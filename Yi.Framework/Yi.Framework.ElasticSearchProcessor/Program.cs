
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Yi.Framework.WebCore;
using Yi.Framework.WebCore.BuilderExtend;
using Yi.Framework.WebCore.MiddlewareExtend;

namespace Yi.Framework.ElasticSearchProcessor
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
                              //configurationBuilder.AddJsonFile("configuration.json", optional: false, reloadOnChange: true);
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
                  services.AddHostedService<InitESIndexWorker>();
                  services.AddHostedService<WarmupESIndexWorker>();
                  #region 服务注入
                  //services.Configure<MySqlConnOptions>(configuration.GetSection("MysqlConn"));


                  #region
                  //RabbitMQ服务配置
                  #endregion
                  services.AddRabbitMQService();
                    #endregion

                    #region Consul
                    //services.Configure<ConsulClientOption>(configuration.GetSection("ConsulClientOption"));
                    //services.AddTransient<AbstractConsulDispatcher, PollingDispatcher>();
                    #endregion

                });
    }
}
