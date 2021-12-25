using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consul;
using Microsoft.Extensions.Options;
using Yi.Framework.Common.IOCOptions;

namespace Yi.Framework.Core.ConsulExtend
{
    /// <summary>
    /// 轮询
    /// </summary>
    public class PollingDispatcher : AbstractConsulDispatcher
    {
        #region Identity
        private static int _iTotalCount = 0;
        private static int iTotalCount
        {
            get
            {
                return _iTotalCount;
            }
            set
            {
                _iTotalCount = value >= Int32.MaxValue ? 0 : value;
            }
        }

        public PollingDispatcher(IOptionsMonitor<ConsulClientOption> consulClientOption) : base(consulClientOption)
        {
        }
        #endregion

        /// <summary>
        /// 轮询
        /// </summary>
        /// <param name="serviceCount"></param>
        /// <returns></returns>
        protected override int GetIndex()
        {
            return iTotalCount++ % base._CurrentAgentServiceDictionary.Length;
        }
    }
}
