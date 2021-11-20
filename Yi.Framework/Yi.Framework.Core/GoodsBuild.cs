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
            goods.createTime = _spu.crate_time;
            goods.skus = _spu.skus;
           goods.title = _spu.title;
            goods.id = _spu.id;
            return goods;
        }
    }
}
