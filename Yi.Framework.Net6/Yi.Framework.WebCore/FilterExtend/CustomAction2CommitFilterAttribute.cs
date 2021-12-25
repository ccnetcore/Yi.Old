using Yi.Framework.Common.Models;
using Yi.Framework.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Common.Helper;

namespace Yi.Framework.WebCore.FilterExtend
{
    /// <summary>
    /// 重复提交过滤器
    /// </summary>
    public class CustomAction2CommitFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 防重复提交周期  单位秒
        /// </summary>
        //public int TimeOut = 1;

        //#region Identity
        //private readonly ILogger<CustomAction2CommitFilterAttribute> _logger;
        //private readonly CacheClientDB _cacheClientDB;
        //private static string KeyPrefix = "2CommitFilter";

       // public CustomAction2CommitFilterAttribute(ILogger<CustomAction2CommitFilterAttribute> logger, CacheClientDB cacheClientDB)
       // {
       //     this._logger = logger;
       //     this._cacheClientDB = cacheClientDB;
       // }
       // #endregion


       //if (this.IsAjaxRequest(context.HttpContext.Request))
            //    //{ }
            //    context.Result = new RedirectResult("~/Fourth/Login");
            //}
            //else
            //{
            //    this._logger.LogDebug($"{currentUser.Name} 访问系统");
            //}
        //} public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    string url = context.HttpContext.Request.Path.Value;
        //    string argument = JsonConvert.SerializeObject(context.ActionArguments);
        //    string ip = context.HttpContext.Connection.RemoteIpAddress.ToString();
        //    string agent = context.HttpContext.Request.Headers["User-Agent"];
        //    string sInfo = $"{url}-{argument}-{ip}-{agent}";
        //    string summary = MD5Helper.MD5EncodingOnly(sInfo);

        //    string totalKey = $"{KeyPrefix}-{summary}";

        //    string result = this._cacheClientDB.Get<string>(totalKey);
        //    if (string.IsNullOrEmpty(result))
        //    {
        //        this._cacheClientDB.Add(totalKey, "1", TimeSpan.FromSeconds(3));//3秒有效期
        //        this._logger.LogInformation($"CustomAction2CommitFilterAttribute:{sInfo}");
        //    }
        //    else
        //    {
        //        //已存在
        //        this._logger.LogWarning($"CustomAction2CommitFilterAttribute重复请求:{sInfo}");
        //        context.Result = new JsonResult(Result.Error("请勿重复提交"));
        //    }

        //    //CurrentUser currentUser = context.HttpContext.GetCurrentUserBySession();
        //    //if (currentUser == null)
        //    //{
        //    //    //
        //private bool IsAjaxRequest(HttpRequest request)
        //{
        //    string header = request.Headers["X-Requested-With"];
        //    return "XMLHttpRequest".Equals(header);
        //}
    }
}
