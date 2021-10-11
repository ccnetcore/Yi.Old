using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Model.Models
{
   public class mould:baseModel<int>
    {
        public string mould_name { get; set; }
        public string url { get; set; }
        public menu menu { get; set; }
    }
}
