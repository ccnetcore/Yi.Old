using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Model.Models
{
    public class sku : baseModel<int>
    {
        [Comment("商品标题")]
        public string title { get; set; }          
        [Comment("订单")]
        public List<order> orders { get; set; }
    }
}
