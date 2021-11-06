using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.DTOModel
{
   public class SettingDto
    {
        public string InitIcon { get; set; }
        public string InitRole { get; set; }
        public string Title { get; set; }
        public List<string> ImageList { get; set; }       
    }
}
