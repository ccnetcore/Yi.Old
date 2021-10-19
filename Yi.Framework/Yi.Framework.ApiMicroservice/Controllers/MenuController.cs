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
    public class MenuController : ControllerBase
    {
        private IMenuService _menuService;
        private IUserService _userService;
        public MenuController(IMenuService menuService, IUserService userService)
        {
            _menuService = menuService;
            _userService =userService;
        }
        [HttpGet]
        public async Task<Result> GetMenu()
        {
                      
            return  Result.Success().SetData(await _menuService.GetTopMenu());
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
        /// </summary>
        /// <param name="_menu"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> AddMenu(menu _menu)
        {
            _menu.is_top = (short)Common.Enum.TopFlagEnum.Top;
            await _menuService.AddAsync(_menu);
            return Result.Success();
        }

        /// <summary>
        /// 给一个菜单设置一个接口,Id1为菜单id,Id2为接口id
        /// </summary>
        /// <param name="idDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> SetMouldByMenu(IdDto<int> idDto)
        {
            if (await _menuService.SetMouldByMenu(idDto.id2,idDto.id1))
            {
                return Result.Success();
            }
            return Result.Error(); 
        }

        /// <summary>
        /// 得到该用户有哪些菜单，关联mould
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result> GetMenuByUser()
        {
            var _user = this.HttpContext.GetCurrentUserInfo();
          var menuList= await _userService.GetMenusByUser(_user);
            return Result.Success().SetData(menuList);
            
        }

        /// <summary>
        /// 给一个菜单添加子节点（注意：添加，不是覆盖）
        /// </summary>
        /// <param name="childrenDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> AddChildrenMenu(ChildrenDto<menu> childrenDto)
        {
            
            var _children= await _menuService.AddChildrenMenu(childrenDto.parentId, childrenDto.data); 
            return Result.Success();
        }
        /// <summary>
        /// 获取用户的目录菜单，不包含接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result> GeTopMenuByUser()
        {
            var _user = this.HttpContext.GetCurrentUserInfo();
            var menuList =await _userService.GetMenuByUser(_user);
            return Result.Success().SetData(menuList);
        }
    }
}
