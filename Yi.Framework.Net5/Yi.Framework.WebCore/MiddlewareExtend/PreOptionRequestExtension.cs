using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.WebCore.MiddlewareExtend
{
    /// <summary>
    /// 预检请求扩展
    /// </summary>
    public class PreOptionRequestExtension
    {
        private readonly RequestDelegate _next;

        public PreOptionRequestExtension(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method.ToUpper() == "OPTIONS")
            {
                //context.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:8070");
                //context.Response.Headers.Add("Access-Control-Allow-Methods", "GET,PUT,POST,DELETE,PATCH,OPTIONS");
                //context.Response.Headers.Add("Access-Control-Allow-Headers", "*");
                context.Response.StatusCode = 200;
                return;
            }
            await _next.Invoke(context);
        }
    }

    /// <summary>
    /// 扩展中间件
    /// </summary>
    public static class PreOptionsRequestMiddlewareExtensions
    {
        public static IApplicationBuilder UsePreOptionsRequest(this IApplicationBuilder app)
        {
            return app.UseMiddleware<PreOptionRequestExtension>();
        }
    }

}
