using Microsoft.AspNetCore.Mvc;
using Yi.Framework.Common.Const;
using Yi.Framework.Common.Models;
using Yi.Framework.Common.QueueModel;
using Yi.Framework.Core;
using Yi.Framework.Interface;
using Yi.Framework.Model.Search;

namespace Yi.Framework.SearchMicroservice.Controllers
{
    [ApiController]
    public class SearchController : ControllerBase
    {
        private ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        [Route("api/search/page")]
        [HttpPost]
        public Result Search(SearchRequest searchRequest)
        {
            SearchResult<Goods> searchResult = _searchService.GetData(searchRequest);

            return Result.Success().SetData(searchResult);
        }
    }
}
