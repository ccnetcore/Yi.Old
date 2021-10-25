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
   public partial class MouldService:BaseService<mould>, IMouldService
    {
        public async Task<menu> GetMenuByMould(mould _mould)
        {
            var menu_data = await _Db.Set<menu>().Include(u => u.mould)
                .Where(u => u.mould == _mould && u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).FirstOrDefaultAsync();        
            return menu_data;
        }
    }
}
