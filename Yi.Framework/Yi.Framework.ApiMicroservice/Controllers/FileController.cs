using Microsoft.AspNetCore.Authorization;
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
        [HttpPost]
        [Authorize]
        public async Task<Result> EditIcon(IFormFile file)
        {
            var _user = HttpContext.GetCurrentUserInfo();
            var user_data = await _userService.GetUserById(_user.id);
            var type = "image";
          var filename = await Upload(type, file);      
            user_data.icon = filename;
            await _userService.UpdateAsync(user_data);
            return Result.Success();
        }
        [HttpGet]
        public IActionResult Get(string type, string imageNmae)
        {
            var path = Path.Combine($"wwwroot\\{type}", imageNmae);
            var stream = System.IO.File.OpenRead(path);
            var MimeType = Common.Helper.MimeHelper.GetMimeMapping(imageNmae);
            return new FileStreamResult(stream, MimeType);
        }


        private async Task<string> Upload(string type,IFormFile file)
        {
            
            string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            using (var stream = new FileStream(Path.Combine($"wwwroot\\{type}", filename), FileMode.CreateNew, FileAccess.Write))
            {
                await file.CopyToAsync(stream);
            }

            return filename;
        }
         [HttpGet]
        public async Task<IActionResult>ExportFile()
        {
            var userdata = await _userService.GetAllEntitiesTrueAsync();
            var userList = userdata.ToList();
            List<string> header = new() { "用户", "密码", "头像",  "昵称", "邮箱", "ip","年龄", "个人介绍", "地址", "手机", "角色" };
           var filename= Common.Helper.ExcelHelper.CreateExcelFromList(userList,header,_env.ContentRootPath.ToString());
            var MimeType = Common.Helper.MimeHelper.GetMimeMapping(filename);
            return new FileStreamResult(new FileStream(Path.Combine(_env.ContentRootPath+@"\wwwroot\Excel", filename), FileMode.Open),MimeType);
        }
    }
}
