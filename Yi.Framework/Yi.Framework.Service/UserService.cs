using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Service
{
   public class UserService: BaseService<user>,IUserService
    {
        public UserService(DbContext Db):base(Db)
        { 
        }
          
        public async Task<bool> DelListByUpdateAsync(List<int> _ids)
        {
            var userList = await GetEntitiesAsync(u => _ids.Contains(u.id));
            userList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
            return await UpdateListAsync(userList);
        }
        public async Task<IEnumerable<user>> GetAllEntitiesTrueAsync()
        {
            return await GetEntitiesAsync(u=>u.is_delete==(short)Common.Enum.DelFlagEnum.Normal);
        }
        public async Task<bool> AddEntitesAsync(List<user> _users)
        {
            _users.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Normal);
            return await AddEntitesAsync(_users);
        }
        public async Task<IEnumerable<user>> GetEntitiesTrueByIdAsync(List<int> _ids)
        {
           return await GetEntitiesAsync(u => _ids.Contains(u.id));
        }       
        public async Task<bool> UpdateEntitesAsync(List<user> _users)
        {
           return await UpdateEntitesAsync(_users);
        }

       
    }
}
