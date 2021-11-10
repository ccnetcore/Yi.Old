using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Model.Models
{
   public class category:baseModel<int>
    {
        [Comment("类别名称")]
        public string name { get; set; }
        [Comment("排序")] 
        public int sort { get; set; }
        [Comment("是否父类别")] 
        public int is_parent { get; set; }
        [Comment("子类别")] 
        public List<category> chidrens { get; set; }
        [Comment("品牌")]
        public List<brand> brands { get; set; }
        [Comment("spu")]
        public List<spu> spus { get; set; }
        [Comment("规格组")] 
        public List<spec_group> spec_Groups { get; set; }
        [Comment("规格")] 
        public List<spec_param> spec_Params { get; set; } 
    }
}
