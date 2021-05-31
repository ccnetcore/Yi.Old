using CC.Yi.DAL;
using CC.Yi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Yi.API.Filter
{
    public class DbContextFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cache = filterContext.HttpContext.RequestServices.GetService(typeof(DataContext)) as DataContext;
            DbContentFactory.Initialize(cache);
            base.OnActionExecuting(filterContext);
          
        }
    }
}
