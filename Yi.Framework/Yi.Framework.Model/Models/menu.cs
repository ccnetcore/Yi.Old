using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Model.Models
{
    public class menu :loopModel
    {
        public string icon { get; set; }
        public string router { get; set; }
        public string menu_name { get; set; }
        
       

        public ICollection<menu> children { get; set; }
        public mould mould { get; set; }
        public ICollection<role> roles { get; set; } 
    }
}
