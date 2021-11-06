using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Model.Models
{
    public class spec_group : baseModel<int>
    {
        [Comment("规格组名称")]
        public string name { get; set; }
        [Comment("类别")]
        public category category { get; set; }
        [Comment("规格")]
        public List<spec_param> spec_Params { get; set; }
    }
}
