//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using Microsoft.AspNetCore.Mvc.ViewFeatures;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Zhaoxi.AgileFramework.WebCore.FilterExtend
//{
//    public class CustomActionCheckFilterAttribute : ActionFilterAttribute
//    {
//        #region Identity
//        private readonly ILogger<CustomActionCheckFilterAttribute> _logger;
//        private readonly IModelMetadataProvider _modelMetadataProvider;
//        public CustomActionCheckFilterAttribute(ILogger<CustomActionCheckFilterAttribute> logger)
//        {
//            this._logger = logger;
//        }
//        #endregion

//        public override void OnActionExecuting(ActionExecutingContext context)
//        {
//            //CurrentUser currentUser = context.HttpContext.GetCurrentUserBySession();
//            //if (currentUser == null)
//            //{
//            //    //if (this.IsAjaxRequest(context.HttpContext.Request))
//            //    //{ }
//            //    context.Result = new RedirectResult("~/Fourth/Login");
//            //}
//            //else
//            //{
//            //    this._logger.LogDebug($"{currentUser.Name} 访问系统");
//            //}
//        }
//        private bool IsAjaxRequest(HttpRequest request)
//        {
//            string header = request.Headers["X-Requested-With"];
//            return "XMLHttpRequest".Equals(header);
//        }
//    }
//}
