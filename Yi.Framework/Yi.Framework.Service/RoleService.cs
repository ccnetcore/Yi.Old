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
   public class RoleService:BaseService<role>, IRoleService
    {
        public RoleService(DbContext Db):base(Db)
        { 
        }

        public async Task<bool> DelListByUpdateAsync(List<int> _ids)
        {
            var userList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
            userList.ToList().ForEach(u => u.is_delete =(short)Common.Enum.DelFlagEnum.Deleted);
            return await UpdateListAsync(userList);
        }
        public async Task<IEnumerable<role>> GetAllEntitiesTrueAsync()
        {
            return await GetEntitiesAsync(u => u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
        }

        public async Task<List<menu>> GetMenusByRole(role _role)
        {
            var role_data =await _Db.Set<role>().Include(u => u.menus)
                .Where(u => u.id == _role.id && u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).FirstOrDefaultAsync();
            return role_data.menus.ToList();
        }

        public async Task<List<user>> GetUsersByRole(role _role)
        {
            var role_data = await _Db.Set<role>().Include(u => u.users)
               .Where(u => u.id == _role.id && u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).FirstOrDefaultAsync();
            return role_data.users.ToList();
        }

        public async Task<bool> SetMenusByRolesId(List<int> menuIds, int roleId)
        {
            var role_data = await GetEntity(u => u.id == roleId && u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            if (role_data == null)
            {
                return false;
            }
            var menuList = _Db.Set<menu>().Where(u => menuIds.Contains(u.id)&&u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).ToListAsync();
            
             role_data.menus = (ICollection<menu>)menuList;
            return await AddAsync(role_data);
        }
    }
}
