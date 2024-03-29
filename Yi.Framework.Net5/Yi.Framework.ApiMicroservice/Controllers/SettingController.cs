﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Common.Const;
using Yi.Framework.Common.Models;
using Yi.Framework.Core;
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
        private readonly CacheClientDB _cacheClientDB;

        public SettingController(ILogger<SettingController> logger, CacheClientDB cacheClientDB)
        {
            _logger = logger;
            _cacheClientDB = cacheClientDB;
        }

     

        /// <summary>
        /// 查
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Result GetSetting()
        {
            var setDto = Common.Helper.JsonHelper.StrToObj<SettingDto>(_cacheClientDB.Get<string>(RedisConst.key));
            return Result.Success().SetData( setDto);
        }

        /// <summary>
        /// 更
        /// </summary>
        /// <param name="settingDto"></param>
        /// <returns></returns>
        [HttpPut]
        public  Result UpdateSetting(SettingDto settingDto)
        {
            var setDto = Common.Helper.JsonHelper.ObjToStr(settingDto);

           _cacheClientDB.Set(RedisConst.key, setDto);
            return Result.Success();

        }
    }
}
