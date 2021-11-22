using DotNetCore.CAP.Dashboard.NodeDiscovery;
using DotNetCore.CAP.Messages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.WebCore.MiddlewareExtend
{
    public static class CAPExtend
    {
        public static IServiceCollection AddCAPService<T>(this IServiceCollection services)
        {
            if (Appsettings.appBool("CAP_Enabled"))
            {
                services.AddCap(x =>
                {
                    x.UseMySql(Appsettings.app("DbConn", "WriteUrl"));
 
                    x.UseRabbitMQ(optios => {
                        optios.HostName = Appsettings.app("RabbitConn", "HostName");
                        optios.Port =Convert.ToInt32(Appsettings.app("RabbitConn", "Port"));
                        optios.UserName = Appsettings.app("RabbitConn", "UserName");
                        optios.Password = Appsettings.app("RabbitConn", "Password");

                    });
                    x.FailedRetryCount = 30;
                    x.FailedRetryInterval = 60;//second
                    x.FailedThresholdCallback = failed =>
                    {
                        var logger = failed.ServiceProvider.GetService<ILogger<T>>();
                        logger.LogError($@"MessageType {failed.MessageType} 失败了， 重试了 {x.FailedRetryCount} 次, 
                        消息名称: {failed.Message.GetName()}");//do anything
                    };
                    if (Appsettings.appBool("CAPDashboard_Enabled"))
                    {
                        x.UseDashboard();
                        var discoveryOptions = Appsettings.app<DiscoveryOptions>();
                        x.UseDiscovery(d =>
                        {
                            d.DiscoveryServerHostName = discoveryOptions.DiscoveryServerHostName;
                            d.DiscoveryServerPort = discoveryOptions.DiscoveryServerPort;
                            d.CurrentNodeHostName = discoveryOptions.CurrentNodeHostName;
                            d.CurrentNodePort = discoveryOptions.CurrentNodePort;
                            d.NodeId = discoveryOptions.NodeId;
                            d.NodeName = discoveryOptions.NodeName;
                            d.MatchPath = discoveryOptions.MatchPath;
                        });
                    }
                });

            }
            return services;
        }
    }
}
