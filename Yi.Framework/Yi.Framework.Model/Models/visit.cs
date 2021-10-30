using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Model.Models
{
   public class visit:baseModel<int>
    {
        public DateTime time { get; set; }
        public int num { get; set; }
    }
}
