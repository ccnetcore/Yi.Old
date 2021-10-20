using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Yi.Framework.Common.IOCOptions;
using Yi.Framework.Common.Models;
using Yi.Framework.Common.QueueModel;
using Yi.Framework.Core;
using Yi.Framework.Core.ConsulExtend;

namespace Yi.Framework.StaticPageProcessor
{
    public class InitPageWorker : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<InitPageWorker> _logger;
        private readonly RabbitMQInvoker _RabbitMQInvoker;
        private readonly AbstractConsulDispatcher _AbstractConsulDispatcher = null;

        public InitPageWorker(ILogger<InitPageWorker> logger, RabbitMQInvoker rabbitMQInvoker, IConfiguration configuration, AbstractConsulDispatcher abstractConsulDispatcher)
        {
            this._logger = logger;
            this._RabbitMQInvoker = rabbitMQInvoker;
            this._configuration = configuration;
            this._AbstractConsulDispatcher = abstractConsulDispatcher;
           
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            RabbitMQConsumerModel rabbitMQConsumerModel = new RabbitMQConsumerModel()
            {
                ExchangeName = RabbitMQExchangeQueueName.SKUCQRS_Exchange,
                QueueName = RabbitMQExchangeQueueName.SKUCQRS_Queue_StaticPage
            };
            HttpClient _HttpClient = new HttpClient();
            this._RabbitMQInvoker.RegistReciveAction(rabbitMQConsumerModel, message =>
            {
                SPUCQRSQueueModel skuCQRSQueueModel = JsonConvert.DeserializeObject<SPUCQRSQueueModel>(message);

                string detailUrl = this._AbstractConsulDispatcher.GetAddress(this._configuration["DetailPageUrl"]);
                string totalUrl = null;
                switch (skuCQRSQueueModel.CQRSType)
                {
                    case (int)SPUCQRSQueueModelType.Insert:
                        totalUrl = $"{detailUrl}{skuCQRSQueueModel.SpuId}.html";
                        break;
                    case (int)SPUCQRSQueueModelType.Update:
                        totalUrl = $"{detailUrl}{skuCQRSQueueModel.SpuId}.html";
                        break;
                    case (int)SPUCQRSQueueModelType.Delete:
                        totalUrl = $"{detailUrl}{skuCQRSQueueModel.SpuId}.html?ActionHeader=Delete";
                        break;
                    default:
                        break;
                }

                try
                {
                    var result = _HttpClient.GetAsync(totalUrl).Result;
                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        this._logger.LogInformation($"{nameof(WarmupPageWorker)}.Init succeed {totalUrl}");
                        return true;
                    }
                    else
                    {
                        this._logger.LogWarning($"{nameof(WarmupPageWorker)}.Init succeed {totalUrl}");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    var logModel = new LogModel()
                    {
                        OriginalClassName = this.GetType().FullName,
                        OriginalMethodName = nameof(ExecuteAsync),
                        Remark = "定时作业错误日志"
                    };
                    this._logger.LogError(ex, $"{nameof(WarmupPageWorker)}.Init failed {totalUrl}, Exception:{ex.Message}", JsonConvert.SerializeObject(logModel));
                    return false;
                }
            });
            await Task.CompletedTask;
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            //    await Task.Delay(1000, stoppingToken);
            //}
        }
    }
}
