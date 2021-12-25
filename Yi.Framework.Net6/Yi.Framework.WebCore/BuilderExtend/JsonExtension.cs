using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.WebCore.BuilderExtend
{
    public static class JsonExtension
    {
        public static void AddJsonFileService(this IMvcBuilder builder)
        {
            builder.AddNewtonsoftJson(options =>
             {
                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                 options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm";
             });

        }
    }
}
