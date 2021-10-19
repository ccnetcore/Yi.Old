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
        Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<role>> GetAllEntitiesTrueAsync();

        /// <summary>
        /// 获取该角色的所有菜单
        /// </summary>
        /// <param name="_role"></param>
        /// <returns></returns>
        Task<List<menu>> GetMenusByRole(role _role);

        /// <summary>
        /// 获取含有该角色的所有用户
        /// </summary>
        /// <param name="_role"></param>
        /// <returns></returns>
        Task<List<user>> GetUsersByRole(role _role);

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

    }
}
