using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Interface
{
   public partial interface IRoleService:IBaseService<role> 
    {

        /// <summary>
        /// 获取该角色的所有菜单
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<menu>> GetMenusByRole(int roleId);

        /// <summary>
        /// 给多个角色设置多个菜单
        /// </summary>
        /// <param name="menuIds"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        Task<bool> SetMenusByRolesId(List<int> menuIds, List<int> roleIds);
        /// <summary>
        /// 获取多个用户的菜单，并列，不包含子菜单
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        Task<List<menu>> GetMenusByRoleId(List<int> roleIds);
        /// <summary>
        /// 获取用户的角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<role>> GetRolesByUserId(int userId);
        /// <summary>
        /// 获取该角色的top菜单
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<menu>> GetTopMenusByRoleId(int roleId);
        
    }
}
