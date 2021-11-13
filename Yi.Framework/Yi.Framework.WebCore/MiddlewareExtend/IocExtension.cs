using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Yi.Framework.Model;
using Yi.Framework.Model.ModelFactory;

namespace Yi.Framework.WebCore.MiddlewareExtend
{
    /// <summary>
    /// 通用跨域扩展
    /// </summary>
    public static class IocExtension
    {
        public static IServiceCollection AddIocService(this IServiceCollection services, IConfiguration configuration)
        {
            #region
            //配置文件使用配置
            #endregion
            services.AddSingleton(new Appsettings(configuration));
            #region
            //数据库配置
            #endregion
            services.AddTransient<DbContext, DataContext>();
            #region
            //数据库工厂配置
            #endregion
            services.AddTransient<IDbContextFactory, DbContextFactory>();
            return services;
        }

    }
}
