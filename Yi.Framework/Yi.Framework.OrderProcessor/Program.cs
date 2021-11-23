using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Yi.Framework.WebCore;
using Yi.Framework.WebCore.BuilderExtend;
using Yi.Framework.WebCore.MiddlewareExtend;
using Microsoft.Extensions.Logging;
using Yi.Framework.Interface;
using Yi.Framework.Service;

namespace Yi.Framework.OrderProcessor
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

                    #region
                    //Ioc配置
                    #endregion
                    services.AddIocService(configuration);
                    services.AddSingleton(new Appsettings(configuration));
                    services.AddHostedService<Worker>();
                    services.AddHostedService<CancelOrderWorker>();
                    services.AddRabbitMQService();
                    services.AddRedisService();
                    services.AddCAPService<Program>();
                    services.AddTransient<IOrderService, OrderService>();
                    services.AddDbService();

                });
    }
}
