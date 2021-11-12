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
        private ICategoryService _categoryService;
        private IBrandService _brandService;
        private ElasticSearchInvoker _elasticSearchInvoker ;
        public SearchService(IGoodsService goodsService, ElasticSearchInvoker elasticSearchInvoker, IBrandService brandService, ICategoryService categoryService, IDbContextFactory DbFactory) : base(DbFactory)
        {
            _goodsService = goodsService;
            _elasticSearchInvoker = elasticSearchInvoker;
            _categoryService = categoryService;
            _brandService = brandService;
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
                PageResult<spu> result = _goodsService.QuerySpuByPage(page, rows, null, 1);
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
                _elasticSearchInvoker.Send(goodsList);
                page++;
            } while (size == 100);
        }
       
        private Goods BuildGoods(spu spu)
        {
          var _spu=  _DbRead.Set<spu>().Include(u => u.cid1).Include(u => u.cid2).Include(u => u.cid3).Include(u => u.spu_Detail).Include(u => u.brand).Include(u => u.skus).Where(u =>u.id==spu.id&& u.is_delete ==(short)Common.Enum.DelFlagEnum.Normal).FirstOrDefault();
            Goods goods = new();
            goods.brand = _spu.brand;
            goods.cid1 = _spu.cid1;
            goods.cid2 = _spu.cid2;
            goods.cid3 = _spu.cid3;
            goods.createTime = _spu.crate_time;
            goods.subtitle = _spu.sub_title;
            goods.price = _spu.skus.Select(u => u.price).ToHashSet();
            goods.all = _spu.brand.name + ',' + _spu.cid1.name + ',' + _spu.cid2.name + ',' + _spu.cid3.name + ',' + _spu.title;
            goods.skus = _spu.skus;
            var specParam = _goodsService.SpecParam(_spu.cid3, 1);
            //获取通用规格参数
            Dictionary<long, string> genericSpec = JsonConvert.DeserializeObject<Dictionary<long, string>>(_spu.spu_Detail.generic_spec);
            //获取特有规格参数
            Dictionary<long, List<string>> specialSpec = JsonConvert.DeserializeObject<Dictionary<long, List<string>>>(_spu.spu_Detail.special_spec);
            //对规格进行遍历，并封装spec，其中spec的key是规格参数的名称，值是商品详情中的值
            specParam.ForEach(u =>
            {
                //key是规格参数的名称
                string key = u.name;
                object value = "";

                if (u.generic == 1)
                {
                    //参数是通用属性，通过规格参数的ID从商品详情存储的规格参数中查出值
                    value = genericSpec[u.id];
                    if (u.numeric == 1)
                    {
                        //参数是数值类型，处理成段，方便后期对数值类型进行范围过滤
                        value = ChooseSegment(value.ToString(), u);
                    }
                }
                else
                {
                    //参数不是通用类型
                    value = specialSpec[u.id];
                }
                value ??= "其他";
                //存入map
                goods.specs.Add(key, value);
            });
            return goods;
        }
        private static string ChooseSegment(string value, spec_param p)
        {
            try
            {
                double val = double.Parse(value);
                string result = "其它";
                // 保存数值段
                foreach (string segment in p.segments.Split(","))
                {
                    string[] segs = segment.Split("-");
                    // 获取数值范围
                    double begin = double.Parse(segs[0]);
                    double end = double.MaxValue;
                    if (segs.Length == 2)
                    {
                        end = double.Parse(segs[1]);
                    }
                    // 判断是否在范围内
                    if (val >= begin && val < end)
                    {
                        if (segs.Length == 1)
                        {
                            result = segs[0] + p.unit + "以上";
                        }
                        else if (begin == 0)
                        {
                            result = segs[1] + p.unit + "以下";
                        }
                        else
                        {
                            result = segment + p.unit;
                        }
                        break;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {

               throw new Exception(ex.Message);
            }

        }

        public SearchResult<Goods> GetData(SearchRequest searchRequest)
        {
            //先通过ES分词查询，得到一个goodslist
            List<Goods> GoodsList=new List<Goods>();
            SearchResult<Goods> searchResult = new()
            {
                total = 100,
                specs = GoodsList.Select(u => u.specs).ToList(),
                brands = GoodsList.Select(u => u.brand).ToList(),
                categories = GoodsList.Select(u => u.cid3).ToList(),
                rows=GoodsList,
                totalPages=GoodsList.Count%2==0?GoodsList.Count/100:GoodsList.Count / 100+1               
            };
            return searchResult;         
        }
//        var cid3s = GoodsList.Select(u => u.cid3).Distinct().ToList();
//        var brandIds = GoodsList.Select(u => u.brand).Distinct().ToList();
//        List<int> cids = new();
//        List<int> bids = new();
//        cid3s.ForEach(u => { cids.Add(u.id); });
//            brandIds.ForEach(u => { bids.Add(u.id); });
//List<category> categories = await _categoryService.GetByIds(cids);
//List<brand> brands = await _brandService.GetByIds(bids);
//List<Dictionary<string, object>> specs = null;

//if (categories != null && categories.Count == 1)
//{
//    //specs = HandleSpecs(categories[0].id, GoodsList);
//}
//foreach (var item in GoodsList)
//{
//    item.specs = null;
//}
//int page = total % searchRequest.getSize() == 0 ? total / searchRequest.getSize() : (total / searchRequest.getSize()) + 1;
//return new SearchResult<Goods>(total, page, GoodsList, categories, brands, specs);
        //private List<Dictionary<string, object>> HandleSpecs(long id, List<Goods> goods)
        //{
        //    List<Dictionary<string, object>> specs = new();

        //    //查询可过滤的规格参数

        //    List<spec_param> tbSpecParams = _goodsService.(null, id, true, null);
        //    //基本查询条件
        //    foreach (spec_param param in tbSpecParams)
        //    {
        //        //聚合
        //        string name = param.name;
        //        // 如果对keyword类型的字符串进行搜索必须是精确匹配terms
        //        //queryBuilder.addAggregation(AggregationBuilders.terms(name).field("specs." + name + ".keyword"));
        //        Dictionary<string, object> map = new();
        //        map.Add("k", name);
        //        var dicspec = goods.Select(m => m.specs).Where(m => m.Keys.Contains(name));

        //        var options = new List<string>();
        //        foreach (var item in dicspec)
        //        {
        //            options.Add(item[name].ToString());
        //        }
        //        map.Add("options", options.Distinct().ToList());

        //        specs.Add(map);
        //    }
        //    return specs;
        //}


    }
    }
