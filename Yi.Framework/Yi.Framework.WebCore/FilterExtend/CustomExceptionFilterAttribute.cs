using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CC.ElectronicCommerce.Common.Models;

namespace CC.ElectronicCommerce.WebCore.FilterExtend
{
    public class CustomExceptionFilterAttribute : IExceptionFilter
    {
        private ILogger<CustomExceptionFilterAttribute> _logger = null;
        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
        {
            this._logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                context.Result = new JsonResult(
                    Result.Error("操作失败").SetData(context.Exception.Message));
                string url = context.HttpContext.Request.Path.Value;
                string actionName = context.ActionDescriptor.DisplayName;

                var logModel = new LogModel()
                {
                    OriginalClassName = "",
                    OriginalMethodName = actionName,
                    Remark = $"来源于{nameof(CustomExceptionFilterAttribute)}.{nameof(OnException)}"
                };
                this._logger.LogError(context.Exception, $"{url}----->actionName={actionName}  Message={context.Exception.Message}", JsonConvert.SerializeObject(logModel));
            }
            context.ExceptionHandled = true;
        }
    }
}
