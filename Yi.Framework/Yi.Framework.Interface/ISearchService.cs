using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Search;

namespace Yi.Framework.Interface
{
   public interface ISearchService
    {
         void ImpDataBySpu();
        SearchResult<Goods> GetData(SearchRequest searchRequest);
    }
}
