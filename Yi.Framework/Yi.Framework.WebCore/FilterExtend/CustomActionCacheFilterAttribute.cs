using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yi.Framework.WebCore.FilterExtend
{
    /// <summary>
    /// 缓存过滤器
    /// </summary>
    public class CustomActionCacheFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("Cache-Control", "public,max-age=6000");
            Console.WriteLine($"This {nameof(CustomActionCacheFilterAttribute)} OnActionExecuted{this.Order}");
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"This {nameof(CustomActionCacheFilterAttribute)} OnActionExecuting{this.Order}");
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($"This {nameof(CustomActionCacheFilterAttribute)} OnResultExecuting{this.Order}");
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"This {nameof(CustomActionCacheFilterAttribute)} OnResultExecuted{this.Order}");
        }
    }

}
