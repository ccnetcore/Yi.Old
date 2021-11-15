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
using Yi.Framework.Common.Const;
using Yi.Framework.Common.IOCOptions;
using Yi.Framework.Common.Models;
using Yi.Framework.Common.QueueModel;
using Yi.Framework.Core;
using Yi.Framework.Core.ConsulExtend;

namespace Yi.Framework.StaticPageProcessor
{
    public class WarmupPageWorker : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<WarmupPageWorker> _logger;
        private readonly RabbitMQInvoker _RabbitMQInvoker;
        private readonly AbstractConsulDispatcher _IConsulDispatcher = null;

        public WarmupPageWorker(ILogger<WarmupPageWorker> logger, RabbitMQInvoker rabbitMQInvoker, IConfiguration configuration, AbstractConsulDispatcher consulDispatcher)
        {
            this._logger = logger;
            this._RabbitMQInvoker = rabbitMQInvoker;
            this._configuration = configuration;
            this._IConsulDispatcher = consulDispatcher;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            RabbitMQConsumerModel rabbitMQConsumerModel = new RabbitMQConsumerModel()
            {
                ExchangeName = RabbitConst.PageWarmup_Exchange,
                QueueName = RabbitConst.PageWarmup_Queue_Send
            };
            HttpClient _HttpClient = new HttpClient();
            this._RabbitMQInvoker.RegistReciveAction(rabbitMQConsumerModel, message =>
            {
              string realUrl=  this._IConsulDispatcher.GetAddress(this._configuration["DetailPageUrl"]);

                SKUWarmupQueueModel skuWarmupQueueModel = JsonConvert.DeserializeObject<SKUWarmupQueueModel>(message);
                #region 先ClearAll
                {
                    string totalUrl = $"{realUrl}{0}.html?ActionHeader=ClearAll";
                    try
                    {
                        var result = _HttpClient.GetAsync(totalUrl).Result;
                        if (result.StatusCode == HttpStatusCode.OK)
                        {
                            this._logger.LogInformation($"{nameof(WarmupPageWorker)}.ClearAll succeed {totalUrl}");
                            //return true;
                        }
                        else
                        {
                            this._logger.LogWarning($"{nameof(WarmupPageWorker)}.ClearAll failed {totalUrl}");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        this._logger.LogError($"{nameof(WarmupPageWorker)}.ClearAll failed {totalUrl}, Exception:{ex.Message}");
                        return false;
                    }
                }
                #endregion

                #region 然后全部创建  Warmup
                {
                    //限流？ 白名单----分批---记录当下等

                    int count = 100;//单次查询
                    int pageIndex = 1;//分页的页码七点
                    while (count == 100)
                    {


// -------------------> 此处生成静态页名称，通常使用id标识,可以通过调用service的查询方法得到所有id
                        List<long> ids = new List<long>{ 1,2,3,4,5,6,7,8,9};
// -------------------> 此处生成静态页名称，通常使用id标识,可以通过调用service的查询方法得到所有id


                        foreach (var id in ids)
                        {
                            string totalUrl = $"{realUrl}{id}.html";
                            try
                            {
                                var result = _HttpClient.GetAsync(totalUrl).Result;
                                if (result.StatusCode == HttpStatusCode.OK)
                                {
                                    this._logger.LogInformation($"{nameof(WarmupPageWorker)}.Warmup succeed {totalUrl}");
                                    //return true;
                                }
                                else
                                {
                                    this._logger.LogWarning($"{nameof(WarmupPageWorker)}.Warmup failed {totalUrl}");
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
                                this._logger.LogError(ex, $"{nameof(WarmupPageWorker)}.Warmup failed {totalUrl}, Exception:{ex.Message}", JsonConvert.SerializeObject(logModel));
                                return false;
                            }
                        }
                        pageIndex++;
                        count = ids.Count;
                    }
                }
                #endregion
                return true;
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
