using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Model.Models
{
    public class order : baseModel<int>
    {
            
        [Comment("订单创建时间")]
        public DateTime creat_time { get; set; }     
        [Comment("sku")]
        public sku sku { get; set; }
        [Comment("数量")]
        public int num { get; set; }
    }
}
