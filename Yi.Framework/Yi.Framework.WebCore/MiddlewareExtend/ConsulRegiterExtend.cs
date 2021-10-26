using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Common.IOCOptions;

namespace Yi.Framework.WebCore.MiddlewareExtend
{
    /// <summary>
    /// HTTP模式
    /// </summary>
    public static class ConsulRegiterExtend
    {
        /// <summary>
        /// 基于提供信息完成注册
        /// </summary>
        /// <param name="app"></param>
        /// <param name="healthService"></param>
        /// <returns></returns>
        public static void UseConsulService(this IApplicationBuilder app)
        {

            if (Appsettings.appBool("Consul_Enabled"))
            {
                var consulRegisterOption = Appsettings.app<ConsulRegisterOption>("ConsulRegisterOption");

                var consulClientOption = Appsettings.app<ConsulClientOption>("ConsulRegisterOption");
                using (ConsulClient client = new ConsulClient(c =>
                 {
                     c.Address = new Uri($"http://{consulClientOption.IP}:{consulClientOption.Port}/");
                     c.Datacenter = consulClientOption.Datacenter;
                 }))
                {
                    client.Agent.ServiceRegister(new AgentServiceRegistration()
                    {
                        ID = $"{consulRegisterOption.IP}-{consulRegisterOption.Port}-{Guid.NewGuid()}",//唯一Id
                        Name = consulRegisterOption.GroupName,//组名称-Group
                        Address = consulRegisterOption.IP,
                        Port = consulRegisterOption.Port,
                        Tags = new string[] { consulRegisterOption.Tag },
                        Check = new AgentServiceCheck()
                        {
                            Interval = TimeSpan.FromSeconds(consulRegisterOption.Interval),
                            HTTP = $"http://{consulRegisterOption.IP}:{consulRegisterOption.Port}{consulRegisterOption.HealthCheckUrl}",
                            Timeout = TimeSpan.FromSeconds(consulRegisterOption.Timeout),
                            DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(consulRegisterOption.DeregisterCriticalServiceAfter)
                        }
                    }).Wait();
                    Console.WriteLine($"{JsonConvert.SerializeObject(consulRegisterOption)} 完成注册");
                }
            }
        }

    }
}
