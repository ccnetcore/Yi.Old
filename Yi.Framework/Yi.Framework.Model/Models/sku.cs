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
        [Comment("商品的图片，多个图片以‘,’分割")]
        public string images { get; set; }
        [Comment("销售价格，单位为分")]
        public int price { get; set; }
        [Comment("特有规格属性在spu属性模板中的对应下标组合")]
        public string indexes { get; set; }
        [Comment("是否有效，0无效，1有效")]
        public int enable { get; set; }
        [Comment("sku的特有规格参数键值对，json格式，反序列化时请使用linkedHashMap，保证有序")]
        public string own_spec { get; set; }
        [Comment("创建时间")]
        public DateTime crate_time { get; set; }
        [Comment("最后更新时间")]
        public DateTime last_update_time { get; set; }
        [Comment("spu")]
        public spu spu { get; set; }
        [Comment("订单")]
        public List<order> orders { get; set; }
    }
}
