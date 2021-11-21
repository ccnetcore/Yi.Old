using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Core;
using Yi.Framework.Interface;
using Yi.Framework.Model.ModelFactory;
using Yi.Framework.Model.Models;
using Yi.Framework.Model.Search;

namespace Yi.Framework.Service
{
    public class SearchService : BaseService<spu>, ISearchService
    {
        private IGoodsService _goodsService;
        private ElasticSearchInvoker _elasticSearchInvoker;
        public SearchService(IGoodsService goodsService, ElasticSearchInvoker elasticSearchInvoker, IDbContextFactory DbFactory) : base(DbFactory)
        {
            _goodsService = goodsService;
            _elasticSearchInvoker = elasticSearchInvoker;
        }
        public void ImpDataBySpu()
        {
            ImportToEs();
        }
        private void ImportToEs()
        {
            int page = 1;
            int size;
            int rows = 100;
            do
            {
                List<Goods> goodsList = new List<Goods>();
                // 上架商品
                PageResult<spu> result = _goodsService.QuerySpuByPage(page, rows, null);
                List<spu> spus = result.rows;
                size = spus.Count;
                foreach (var spu in spus)
                {
                    try
                    {
                        Goods g = GoodsBuild.BuildGoods(spu,_goodsService);
                        
                        // 处理好的数据添加到集合中
                        goodsList.Add(g);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;//部分数据不严格
                    }
                }

                
                // 存入es,先留着，不写
                _elasticSearchInvoker.Send(goodsList);
                page++;
            } while (size == 100);
        }

       


        public SearchResult<Goods> GetData(SearchRequest searchRequest)
        {
            var client = _elasticSearchInvoker.GetElasticClient();
            var GoodsList = client.Search<Goods>(s => s
                .From((searchRequest.getPage() - 1) * searchRequest.getSize())
                .Size(searchRequest.getSize())
                .Query(q => q
                     .Match(m => m
                        .Field(f => f.title)
                        .Query(searchRequest.key)
                     )
                )).Documents.ToList();

            var total = client.Search<Goods>(s => s
                .Query(q => q
                     .Match(m => m
                        .Field(f => f.title)
                        .Query(searchRequest.key)
                     )
                )).Documents.Count();

            if (total == 0)
            {
                return null;
            }


            SearchResult<Goods> searchResult = new()
            {
                total = total,
                titles = GoodsList.Select(u => u.title).Distinct().ToList(),              
                rows = GoodsList,
                totalPages =  GoodsList.Count % 2 == 0 ? GoodsList.Count / total : GoodsList.Count / total + 1
            };
            return searchResult;
        }
    }
}
