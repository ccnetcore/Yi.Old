using CC.ElectronicCommerce.Common.IOCOptions;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.ElectronicCommerce.Core
{
    /// <summary>
    /// 一个Exchange----多个Queue-----弄个缓存映射关系，初始化+支持全新绑定
    /// 全局单例使用
    /// 
    /// 关系应该是直接配置到RabbitMQ了---程序只是向某个位置写入即可
    /// 
    /// 
    /// 全量更新--耗时---阻塞实时更新---换不同的exchange？
    /// </summary>
    public class RabbitMQInvoker
    {
        #region Identity
        private readonly RabbitMQOptions _rabbitMQOptions;
        private readonly string _HostName = null;
        private readonly string _UserName = null;
        private readonly string _Password = null;
        public RabbitMQInvoker(IOptionsMonitor<RabbitMQOptions> optionsMonitor) : this(optionsMonitor.CurrentValue.HostName, optionsMonitor.CurrentValue.UserName, optionsMonitor.CurrentValue.Password)
        {
            this._rabbitMQOptions = optionsMonitor.CurrentValue;
        }

        public RabbitMQInvoker(string hostName, string userName = "cc", string password = "cc")
        {
            this._HostName = hostName;
            this._UserName = userName;
            this._Password = password;
        }
        #endregion

        #region Init
        private static object RabbitMQInvoker_BindQueueLock = new object();
        private static Dictionary<string, bool> RabbitMQInvoker_ExchangeQueue = new Dictionary<string, bool>();
        private void InitBindQueue(RabbitMQConsumerModel rabbitMQConsumerModel)
        {
            if (!RabbitMQInvoker_ExchangeQueue.ContainsKey($"InitBindQueue_{rabbitMQConsumerModel.ExchangeName}_{rabbitMQConsumerModel.QueueName}"))
            {
                lock (RabbitMQInvoker_BindQueueLock)
                {
                    if (!RabbitMQInvoker_ExchangeQueue.ContainsKey($"InitBindQueue_{rabbitMQConsumerModel.ExchangeName}_{rabbitMQConsumerModel.QueueName}"))
                    {
                        this.InitConnection();
                        using (IModel channel = _CurrentConnection.CreateModel())
                        {
                            channel.ExchangeDeclare(exchange: rabbitMQConsumerModel.ExchangeName, type: ExchangeType.Fanout, durable: true, autoDelete: false, arguments: null);
                            channel.QueueDeclare(queue: rabbitMQConsumerModel.QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                            channel.QueueBind(queue: rabbitMQConsumerModel.QueueName, exchange: rabbitMQConsumerModel.ExchangeName, routingKey: string.Empty, arguments: null);
                        }
                        RabbitMQInvoker_ExchangeQueue[$"InitBindQueue_{rabbitMQConsumerModel.ExchangeName}_{rabbitMQConsumerModel.QueueName}"] = true;
                    }
                }
            }
        }
        /// <summary>
        /// 必须先声明exchange--检查+初始化
        /// </summary>
        /// <param name="rabbitMQConsumerModel"></param>
        private void InitExchange(string exchangeName)
        {
            if (!RabbitMQInvoker_ExchangeQueue.ContainsKey($"InitExchange_{exchangeName}"))//没用api确认
            {
                lock (RabbitMQInvoker_BindQueueLock)
                {
                    if (!RabbitMQInvoker_ExchangeQueue.ContainsKey($"InitExchange_{exchangeName}"))
                    {
                        this.InitConnection();
                        using (IModel channel = _CurrentConnection.CreateModel())
                        {
                            channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Fanout, durable: true, autoDelete: false, arguments: null);
                        }
                        RabbitMQInvoker_ExchangeQueue[$"InitExchange_{exchangeName}"] = true;
                    }
                }
            }
        }
        //public void UnBindQueue(string exchangeName, string queueName)
        //{
        //}

        private static object RabbitMQInvoker_InitLock = new object();
        private static IConnection _CurrentConnection = null;//链接做成单例重用--channel是新的
        private void InitConnection()
        {
            //https://blog.csdn.net/weixin_30646315/article/details/99101279
            if (_CurrentConnection == null || !_CurrentConnection.IsOpen)
            {
                lock (RabbitMQInvoker_InitLock)
                {
                    if (_CurrentConnection == null || !_CurrentConnection.IsOpen)
                    {
                        var factory = new ConnectionFactory()
                        {
                            HostName = this._HostName,
                            Password = this._Password,
                            UserName = this._UserName
                        };
                        _CurrentConnection = factory.CreateConnection();
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 只管exchange---
        /// 4种路由类型？
        /// 
        /// Send前完成交换机初始化
        /// </summary>
        /// <param name="exchangeName"></param>
        /// <param name="message">建议Json格式</param>
        public void Send(RabbitMQConsumerModel rabbitMQConsumerModel, string message)
        {
            this.InitExchange(rabbitMQConsumerModel.ExchangeName);
            this.InitBindQueue(rabbitMQConsumerModel);
            if (_CurrentConnection == null || !_CurrentConnection.IsOpen)
            {
                this.InitConnection();
            }
            using (var channel = _CurrentConnection.CreateModel())//开辟新的信道通信
            {
                try
                {
                    channel.TxSelect();//开启Tx事务---RabbitMQ协议级的事务-----强事务

                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: rabbitMQConsumerModel.ExchangeName,
                                         routingKey: string.Empty,
                                         basicProperties: null,
                                         body: body);
                    channel.TxCommit();//提交
                    Console.WriteLine($" [x] Sent {body.Length}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"【{message}】发送到Broker失败！{ex.Message}");
                    channel.TxRollback(); //事务回滚--前面的所有操作就全部作废了。。。。
                }
            }
        }

        /// <summary>
        /// 固定无消费队列名字---转移到目标队列---定好时间
        /// </summary>
        /// <param name="targetExchangeName"></param>
        /// <param name="message"></param>
        /// <param name="delaySecond"></param>
        public void SendDelay(string targetExchangeName, string message, int delaySecond)
        {
            this.InitExchange(targetExchangeName);

            if (_CurrentConnection == null || !_CurrentConnection.IsOpen)
            {
                this.InitConnection();
            }
            using (var channel = _CurrentConnection.CreateModel())//开辟新的信道通信
            {
                try
                {
                    string delayExchangeName = "ZhaoxiMSA_DelayExchange";

                    //普通交换器
                    channel.ExchangeDeclare(delayExchangeName, "fanout", true, false, null);
                    //参数设置
                    Dictionary<string, object> args = new Dictionary<string, object>();
                    args.Add("x-message-ttl", delaySecond * 1000);//TTL 毫秒
                    args.Add("x-dead-letter-exchange", targetExchangeName);//DLX
                    args.Add("x-dead-letter-routing-key", "routingkey");//routingKey
                    channel.QueueDeclare("ZhaoxiMSA_DelayQueue", true, false, false, args);
                    channel.QueueBind(queue: "ZhaoxiMSA_DelayQueue",
                        exchange: delayExchangeName,
                        routingKey: string.Empty,
                        arguments: null);

                    ////DLX--- //死信队列绑定
                    //channel.ExchangeDeclare("ZhaoxiMSA_exchange_dlx", "fanout", true, false, null);
                    //channel.QueueDeclare("ZhaoxiMSA_queue_dlx", true, false, false, null);
                    //channel.QueueBind("ZhaoxiMSA_queue_dlx", "ZhaoxiMSA_exchange_dlx", "routingkey", null);


                    channel.TxSelect();//开启Tx事务---RabbitMQ协议级的事务-----强事务
                    var properties = channel.CreateBasicProperties();

                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: delayExchangeName,
                                         routingKey: string.Empty,
                                         basicProperties: properties,
                                         body: body);
                    channel.TxCommit();//提交
                    Console.WriteLine($" [x] Sent {body.Length}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"【{message}】发送到Broker失败！{ex.Message}");
                    channel.TxRollback(); //事务回滚--前面的所有操作就全部作废了。。。。
                }
            }
        }

        #region Receive
        /// <summary>
        /// 注册处理动作
        /// </summary>
        /// <param name="rabbitMQConsumerMode"></param>
        /// <param name="func"></param>
        public void RegistReciveAction(RabbitMQConsumerModel rabbitMQConsumerMode, Func<string, bool> func)
        {
            this.InitBindQueue(rabbitMQConsumerMode);

            Task.Run(() =>
            {
                using (var channel = _CurrentConnection.CreateModel())
                {
                    var consumer = new EventingBasicConsumer(channel);
                    channel.BasicQos(0, 0, true);
                    consumer.Received += (sender, ea) =>
                    {
                        string str = Encoding.UTF8.GetString(ea.Body.ToArray());
                        if (func(str))
                        {
                            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);//确认已消费
                        }
                        else
                        {
                            //channel.BasicReject(deliveryTag: ea.DeliveryTag, requeue: true);//放回队列--重新包装信息，放入其他队列
                        }
                    };
                    channel.BasicConsume(queue: rabbitMQConsumerMode.QueueName,
                                         autoAck: false,//不ACK
                                         consumer: consumer);
                    Console.WriteLine($" Register Consumer To {rabbitMQConsumerMode.ExchangeName}-{rabbitMQConsumerMode.QueueName}");
                    Console.ReadLine();
                    Console.WriteLine($" After Register Consumer To {rabbitMQConsumerMode.ExchangeName}-{rabbitMQConsumerMode.QueueName}");
                }
            });
        }
        #endregion

    }
}
