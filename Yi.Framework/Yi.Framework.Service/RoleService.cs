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
            var roleList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
            roleList.ToList().ForEach(u => u.is_delete =(short)Common.Enum.DelFlagEnum.Deleted);
            return await UpdateListAsync(roleList);
        }
        public async Task<IEnumerable<role>> GetAllEntitiesTrueAsync()
        {
            return await GetEntitiesAsync(u => u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
        }
        public async Task<bool> AddEntitesAsync(List<role> _roles)
        {
            _roles.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Normal);
            return await AddEntitesAsync(_roles);
        }
        public async Task<IEnumerable<role>> GetEntitiesTrueByIdAsync(List<int> _ids)
        {
            return await GetEntitiesAsync(u => _ids.Contains(u.id));
        }
        public async Task<bool> UpdateEntitesAsync(List<role> _roles)
        {
            return await UpdateEntitesAsync(_roles);
        }
    }
}
