using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
        public async Task< order> CreateOrder(OrderDto orderDto)
        {
            order _order=new();         
            _order.id =(int) Common.Helper.StringHelper.GetGuidToLongID();
            _order.creat_time = DateTime.Now;
            _order.sku =await _DbRead.Set<sku>().Where(u=>u.id==orderDto.carts.skuId).FirstOrDefaultAsync();
           await AddAsync(_order);
            return _order;           
            
        }       
    }
}
