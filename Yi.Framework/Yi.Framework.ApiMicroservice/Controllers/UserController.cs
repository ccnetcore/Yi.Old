using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Common.Models;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;

namespace Yi.Framework.ApiMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// 查
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result> GetUser()
        {
            return Result.Success().SetData(await _userService.GetAllEntitiesTrueAsync());
        }

        /// <summary>
        /// 更
        /// </summary>
        /// <param name="_user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<Result> UpdateUser(user _user)
        {
            await _userService.UpdateAsync(_user);
            return Result.Success();

        }

        /// <summary>
        /// 删
        /// </summary>
        /// <param name="_ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<Result> DelListUser(List<int> _ids)
        {
            await _userService.DelListByUpdateAsync(_ids);
            return Result.Success();
        }

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="_user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> AddUser(user _user)
        {
            await _userService.AddAsync(_user);
            return Result.Success();
        }
    }
}
