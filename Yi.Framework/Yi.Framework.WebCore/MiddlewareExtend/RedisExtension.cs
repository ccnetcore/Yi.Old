using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using Yi.Framework.Common.IOCOptions;

namespace Yi.Framework.WebCore.MiddlewareExtend
{
    /// <summary>
    /// Redis扩展
    /// </summary>
    public static class RedisExtension
    {
        public static IServiceCollection AddRedisService(this IServiceCollection services)
        {
            Appsettings.app<RedisConnOptions>("RedisConn");
            return services;
        }
    }
}
