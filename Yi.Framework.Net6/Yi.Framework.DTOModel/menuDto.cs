using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.DTOModel
{
    public class menuDto
    {
        public int id { get; set; }
        public string icon { get; set; }
        public string router { get; set; }
        public string menu_name { get; set; }

        public mould mould { get; set; }
    }
}
