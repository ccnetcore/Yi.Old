using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Model.Models
{
   public class stock:baseModel<int>
    {
        [Comment("可秒杀库存")]
        public int seckill_stock { get; set; }
        [Comment("秒杀总数量")]
        public int seckill_total { get; set; }
        [Comment("库存数量")]
        public int stock_count { get; set; }
        [Comment("sku")]
        public sku sku { get; set; }
    }
}
