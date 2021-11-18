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
using Yi.Framework.WebCore;
using Yi.Framework.WebCore.BuilderExtend;
using Yi.Framework.WebCore.MiddlewareExtend;

namespace Yi.Framework.SMSProcessor
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
                                //configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
                                //configurationBuilder.AddJsonFile("configuration.json", optional: false, reloadOnChange: true);
                                configurationBuilder.AddJsonFileService();
                                #region 
                                //Apollo配置
                                #endregion
                                configurationBuilder.AddApolloService("Yi");
                                #region 
                                //Apollo配置
                                #endregion
                                //configurationBuilder.AddApolloService("Yi");
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

                    #region
                    //Ioc配置
                    #endregion
                    services.AddSingleton(new Appsettings(configuration));
                    services.AddHostedService<Worker>();
                    services.AddHostedService<SendWorker>();

                    #region 服务注入
                    //services.Configure<MySqlConnOptions>(configuration.GetSection("MysqlConn"));


                    #region
                    //RabbitMQ服务配置
                    #endregion
                    services.AddRabbitMQService();
                    #endregion

                    #region
                    //短信服务配置
                    #endregion
                    services.AddSMSService();

                    #region Consul
                    //services.Configure<ConsulClientOption>(configuration.GetSection("ConsulClientOption"));
                    //services.AddTransient<AbstractConsulDispatcher, PollingDispatcher>();
                    #endregion

                });
    }
    }
