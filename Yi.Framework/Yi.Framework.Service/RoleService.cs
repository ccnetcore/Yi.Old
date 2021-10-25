using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Service
{
   public partial class RoleService:BaseService<role>, IRoleService
    {
        /// <summary>
        /// 该方法返回的是并列角色并列的菜单，无递归
        /// </summary>
        /// <param name="_role"></param>
        /// <returns></returns>
        public async Task<List<menu>> GetMenusByRole(role _role)
        {
            var role_data =await _Db.Set<role>().Include(u => u.menus)
                .Where(u => u.id == _role.id && u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).FirstOrDefaultAsync();
           var menuList =role_data.menus.Where(u => u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).ToList();        
            return menuList;
        }

        /// <summary>
        /// 这个接口好像没用，算作废吧，怎么能通过角色获取用户呢？数据库表也得改，不能通过角色获取用户
        /// </summary>
        /// <param name="_role"></param>
        /// <returns></returns>
        public async Task<List<user>> GetUsersByRole(role _role)
        {
            var role_data = await _Db.Set<role>().Include(u => u.users)
               .Where(u => u.id == _role.id && u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).FirstOrDefaultAsync();
            return role_data.users.ToList();
        }


        public async Task<bool> SetMenusByRolesId(List<int> menuIds,List<int> roleIds)
        {
            var role_data = await _Db.Set<role>().Include(u=>u.menus).Where(u =>roleIds.Contains(u.id) && u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).ToListAsync();
            if (role_data == null)
            {
                return false;
            }
            var menuList = await _Db.Set<menu>().Where(u => menuIds.Contains(u.id)&&u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).ToListAsync();
            foreach(var role in role_data)
            {
                role.menus =menuList;
            }             
            return await UpdateListAsync(role_data);
        }

        /// <summary>
        /// 好像也不需要通过菜单来获取角色啊，这个数据库也得改
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<List<menu>> GetMenusByRoleId(int roleId)
        {
            var role_data = await _Db.Set<role>().Include(u=>u.menus).Where(u =>u.id==roleId && u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).FirstOrDefaultAsync();
            var menuList = role_data.menus.ToList();
            menuList.ForEach(u => u.roles = null);
            return menuList;
        }
    }
}
