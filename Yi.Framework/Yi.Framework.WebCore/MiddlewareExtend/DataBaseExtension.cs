using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using Yi.Framework.Common.IOCOptions;

namespace Yi.Framework.WebCore.MiddlewareExtend
{
    /// <summary>
    /// 数据库扩展
    /// </summary>
    public static class DataBaseExtension
    {
        public static IServiceCollection AddDataBaseService<IocOptios>(this IServiceCollection services , string appsettings)
        {
            Appsettings.app<IocOptios>(appsettings);
            return services;
        }

        public static void UseDataBaseService(this IApplicationBuilder app)
        {
      
        }

    }
}
