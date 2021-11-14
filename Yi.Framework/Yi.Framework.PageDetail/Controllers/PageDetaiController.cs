using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;

namespace Yi.Framework.PageDetail.Controllers
{
    public class PageDetaiController : Controller
    {
        private IGoodsService _goodsService;
        public PageDetaiController(IGoodsService goodsService)
        {
            _goodsService = goodsService;
        }
        [Route("/item/{id}.html")]
        public IActionResult Index(int id)
        {
            var htmlmodel =_goodsService.GetGoodsBySpuId(id);
            return View(htmlmodel);
        }
    }
}
