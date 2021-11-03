using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Common.Const;
using Yi.Framework.Common.Models;
using Yi.Framework.DTOModel;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;
using Yi.Framework.WebCore;

namespace Yi.Framework.ApiMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class SettingController : ControllerBase
    {
        private readonly ILogger<SettingController> _logger;

        public SettingController(ILogger<SettingController> logger)
        {
            _logger = logger;
        }

     

        /// <summary>
        /// 查
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result> GetSetting()
        {
            var p = RedisConst.stringData[RedisConst.ImageList_key];
            return Result.Success();
        }

        /// <summary>
        /// 更
        /// </summary>
        /// <param name="_Setting"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<Result> UpdateSetting()
        {

            return Result.Success();

        }
    }
}
