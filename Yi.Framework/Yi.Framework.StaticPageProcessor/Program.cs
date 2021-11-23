using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Core;
using Com.Ctrip.Framework.Apollo.Enums;
using Com.Ctrip.Framework.Apollo.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Yi.Framework.Common.IOCOptions;
using Yi.Framework.Core;
using Yi.Framework.Core.ConsulExtend;
using Yi.Framework.WebCore.BuilderExtend;

namespace Yi.Framework.StaticPageProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                            .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
                            {
                                configurationBuilder.AddCommandLine(args);
                                configurationBuilder.AddJsonFileService();
                                #region 
                                //Apollo配置
                                #endregion
                                configurationBuilder.AddApolloService("yi");
                            })
                            .ConfigureLogging(loggingBuilder =>
                            {
                                loggingBuilder.AddFilter("System", Microsoft.Extensions.Logging.LogLevel.Warning);
                                loggingBuilder.AddFilter("Microsoft", Microsoft.Extensions.Logging.LogLevel.Warning);
                                loggingBuilder.AddLog4Net();
                            })
                .ConfigureServices((hostContext, services) =>
                {

                    IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

                    services.AddHostedService<Worker>();
                    services.AddHostedService<InitPageWorker>();

                    #region 服务注入
                    //services.Configure<MySqlConnOptions>(configuration.GetSection("MysqlConn"));

                    services.AddTransient<CacheClientDB, CacheClientDB>();
                    services.Configure<RedisConnOptions>(configuration.GetSection("RedisConn"));

                    services.AddSingleton<RabbitMQInvoker>();
                    services.Configure<RabbitMQOptions>(configuration.GetSection("RabbitMQOptions"));
                    #endregion

                    #region Consul
                    services.Configure<ConsulClientOption>(configuration.GetSection("ConsulClientOption"));
                    services.AddTransient<AbstractConsulDispatcher, PollingDispatcher>();
                    #endregion

                    services.AddHostedService<WarmupPageWorker>();
                });
    }
    }
