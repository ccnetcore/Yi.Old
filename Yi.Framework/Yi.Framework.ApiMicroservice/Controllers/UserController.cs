using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Common.Models;
using Yi.Framework.DTOModel;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;
using Yi.Framework.WebCore;

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

        /// <summary>
        /// 通过上下文对象获取user（注意，_user下只有userId），返回值为该用户下所有的menu，(注意子类递归)并且需要关联mould
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> GetMenuMould()
        {
            var _user= this.HttpContext.GetCurrentUserInfo();
            var menu_data = await _userService.GetMenusByUser(_user);
            return Result.Success().SetData(menu_data);
        }

        /// <summary>
        /// 给多个用户设置多个角色，ids有用户id与 角色列表ids，多对多,ids1用户,ids2为角色
        /// </summary>
        /// <param name="idsListDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> SetRoleByUser(IdsListDto<int> idsListDto)
        {
            var _user = this.HttpContext.GetCurrentUserInfo();
          await  _userService.SetRolesByUser(idsListDto.ids2, idsListDto.ids1);
            return Result.Success();
        }
    }
}
