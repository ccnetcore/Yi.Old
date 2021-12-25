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
       /// <summary>
       /// 这个获取的是菜单，用的是菜单表，应该放到菜单service里面，像这种只用到id的，就传一个id就可以了
       /// </summary>
       /// <param name="_mould"></param>
       /// <returns></returns>
        public async Task<menu> GetMenuByMould(mould _mould)
        {
            var menu_data = await _Db.Set<menu>().Include(u => u.mould).Where(u => u.mould == _mould && u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).FirstOrDefaultAsync();        
            return menu_data;
        }
    }
}
