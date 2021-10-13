using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Yi.Framework.Common.IOCOptions;

namespace Yi.Framework.WebCore.MiddlewareExtend
{
    /// <summary>
    /// 数据库扩展
    /// </summary>
    public static class SqliteExtension
    {
        public static IServiceCollection AddSqliteService(this IServiceCollection services)
        {
            services.Configure<SqliteOptions>(Appsettings.appConfiguration("SqliteConn"));
            return services;
        }
    }
}
