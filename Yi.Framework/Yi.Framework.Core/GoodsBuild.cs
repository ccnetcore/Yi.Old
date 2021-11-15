using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;
using Yi.Framework.Model.Search;

namespace Yi.Framework.Core
{
    public static class GoodsBuild
    {
     
        public static Goods BuildGoods(spu _spu, IGoodsService _goodsService)
        {
            Goods goods = new();
            goods.brand = _spu.brand;
            goods.cid1 = _spu.cid1;
            goods.cid2 = _spu.cid2;
            goods.cid3 = _spu.cid3;
            goods.createTime = _spu.crate_time;
            goods.subtitle = _spu.sub_title;
            goods.price = _spu.skus.Select(u => u.price).ToHashSet();
            goods.all = _spu.brand.name +','+ _spu.cid3.name + ',' + _spu.title;
            goods.skus = _spu.skus;
            var specParam = _goodsService.SpecParam(_spu.cid3);//得到该商品有的所有规程参数，name为规程参数名，id为规格参数id，下面的通用规格与特殊规格加起来等于这个
            //获取通用规格参
            specParam.ForEach(u => u.category = null);
            Dictionary<int, string> genericSpec = Common.Helper.JsonHelper.StrToObj<Dictionary<int, string>>(_spu.spu_Detail.generic_spec);
            //获取特有规格参数
            Dictionary<int, List<string>> specialSpec = Common.Helper.JsonHelper.StrToObj<Dictionary<int, List<string>>>(_spu.spu_Detail.special_spec);
            //对规格进行遍历，并封装spec，其中spec的key是规格参数的名称，值是商品详情中的值

            foreach (var item in genericSpec)
            {
                var name = specParam.Where(u => u.id == item.Key).Select(u => u.name).FirstOrDefault();            
                goods.specs.Add(name, item.Value);
            }

            foreach (var item in specialSpec)
            {
                var name = specParam.Where(u => u.id == item.Key).Select(u => u.name).FirstOrDefault();
                goods.specs.Add(name, item.Value);
            }

            return goods;
        }
    }
}
