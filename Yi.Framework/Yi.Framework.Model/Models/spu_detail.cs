using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Model.Models
{
    public class spu_detail : baseModel<int>
    {
        [Comment("描述")]
        public string description { get; set; }
        [Comment("通用规格参数数据")]
        public string generic_spec { get; set; }
        [Comment("特有规格参数及可选值信息，json格式")]
        public string special_spec { get; set; }
        [Comment("包装清单")]
        public string packing_list { get; set; }
        [Comment("售后服务")]
        public string after_service { get; set; }
        [Comment("规格参数")]
        public spec_param spec { get; set; }
    }
}
