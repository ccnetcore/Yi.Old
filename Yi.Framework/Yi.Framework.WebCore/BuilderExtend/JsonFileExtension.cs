using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.WebCore.BuilderExtend
{
    public static class JsonFileExtension
    {
        public static void AddJsonFileService(this IConfigurationBuilder builder, params string[] JsonFile)
        {
            if (JsonFile==null)
            {
                string[] myJsonFile = new string[] { "appsettings.json", "configuration.json" };
                foreach (var item in myJsonFile)
                {
                    builder.AddJsonFile(item, optional: true, reloadOnChange: false);
                }
            }
            else
            {
                foreach (var item in JsonFile)
                {
                    builder.AddJsonFile(item, optional: true, reloadOnChange: false);
                }
            }

        }
    }
}
