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
    public partial class StockService:BaseService<stock>, IStockService
    {
        public async Task<bool>Destocking(int skuId)
        {
          var data= await _DbRead.Set<stock>().Include(u=>u.sku).ThenInclude(u=>u.orders).Where(u=>u.id==skuId).FirstOrDefaultAsync();
            var num = data.sku.orders.Where(u=>u.is_delete== (short)Common.Enum.DelFlagEnum.Normal).Count();  
            data.stock_count-=num;
            data.sku.orders.ForEach(u=>{u.is_delete=(short)Common.Enum.DelFlagEnum.Deleted;});
           return await UpdateAsync(data);
        }
    }
}
