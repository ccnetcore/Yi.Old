using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.ElectronicCommerce.Core.ConsulExtend
{
    /// <summary>
    /// HTTP模式
    /// </summary>
    public static class ConsulRegiterExtend
    {
        /// <summary>
        /// 自动读取配置文件完成注册
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static async Task UseConsulConfiguration(this IApplicationBuilder app, IConfiguration configuration)
        {
            ConsulRegisterOption consulRegisterOption = new ConsulRegisterOption();
            configuration.Bind("ConsulRegisterOption", consulRegisterOption);

            ConsulClientOption consulClientOption = new ConsulClientOption();
            configuration.Bind("ConsulClientOption", consulClientOption);

            await UseConsul(app, consulClientOption, consulRegisterOption);
        }
        /// <summary>
        /// 基于提供信息完成注册
        /// </summary>
        /// <param name="app"></param>
        /// <param name="healthService"></param>
        /// <returns></returns>
        public static async Task UseConsul(this IApplicationBuilder app, ConsulClientOption consulClientOption, ConsulRegisterOption consulRegisterOption)
        {
            using (ConsulClient client = new ConsulClient(c =>
             {
                 c.Address = new Uri($"http://{consulClientOption.IP}:{consulClientOption.Port}/");
                 c.Datacenter = consulClientOption.Datacenter;
             }))
            {
                await client.Agent.ServiceRegister(new AgentServiceRegistration()
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
                });
                Console.WriteLine($"{JsonConvert.SerializeObject(consulRegisterOption)} 完成注册");
            }
        }


    }
}
