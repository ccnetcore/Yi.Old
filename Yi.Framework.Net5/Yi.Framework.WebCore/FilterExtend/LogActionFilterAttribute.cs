using Yi.Framework.Common.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yi.Framework.WebCore.FilterExtend
{
    /// <summary>
    /// 日志处理过滤器
    /// </summary>
    public class LogActionFilterAttribute : ActionFilterAttribute
    {
        private ILogger<LogActionFilterAttribute> _logger = null;
        public LogActionFilterAttribute(ILogger<LogActionFilterAttribute> logger)
        {
            this._logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string url = context.HttpContext.Request.Path.Value;
            string argument = JsonConvert.SerializeObject(context.ActionArguments);

            string controllerName = context.Controller.GetType().FullName;
            string actionName = context.ActionDescriptor.DisplayName;

            LogModel logModel = new LogModel()
            {
                OriginalClassName = controllerName,
                OriginalMethodName = actionName,
                Remark = $"来源于{nameof(LogActionFilterAttribute)}.{nameof(OnActionExecuting)}"
            };

            //this._logger.LogInformation($"url={url}---argument={argument}",new object[] { JsonConvert.SerializeObject(logModel) } );
            this._logger.LogInformation($"url={url}---argument={argument}");
        }
    }

    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"This {nameof(LogActionFilterAttribute)} OnActionExecuted{this.Order}");
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"This {nameof(LogActionFilterAttribute)} OnActionExecuting{this.Order}");
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($"This {nameof(LogActionFilterAttribute)} OnResultExecuting{this.Order}");
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"This {nameof(LogActionFilterAttribute)} OnResultExecuted{this.Order}");
        }
    }

    public class CustomControllerFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"This {nameof(CustomControllerFilterAttribute)} OnActionExecuted {this.Order}");
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"This {nameof(CustomControllerFilterAttribute)} OnActionExecuting{this.Order}");
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($"This {nameof(CustomControllerFilterAttribute)} OnResultExecuting{this.Order}");
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"This {nameof(CustomControllerFilterAttribute)} OnResultExecuted{this.Order}");
        }
    }

}
