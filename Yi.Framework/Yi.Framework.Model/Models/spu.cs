using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Model.Models
{
    public class spu : baseModel<int>
    {
        [Comment("标题")]
        public string title { get; set; }
        [Comment("创建时间")]
        public DateTime crate_time { get; set; }
        [Comment("skus")]
        public List<sku> skus { get; set; }

    }
}
