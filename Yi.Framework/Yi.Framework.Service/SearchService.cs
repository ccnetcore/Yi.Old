using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;
using Yi.Framework.Model.Search;

namespace Yi.Framework.Service
{
    public class SearchService : ISearchService
    {
        private IGoodsService _goodsService;
        public SearchService(IGoodsService goodsService)
        {
            _goodsService = goodsService;
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
                PageResult<spu> result = _goodsService.QuerySpuByPage(page, rows, null, true);
                List<spu> spus = result.rows;
                size = spus.Count;
                foreach (var spu in spus)
                {
                    try
                    {
                        Goods g = BuildGoods(spu);
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
                //_elasticSearchService.Send(goodsList);
                page++;
            } while (size == 100);
        }

        private Goods BuildGoods(spu spu)
        {
            Goods goods = new Goods();
            return goods;
        }
    }
}
