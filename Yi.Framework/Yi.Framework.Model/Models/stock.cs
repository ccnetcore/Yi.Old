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
       
        [Comment("库存数量")]
        public int stock_count { get; set; }
        [Comment("sku")]
        public sku sku { get; set; }
    }
}
