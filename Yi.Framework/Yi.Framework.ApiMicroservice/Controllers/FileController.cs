using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Common.Models;
using Yi.Framework.Interface;
using Yi.Framework.WebCore;

namespace Yi.Framework.ApiMicroservice.Controllers
{

    [Route("api/[controller]/[action]")]
    public class FileController : Controller
    {
        private IUserService _userService;
        public FileController(IUserService userService)
        {
            _userService = userService;
        }
        //[HttpGet]
        //[Route("{type}/{imageNmae}")]
        //public IActionResult Get(string type, string imageNmae)
        //{
        //    return new FileStreamResult();
        //}

        //[HttpPost]
        //[Route("{type}/{imageNmae}")]
        //public IActionResult Upload(string type,List<IFormFile> files )
        //{
        //    HttpContext.Request[""];
        //    return new FileStreamResult();
        //}
        [HttpGet]
        public async Task<IActionResult> GetFile()
        {
            var userdata = await _userService.GetAllEntitiesTrueAsync();
            var userList = userdata.ToList();
            Dictionary<string, string> dt = new ();
            dt.Add("sc", "user");
            var bt = Excel.ExportExcel(userList, dt);
            MemoryStream ms = new(bt);
            return new FileStreamResult(ms, "application/vnd.ms-excel");
        }
    }
}
