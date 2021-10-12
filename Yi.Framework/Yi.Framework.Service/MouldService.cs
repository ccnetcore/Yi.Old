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
   public class MouldService:BaseService<mould>, IMouldService
    {
        public MouldService(DbContext Db) : base(Db) { }

        public async Task<bool> DelListByUpdateAsync(List<int> _ids)
        {
            var mouldList =await GetEntitiesAsync(u => _ids.Contains(u.id));
            mouldList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
            return await UpdateListAsync(mouldList);
        }

        public async Task<IEnumerable<mould>> GetAllEntitiesTrueAsync()
        {
            return await GetEntitiesAsync(u => u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
        }

        public async Task<menu> GetMenuByMould(mould _mould)
        {
           var mould_data= await _Db.Set<mould>().Include(u=>u.menu).Where(u => u.id == _mould.id&& u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).FirstOrDefaultAsync();
            return mould_data.menu;
        }
    }
}
