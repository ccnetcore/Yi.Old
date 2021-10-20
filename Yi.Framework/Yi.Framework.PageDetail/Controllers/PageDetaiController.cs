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
        private IUserService _IUserService;
        public PageDetaiController(IUserService IUserService)
        {
            _IUserService = IUserService;
        }
        [Route("/item/{id}.html")]
        public IActionResult Index(int id)
        {
            var htmlmodel = _IUserService.GetEntityById(id);
            return View(htmlmodel);
        }
    }
}
