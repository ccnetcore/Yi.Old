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
        short Normal = (short)Common.Enum.DelFlagEnum.Normal;
            
        public async Task<List<role>> GetRolesByUserId(int userId)
        {
            var user_data =await _Db.Set<user>().Include(u => u.roles).Where(u => u.id==userId).FirstOrDefaultAsync();
            var roleList = user_data.roles.Where(u=>u.is_delete==Normal).ToList();       
            return roleList;
        }


        public async Task<bool> SetMenusByRolesId(List<int> menuIds,List<int> roleIds)
        {
            var role_data = await _Db.Set<role>().Include(u => u.menus).ThenInclude(u => u.children).Where(u =>roleIds.Contains(u.id) && u.is_delete == Normal).ToListAsync();           
            var menuList = await _Db.Set<menu>().Where(u => menuIds.Contains(u.id)&&u.is_delete ==Normal).ToListAsync();
            foreach(var role in role_data)
            {
                role.menus =menuList;
            }             
            return await UpdateListAsync(role_data);
        }
      
        public async Task<List<menu>> GetMenusByRoleId(List< int> roleIds)
        {
            var role_data = await _Db.Set<role>().Include(u => u.menus).Where(u => roleIds.Contains(u.id) && u.is_delete == Normal).ToListAsync();
            List<menu> menuList = new();
            role_data.ForEach(u =>
            {
                var m = u.menus.Where(u => u.is_delete == Normal).ToList();
                menuList = menuList.Union(m).ToList();
            });
            return menuList;
        }
        public async Task<List<menu>> GetTopMenusByRoleId(int roleId)
        {
            var role_data = await _Db.Set<role>().Include(u=>u.menus).Where(u => u.id == roleId).FirstOrDefaultAsync();
            var menuList = role_data.menus.Where(u => u.is_delete == Normal).ToList();
            
            return menuList;
        }

        public async Task<List<menu>> GetMenusByRole(int roleId)
        {
            var role_data = await _Db.Set<role>().Include(u => u.menus).Where(u => u.id == roleId).FirstOrDefaultAsync();
            var menuList = role_data.menus.Where(u => u.is_delete == Normal).ToList();
            return menuList;
        }

    }
}
