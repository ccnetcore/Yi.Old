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

        private ElasticSearchInvoker _elasticSearchInvoker ;
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
            Goods goods = new Goods();
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

                throw;
            }

        }
    }
}
