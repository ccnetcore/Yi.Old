using System;
using System.Collections.Generic;
using System.Text;

namespace Yi.Framework.Common.IOCOptions
{
    /// <summary>
    /// 使用Consul时需要配置
    /// </summary>
    public class ConsulClientOption
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public string Datacenter { get; set; }
    }
}
