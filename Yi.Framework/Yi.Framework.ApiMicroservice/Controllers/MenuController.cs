using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MenuController : ControllerBase
    {
        private IMenuService _menuService;
        private IUserService _userService;
        public MenuController(IMenuService menuService, IUserService userService)
        {
            _menuService = menuService;
            _userService =userService;
        }
        /// <summary>
        /// 这个是要递归的，但是要过滤掉删除的，所以，可以写一个通用过滤掉删除的方法
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result> GetMenuInMould()
        {
            return Result.Success().SetData(await _menuService.GetMenuInMould());
        }

        /// <summary>
        /// 更
        /// </summary>
        /// <param name="_menu"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<Result> UpdateMenu(menu _menu)
        {
            await _menuService.UpdateAsync(_menu);
            return Result.Success();

        }

        /// <summary>
        /// 删
        /// </summary>
        /// <param name="_ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<Result> DelListMenu(List<int> _ids)
        {
            await _menuService.DelListByUpdateAsync(_ids);
            return Result.Success();
        }

        /// <summary>
        /// 增
        /// 现在，top菜单只允许为一个
        /// </summary>
        /// <param name="_menu"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> AddTopMenu(menu _menu)
        {
            await _menuService.AddTopMenu(_menu);
            return Result.Success();
        }

        /// <summary>
        /// 给一个菜单设置一个接口,Id1为菜单id,Id2为接口id
        /// 用于给菜单设置接口
        /// </summary>
        /// <param name="idDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> SetMouldByMenu(IdDto<int> idDto)
        {
            await _menuService.SetMouldByMenu(idDto.id1, idDto.id2);
            return Result.Success();
        }


        /// <summary>
        /// 给一个菜单添加子节点（注意：添加，不是覆盖）
        /// </summary>
        /// <param name="childrenDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> AddChildrenMenu(ChildrenDto<menu> childrenDto)
        {
            await _menuService.AddChildrenMenu(childrenDto.parentId, childrenDto.data);
            return Result.Success();
        }

        /// <summary>
        /// 获取用户的目录菜单，不包含接口
        /// 用于账户信息页面，显示这个用户有哪些菜单，需要并列
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result> GetTopMenusByHttpUser()
        {
            HttpContext.GetCurrentUserInfo(out List<int> menuIds);

            return Result.Success().SetData(await _menuService.GetTopMenusByTopMenuIds(menuIds));
        }
    }
}
