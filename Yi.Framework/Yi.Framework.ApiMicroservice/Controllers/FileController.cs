using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
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
    [ApiController]
    public class FileController : ControllerBase
    {
        private IUserService _userService;
        private readonly IHostEnvironment _env;
        public FileController(IUserService userService, IHostEnvironment env)
        {
            _userService = userService;
            _env = env;
        }

        public FileController()
        {
        }

        [HttpGet]
        [Route("{type}/{imageNmae}")]
        public IActionResult Get(string type, string imageNmae)
        {
            var path = Path.Combine(@"wwwroot/file", imageNmae);
            var stream = System.IO.File.OpenRead(path);
            var MimeType = Common.Helper.MimeMapping.GetMimeMapping(imageNmae);
            return new FileStreamResult(stream, MimeType);
        }

        [HttpPost]
        [Route("{type}/{imageNmae}")]
        public async Task<Result> Upload(string type,IFormFile file)
        {
            if (type != Common.Const.FileConst.Image) { return Result.Error(); }
            string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filepath = Path.Combine(@"wwwroot/image", filename);
            using (var stream = new FileStream(Path.Combine(_env.ContentRootPath, filepath), FileMode.CreateNew, FileAccess.Write))
            {
                await file.CopyToAsync(stream);
            }

            return Result.Success().SetData(filename);
        }
        [HttpGet]
        public async Task<IActionResult> GetFile()
        {
            var userdata = await _userService.GetAllEntitiesTrueAsync();
            var userList = userdata.ToList();
            Dictionary<string, string> dt = new();
            dt.Add("sc", "user");
            var bt = Excel.ExportExcel(userList, dt);
            MemoryStream ms = new(bt);
            return new FileStreamResult(ms, "application/vnd.ms-excel");
        }
    }
}
