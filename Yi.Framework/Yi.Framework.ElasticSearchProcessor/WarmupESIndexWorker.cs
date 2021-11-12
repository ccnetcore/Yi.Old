using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Yi.Framework.Common.Const;
using Yi.Framework.Common.IOCOptions;
using Yi.Framework.Common.Models;
using Yi.Framework.Common.QueueModel;
using Yi.Framework.Core;
using Yi.Framework.Interface;

namespace Yi.Framework.ElasticSearchProcessor
{
    public class WarmupESIndexWorker : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<WarmupESIndexWorker> _logger;
        private readonly RabbitMQInvoker _RabbitMQInvoker;
        private readonly ElasticSearchInvoker _elasticSearchInvoker;
        private readonly IOptionsMonitor<ElasticSearchOptions> _ElasticSearchOptions = null;

        private readonly ISearchService _searchService;
        public WarmupESIndexWorker(ILogger<WarmupESIndexWorker> logger, RabbitMQInvoker rabbitMQInvoker, IConfiguration configuration, ElasticSearchInvoker elasticSearchInvoker, IOptionsMonitor<ElasticSearchOptions> optionsMonitor, ISearchService searchService)
        {
            this._logger = logger;
            this._RabbitMQInvoker = rabbitMQInvoker;
            this._configuration = configuration;
            this._elasticSearchInvoker = elasticSearchInvoker;
            this._ElasticSearchOptions = optionsMonitor;
            this._searchService=searchService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            RabbitMQConsumerModel rabbitMQConsumerModel = new RabbitMQConsumerModel()
            {
                ExchangeName = RabbitConst.GoodsWarmup_Exchange,
                QueueName = RabbitConst.GoodsWarmup_Queue_Send
            };
            HttpClient _HttpClient = new HttpClient();
            this._RabbitMQInvoker.RegistReciveAction(rabbitMQConsumerModel, message =>
            {
                SKUWarmupQueueModel skuWarmupQueueModel = JsonConvert.DeserializeObject<SKUWarmupQueueModel>(message);
                //【得到消息队列模型】
                #region 先删除Index---新建Index---再建立全部数据索引
                {
                    try
                    {
                        this._elasticSearchInvoker.DropIndex(this._ElasticSearchOptions.CurrentValue.IndexName);
                        this._searchService.ImpDataBySpu();
                        //【触发es数据导入服务】
                        this._logger.LogInformation($"{nameof(WarmupESIndexWorker)}.InitAll succeed");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        var logModel = new LogModel()
                        {
                            OriginalClassName = this.GetType().FullName,
                            OriginalMethodName = nameof(ExecuteAsync),
                            Remark = "定时作业错误日志"
                        };
                        this._logger.LogError(ex, $"{nameof(WarmupESIndexWorker)}.Warmup ESIndex failed message={message}, Exception:{ex.Message}", JsonConvert.SerializeObject(logModel));
                        return false;
                    }
                }
                #endregion
            });
            await Task.CompletedTask;
        }
    }
}
