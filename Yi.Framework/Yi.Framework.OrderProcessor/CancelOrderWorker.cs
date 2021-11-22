using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
using Yi.Framework.DTOModel;
using Yi.Framework.Interface;
using Yi.Framework.Common.Helper;
namespace Yi.Framework.OrderProcessor
{
    public class CancelOrderWorker : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CancelOrderWorker> _logger;
        private readonly RabbitMQInvoker _RabbitMQInvoker;
        private readonly IOrderService _IOrderService = null;
        private readonly CacheClientDB _cacheClientDB;

        public CancelOrderWorker(ILogger<CancelOrderWorker> logger, RabbitMQInvoker rabbitMQInvoker, IConfiguration configuration, IOrderService orderService, CacheClientDB cacheClientDB)
        {
            this._logger = logger;
            this._RabbitMQInvoker = rabbitMQInvoker;
            this._configuration = configuration;
            this._IOrderService = orderService;
            this._cacheClientDB = cacheClientDB;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            RabbitMQConsumerModel rabbitMQConsumerModel = new RabbitMQConsumerModel()
            {
                ExchangeName = RabbitConst.OrderCreate_Delay_Exchange,
                QueueName = RabbitConst.OrderCreate_Delay_Queue
            };
            this._RabbitMQInvoker.RegistReciveAction(rabbitMQConsumerModel,  message =>
            {
                try
                {

                    OrderCartDto orderCreateQueueModel = JsonHelper.StrToObj<OrderCartDto>(message);
                    bool bResult = _IOrderService.CloseOrder(Convert.ToInt32(orderCreateQueueModel.OrderId)).Result;
                    string key = $"{RedisConst.keyOrden}:{orderCreateQueueModel.Carts.skuId}";
                this._cacheClientDB.IncrementValueBy(key, orderCreateQueueModel.Carts.num);
                    return true;
                }
                catch (Exception ex)
                {
                    LogModel logModel = new LogModel()
                    {
                        OriginalClassName = this.GetType().FullName,
                        OriginalMethodName = nameof(ExecuteAsync),
                        Remark = "定时作业错误日志"
                    };
                    this._logger.LogError(ex, $"{nameof(CancelOrderWorker)}.CancelOrder failed message={message}, Exception:{ex.Message}",JsonHelper.ObjToStr(logModel));
                    return false;
                }
            });
            await Task.CompletedTask;
        }
    }
}
