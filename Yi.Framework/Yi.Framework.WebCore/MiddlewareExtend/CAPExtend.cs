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
            if (Appsettings.appBool("Cors_Enabled"))
            {
                services.AddCap(x =>
                {
                    x.UseMySql(Appsettings.app(""));
                    x.UseRabbitMQ(Appsettings.app(""));
                    x.FailedRetryCount = 30;
                    x.FailedRetryInterval = 60;//second
                    x.FailedThresholdCallback = failed =>
                    {
                        var logger = failed.ServiceProvider.GetService<ILogger<T>>();
                        logger.LogError($@"MessageType {failed.MessageType} 失败了， 重试了 {x.FailedRetryCount} 次, 
                        消息名称: {failed.Message.GetName()}");//do anything
                    };

                    x.UseDashboard();
                    var discoveryOptions=Appsettings.app<DiscoveryOptions>();
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

                });

            }
            return services;
        }
    }
}
