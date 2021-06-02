using CC.Yi.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Yi.API.Extension
{
    public class ErrorHandExtension
    {
        private readonly RequestDelegate next;

        public ErrorHandExtension(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var statusCode = context.Response.StatusCode;
                if (ex is ArgumentException)
                {
                    statusCode = 200;
                }
                await HandleExceptionAsync(context, statusCode, ex.Message);
            }
            finally
            {
                var statusCode = context.Response.StatusCode;
                var msg = "";

                switch (statusCode) 
                {

                    case 401: msg = "未授权";break;
                    case 403: msg = "未授权"; break;
                    case 404: msg = "未找到服务"; break;
                    case 502: msg = "请求错误"; break;

                }
                if (!string.IsNullOrWhiteSpace(msg))
                {
                    await HandleExceptionAsync(context, statusCode, msg);
                }
            }
        }
        //异常错误信息捕获，将错误信息用Json方式返回
        private static  Task HandleExceptionAsync(HttpContext context, int statusCode, string msg)
        {
            var result = JsonConvert.SerializeObject( Result.Error(msg).SetCode(statusCode));
            context.Response.ContentType = "application/json;charset=utf-8";
            return  context.Response.WriteAsync(result);
        }
    }
    //扩展方法
    public static class ErrorHandlingExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandExtension>();
        }
    }
}