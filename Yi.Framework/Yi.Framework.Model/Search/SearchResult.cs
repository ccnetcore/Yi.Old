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
        public List<string> titles = new ();

        public SearchResult()
        {
        }

        public SearchResult(long total,
                       int totalPage,
                       List<Goods> items,
                       List<string> titles
                      ) : base(total, items)
        {

            this.titles = titles;
        }

    }
}
