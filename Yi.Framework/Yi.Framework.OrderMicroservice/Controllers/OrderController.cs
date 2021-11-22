using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Yi.Framework.Common.Models;
using Yi.Framework.DTOModel;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;
using Yi.Framework.WebCore.FilterExtend;

namespace Yi.Framework.OrderMicroservice.Controllers
{
    [ApiController]
    public class OrderController : Controller
    {
       
        private IOrderService _orderService;    
        public OrderController( IOrderService orderService)
        {
            _orderService = orderService;
           
        }
        [HttpPost]
        [Route("/api/order/create")]
        //[TypeFilter(typeof(CustomAction2CommitFilterAttribute))]//避免重复提交
        public async Task< Result> CreateOrder(OrderDto orderDto)
        {
             var data  =await _orderService.CreateOrder(orderDto);
            return Result.Success().SetData(data);
            //CreateOrder做三件事
            //1:创建一个订单，注意有多个商品（购物车）  2：减少库存，这里先别做，用cap   4：死信队列，先别做
        }
    }
}
