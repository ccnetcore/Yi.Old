using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using Yi.Framework.Common.IOCOptions;
using Yi.Framework.Core;

namespace Yi.Framework.WebCore.MiddlewareExtend
{
    /// <summary>
    /// Redis扩展
    /// </summary>
    public static class RedisExtension
    {
        public static IServiceCollection AddRedisService(this IServiceCollection services)
        {
            if (Appsettings.appBool("Redis_Enabled"))
            {
                services.Configure<RedisConnOptions>(Appsettings.appConfiguration("RedisConn"));
                services.AddTransient<CacheClientDB>();
            }
            return services;
        }
    }
}
