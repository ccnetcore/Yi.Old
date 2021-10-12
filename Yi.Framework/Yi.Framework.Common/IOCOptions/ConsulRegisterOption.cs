using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Common.IOCOptions
{
    public class ConsulRegisterOption
    {
        /// <summary>
        /// 服务自身IP
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 服务自身Port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 组名称
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 心跳检查地址
        /// </summary>
        public string HealthCheckUrl { get; set; }
        /// <summary>
        /// 心跳频率
        /// </summary>
        public int Interval { get; set; }
        /// <summary>
        /// 心跳超时
        /// </summary>
        public int Timeout { get; set; }
        /// <summary>
        /// 移除延迟时间
        /// </summary>
        public int DeregisterCriticalServiceAfter { get; set; }
        /// <summary>
        /// 标签，额外信息，用于权重
        /// </summary>
        public string Tag { get; set; }
    }
}
