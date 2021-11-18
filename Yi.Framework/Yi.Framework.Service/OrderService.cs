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
            _order.buyer_message = "无";
            _order.buyer_nick = _user.nick;
            _order.buyer_rate = 0;
            _order.source_type = 1;
            _order.shipping_name = "京东";
            _order.shipping_code = "jd123456";
            _order.receiver_zip="330200";
            _order.receiver_state = "江西省";
            _order.receiver_mobile = _user.phone;
            _order.receiver_district = "南昌县";
            _order.receiver_city = "南昌市";
            _order.receiver_address = orderDto.addressId;
            _order.receiver = _user.username;
            _order.promotion_ids = null;
            _order.post_fee = 0;
            _order.payment_type = orderDto.paymentType;
            _order.is_delete = (short)Common.Enum.DelFlagEnum.Normal;
            _order.invoice_type = 1;
            _order.id = Common.Helper.StringHelper.GetGuidToLongID().ToString();
            _order.creat_time = DateTime.Now;
            Dictionary<long, int> car = orderDto.carts.ToDictionary(u => u.skuId, u => u.num);
            List<sku> skus=_goodsService.QuerySkuById(car.Keys.ToList());
            if (skus.Count <= 0)
            {
                throw new Exception("查询的商品信息不存在");
            }
            double pay=0;
            skus.ForEach(u => pay+=u.price);
            _order.total_pay = pay;
            _order.actual_pay = pay;
            _order.sku = skus[0];
            return _order;
        }
    }
}
