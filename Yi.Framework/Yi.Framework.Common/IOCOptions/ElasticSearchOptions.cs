using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Common.IOCOptions
{
    public class ElasticSearchOptions
    {
        public string Url { get; set; }
        public string IndexName { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
