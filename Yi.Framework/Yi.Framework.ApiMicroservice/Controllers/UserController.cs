using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
        /// 给多个用户设置多个角色，ids有用户id与 角色列表ids，多对多,ids1用户,ids2为角色
        /// 用户设置给用户设置角色
        /// </summary>
        /// <param name="idsListDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> SetRoleByUser(IdsListDto<int> idsListDto)
        {
            await _userService.SetRoleByUser(idsListDto.ids2, idsListDto.ids1);
            return Result.Success();
        }

        /// <summary>
        /// 根据http上下文的用户得到该用户信息，关联角色
        /// 用于显示账号信息页中的用户信息和角色信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result> GetUserInRolesByHttpUser()
        {
            var _user =  HttpContext.GetCurrentUserInfo();
            return Result.Success().SetData( await _userService.GetUserInRolesByHttpUser(_user.id));
        }

        /// <summary>
        /// 得到登录用户的递归菜单，放到导航栏
        /// 用户放到导航栏中
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result> GetMenuByHttpUser()
        {
            var _user = HttpContext.GetCurrentUserInfo();
            return Result.Success().SetData(await _userService.GetMenuByHttpUser(_user.id));
        }

        /// <summary>
        /// 得到请求模型
        /// </summary>
        /// <param name="router"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result> GetAxiosByRouter(string router)
        {
            var _user = HttpContext.GetCurrentUserInfo(out List<int> menuIds);
            var menuList= await _userService.GetAxiosByRouter(router, _user.id, menuIds);
            AxiosUrlsModel urlsModel = new();
            menuList.ForEach(u =>
            {
                switch (u.menu_name)
                {
                    case "get":urlsModel.get = u.mould.url;break;
                    case "del": urlsModel.del = u.mould.url; break;
                    case "add": urlsModel.add = u.mould.url; break;
                    case "update": urlsModel.update = u.mould.url; break;
                }
            });
            
            return Result.Success().SetData(urlsModel);
        }

    }
}
