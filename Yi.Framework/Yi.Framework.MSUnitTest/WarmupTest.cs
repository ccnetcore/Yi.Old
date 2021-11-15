using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Yi.Framework.Common.Const;
using Yi.Framework.Common.QueueModel;
using Yi.Framework.Core;

namespace Yi.Framework.MSUnitTest
{
    [TestClass]
    public class WarmupTest
    {
        private ServiceProvider _ServiceProvider = null;

        [TestInitialize]
        public void Init()
        {
            Console.WriteLine("This is DataTest Init");
            IServiceCollection services = new ServiceCollection();
            this._ServiceProvider = services.BuildServiceProvider();
        }

        [TestMethod]
        public void mytest()
        {
            Console.WriteLine("成功运行程序！");
        }
        [TestMethod]
        public void mytest2()
        {
            Console.WriteLine("成功运行程序！");
        }

        [TestMethod]
        public void WarmupEs()
        {
            RabbitMQInvoker rabbitMQInvoker = new RabbitMQInvoker("118.195.191.41");
            rabbitMQInvoker.Send(new Common.IOCOptions.RabbitMQConsumerModel()
            {
                ExchangeName = RabbitConst.GoodsWarmup_Exchange,
                QueueName = RabbitConst.GoodsWarmup_Queue_Send
            }, Common.Helper.JsonHelper.ObjToStr(new SKUWarmupQueueModel() { Warmup = true }));
        }

        [TestMethod]
        public void WarmupPage()
        {
            RabbitMQInvoker rabbitMQInvoker = new RabbitMQInvoker("118.195.191.41");
            rabbitMQInvoker.Send(new Common.IOCOptions.RabbitMQConsumerModel()
            {
                ExchangeName = RabbitConst.PageWarmup_Exchange,
                QueueName = RabbitConst.PageWarmup_Queue_Send
            }, Common.Helper.JsonHelper.ObjToStr(new SKUWarmupQueueModel() { Warmup = true }));
        }

    }
}
