using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Model.Models
{
   public class loopModel:baseModel<int>
    {
        public int? is_top { get; set; }
        public int? sort { get; set; }
        public int? is_show { get; set; }
    }
}
