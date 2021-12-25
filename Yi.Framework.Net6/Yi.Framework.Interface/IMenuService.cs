using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Interface
{
   public partial interface IMenuService:IBaseService<menu> 
    {
        /// <summary>
        /// 获取所有菜单，关联接口
        /// 这个是要递归的，但是要过滤掉删除的，所以，可以写一个通用过滤掉删除的方法
        /// </summary>
        /// <returns></returns>
        Task<menu> GetMenuInMould();
        /// <summary>
        /// 增
        /// 现在，top菜单只允许为一个
        /// </summary>
        /// <returns></returns>
        Task<bool> AddTopMenu(menu _menu);
        /// <summary>
        /// 给一个菜单设置一个接口,Id1为菜单id,Id2为接口id
        /// 用于给菜单设置接口
        /// </summary>
        /// <returns></returns>
        Task<menu> SetMouldByMenu(int id1, int id2);
        /// <summary>
        /// 给一个菜单添加子节点（注意：添加，不是覆盖）
        /// </summary>
        /// <returns></returns>
        Task<menu> AddChildrenMenu(int menu_id, menu _children);
        /// <summary>
        /// 获取用户的目录菜单，不包含接口
        /// 用于账户信息页面，显示这个用户有哪些菜单，需要并列
        /// </summary>
        /// <returns></returns>
        Task<List<menu>> GetTopMenusByTopMenuIds(List<int> menuIds);
        Task<List<menu>> GetTopMenuByUserId(int userId);
    }
}
