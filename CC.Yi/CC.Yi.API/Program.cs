using Autofac.Extensions.DependencyInjection;
using CC.Yi.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Yi.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //添加一个数据库，并修改连接数据库的配置文件
            //添加模型类，在模型层中，使用Add-Migration xxx迁移，再使用Update-Database更新数据库
            //向T4Model添加模型名，一键转换生成T4
            //控制器构造函数进行依赖注入直接使用

            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("正在启动Yi意框架。。。。。。");
                var host = CreateHostBuilder(args).Build();
                host.Run();
                logger.Info("Yi意框架启动成功！");
            }
            catch (Exception exception)
            {
                //NLog: catch setup errors
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.UseUrls("http://*:19000").UseStartup<Startup>();
                }).UseServiceProviderFactory(new AutofacServiceProviderFactory())
                 .ConfigureLogging(logging =>
                 {
                     // logging.ClearProviders(); // 这个方法会清空所有控制台的输出
                     logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                 }).UseNLog();//开启nlog日志输出

    }
}
