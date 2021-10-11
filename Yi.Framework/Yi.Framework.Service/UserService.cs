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
            return await _Db.Set<user>().Where(u=>u.is_delete==(short)Common.Enum.DelFlagEnum.Normal).ToListAsync();
        }
    }
}
