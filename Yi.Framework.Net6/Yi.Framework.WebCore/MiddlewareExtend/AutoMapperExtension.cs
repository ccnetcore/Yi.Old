using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Yi.Framework.WebCore.MiddlewareExtend
{
    /// <summary>
    /// 通用autoMapper扩展
    /// </summary>
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapperExtensionService(this IServiceCollection services,Type type)
        {
            services.AddAutoMapper(type);
            return services;
        }
    }
}
