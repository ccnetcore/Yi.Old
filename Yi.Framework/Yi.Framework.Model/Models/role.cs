using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Model.Models
{
    public class role:baseModel<int>
    {
        public string role_name { get; set; }
        public string introduce { get; set; }


        public List<menu> menus { get; set; }
    }
}
