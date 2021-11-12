using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Model.Search
{
    public class SearchResult<Goods> : PageResult<Goods>
    {
        public List<brand> brands = new List<brand>();
        public List<category> categories = new List<category>();
        //规格参数过滤条件
        public List<Dictionary<string, object>> specs = new List<Dictionary<string, object>>();

        public SearchResult()
        {
        }

        public SearchResult(long total,
                       int totalPage,
                       List<Goods> items,
                       List<category> categories,
                       List<brand> brands,
                       List<Dictionary<string, object>> specs) : base
            (total, items)
        {

            this.categories = categories;
            this.brands = brands;
            this.specs = specs;
        }

    }
}
