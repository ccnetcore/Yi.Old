using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yi.Framework.WebCore.FilterExtend
{
    /// <summary>
    /// 依赖注入工厂过滤器
    /// </summary>
    public class CustomIOCFilterFactoryAttribute : Attribute, IFilterFactory
    {
        private readonly Type _FilterType = null;

        public CustomIOCFilterFactoryAttribute(Type type)
        {
            this._FilterType = type;
        }
        public bool IsReusable => true;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            //return (IFilterMetadata)serviceProvider.GetService(typeof(CustomExceptionFilterAttribute));

            return (IFilterMetadata)serviceProvider.GetService(this._FilterType);
        }
    }


}
