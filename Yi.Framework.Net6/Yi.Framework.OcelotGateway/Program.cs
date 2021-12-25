using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yi.Framework.OcelotGateway
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
                    configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
                    configurationBuilder.AddJsonFile("configuration.json", optional: false, reloadOnChange: true);
                    #region 
                    //ApolloÅäÖÃ
                    #endregion
                    //configurationBuilder.AddApolloService("Yi");
                })
                .ConfigureLogging(loggingBuilder =>
                {
                    loggingBuilder.AddFilter("System", Microsoft.Extensions.Logging.LogLevel.Warning);
                    loggingBuilder.AddFilter("Microsoft", Microsoft.Extensions.Logging.LogLevel.Warning);
                    loggingBuilder.AddLog4Net();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseUrls("http://*:7200");
                });
    }
}
