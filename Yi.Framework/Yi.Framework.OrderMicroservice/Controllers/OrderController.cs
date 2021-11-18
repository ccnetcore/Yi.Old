using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        [Route("/api/order/create")]
        [TypeFilter(typeof(CustomAction2CommitFilterAttribute))]//避免重复提交
        public Result CreateOrder(OrderDto orderDto)
        {
            user _user = new user();
            var orderId = _orderService.CreateOrder(orderDto, _user);
            return Result.Success().SetData(orderId);

            //CreateOrder做三件事
            //1:创建一个订单，注意有多个商品（购物车）  2：减少库存，这里先别做，用cap   3：清空购物车先别做用消息队列 4：死信队列，先别做
        }
    }
}
