using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Core;
using Yi.Framework.Core.Quartz;

namespace Yi.Framework.WebCore.MiddlewareExtend
{
    /// <summary>
    /// 启动定时器服务，后台服务
    /// </summary>
    public static class QuartzExtensions
    {
        /// <summary>
        /// 使用定时器
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddQuartzService(this IServiceCollection services)
        {
            services.AddSingleton<QuartzInvoker>();
            services.AddSingleton<IJobFactory, MyQuartzFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            return services;
        }
    }

}
