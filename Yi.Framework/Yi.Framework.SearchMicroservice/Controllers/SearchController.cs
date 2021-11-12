using Microsoft.AspNetCore.Mvc;
using Yi.Framework.Common.Const;
using Yi.Framework.Common.Models;
using Yi.Framework.Core;
using Yi.Framework.Interface;
using Yi.Framework.Model.Search;

namespace Yi.Framework.SearchMicroservice.Controllers
{
    [ApiController]
    public class SearchController : ControllerBase
    {
        private ISearchService _searchService;
        private RabbitMQInvoker _rabbitMQInvoker;
        public SearchController(ISearchService searchService,RabbitMQInvoker rabbitMQInvoker)
        {
            _searchService = searchService;
            _rabbitMQInvoker = rabbitMQInvoker;
        }
        [Route("page")]
        [HttpPost]
        public Result Search(SearchRequest searchRequest)
        {
            SearchResult<Goods> searchResult = _searchService.GetData(searchRequest);

            return Result.Success().SetData(searchResult);
        }

        //测试用
        [Route("InitEs")]
        [HttpGet]
        public Result InitEs()
        {
            _rabbitMQInvoker.Send(new Common.IOCOptions.RabbitMQConsumerModel()
            {
                ExchangeName = RabbitConst.GoodsWarmup_Exchange,
                QueueName = RabbitConst.GoodsWarmup_Queue_Send
            },"true") ;
            return Result.Success();
        }
    }
}
