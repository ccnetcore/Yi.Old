using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Model.Models
{
   public class spec_param:baseModel<int>
    {
        [Comment("参数名")]
        public string name { get; set; }
        [Comment("是否是数字类型参数，true或false")]
        public int numeric { get; set; }
        [Comment("数字类型参数的单位，非数字类型可以为空")]
        public string unit { get; set; }
        [Comment("是否是sku通用属性，true或false")]
        public int generic { get; set; }
        [Comment("是否用于搜索过滤，true或false")]
        public int searching { get; set; }
        [Comment("数值类型参数，如果需要搜索，则添加分段间隔值，如CPU频率间隔：0.5-1.0")]
        public string segments { get; set; }
        [Comment("规格组")]
        public spec_group spec_Group { get; set; }
        [Comment("类别")]
        public category category { get; set; }
        public spu_detail spu_Detail { get; set; }
    }
}
