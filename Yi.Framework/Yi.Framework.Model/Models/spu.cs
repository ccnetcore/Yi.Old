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
        [Comment("子标题")]
        public string sub_title { get; set; }
        [Comment("是否上架")]
        public int saleable { get; set; }
        [Comment("是否有效")]
        public int valid { get; set; }
        [Comment("创建时间")]
        public DateTime crate_time { get; set; }
        [Comment("最后更新时间")]
        public DateTime last_update_time { get; set; }
        [Comment("类别")]
        public List<category> categories { get; set; }
        [Comment("品牌")]
        public brand brand { get; set; }
        [Comment("spu详情")]
        public spu_detail spu_Detail { get; set; }
        [Comment("skus")]
        public List<sku> skus { get; set; }

    }
}
