using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;
using Yi.Framework.Interface;
using Microsoft.EntityFrameworkCore;
using Yi.Framework.Model.ModelFactory;

namespace Yi.Framework.Service
{
           
        public partial class MenuService:BaseService<menu>,IMenuService 
        {
            public MenuService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<int> _ids)
            {
                var menuList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                menuList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(menuList);
            }

            public async Task<IEnumerable<menu>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
        
        public partial class MouldService:BaseService<mould>,IMouldService 
        {
            public MouldService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<int> _ids)
            {
                var mouldList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                mouldList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(mouldList);
            }

            public async Task<IEnumerable<mould>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
        
        public partial class RoleService:BaseService<role>,IRoleService 
        {
            public RoleService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<int> _ids)
            {
                var roleList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                roleList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(roleList);
            }

            public async Task<IEnumerable<role>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
        
        public partial class UserService:BaseService<user>,IUserService 
        {
            public UserService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<int> _ids)
            {
                var userList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                userList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(userList);
            }

            public async Task<IEnumerable<user>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
}
