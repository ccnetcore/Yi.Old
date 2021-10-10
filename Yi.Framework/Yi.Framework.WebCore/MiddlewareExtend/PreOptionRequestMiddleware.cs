using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CC.ElectronicCommerce.WebCore.MiddlewareExtend
{
    /// <summary>
    /// Axios会触发，需要做个状态返回，还需要指定跨域信息，这里放在网关了
    /// 
    /// OPTIONS请求即预检请求，可用于检测服务器允许的http方法。当发起跨域请求时，由于安全原因，触发一定条件时浏览器会在正式请求之前自动先发起OPTIONS请求，即CORS预检请求，服务器若接受该跨域请求，浏览器才继续发起正式请求。
    /// </summary>
    public class PreOptionRequestMiddleware
    {
        private readonly RequestDelegate _next;

        public PreOptionRequestMiddleware(RequestDelegate next)
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
            return app.UseMiddleware<PreOptionRequestMiddleware>();
        }
    }

}
