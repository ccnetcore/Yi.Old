using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yi.Framework.WebCore.FilterExtend
{
    /// <summary>
    /// 跨域过滤器
    /// </summary>
    public class CORSFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            context.HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST, GET, OPTIONS, DELETE,PUT");
            context.HttpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
        }
    }
}
