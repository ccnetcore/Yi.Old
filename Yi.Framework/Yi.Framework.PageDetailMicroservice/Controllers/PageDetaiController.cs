using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Common.Const;
using Yi.Framework.Common.Models;
using Yi.Framework.Common.QueueModel;
using Yi.Framework.Core;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;

namespace Yi.Framework.PageDetail.Controllers
{
    public class PageDetaiController : Controller
    {
        private IGoodsService _goodsService;
        private RabbitMQInvoker _rabbitMQInvoker;
        public PageDetaiController(IGoodsService goodsService, RabbitMQInvoker rabbitMQInvoker)
        {
            _goodsService = goodsService;
            _rabbitMQInvoker = rabbitMQInvoker;
        }
        [Route("/item/{id}.html")]
        public IActionResult Index(int id)
        {
            var htmlmodel =_goodsService.GetGoodsBySpuId(id);
            return View(htmlmodel);
        }
    }
}
