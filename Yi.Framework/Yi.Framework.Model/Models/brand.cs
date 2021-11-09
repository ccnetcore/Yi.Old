using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Model.Models
{
   public class brand:baseModel<int>
    {
        [Comment("品牌名称")]
        public string name { get; set; }
        [Comment("品牌图片")]
        public string image { get; set; }
        [Comment("品牌首字母")] 
        public string letter { get; set; }
        [Comment("类别")] 
        public List<category > categories { get; set; }
        [Comment("spu")] 
        public List<spu> spus { get; set; }
        
    }
}
