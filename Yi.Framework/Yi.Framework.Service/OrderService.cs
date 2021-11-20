using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.DTOModel;
using Yi.Framework.Interface;
using Yi.Framework.Model.ModelFactory;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Service
{
    public partial class OrderService:BaseService<order>,IOrderService
    {
        private IGoodsService _goodsService;
        public OrderService(IGoodsService goodsService,IDbContextFactory db):base(db)
        {
            _goodsService = goodsService;
        }
        public order CreateOrder(OrderDto orderDto, user _user)
        {
            order _order=new();
           
            _order.id =(int) Common.Helper.StringHelper.GetGuidToLongID();
            _order.creat_time = DateTime.Now;
            Dictionary<long, int> car = orderDto.carts.ToDictionary(u => u.skuId, u => u.num);
            List<sku> skus=_goodsService.QuerySkuById(car.Keys.ToList());
            if (skus.Count <= 0)
            {
                throw new Exception("查询的商品信息不存在");
            }
           
            _order.sku = skus[0];
            return _order;
        }       
    }
}
