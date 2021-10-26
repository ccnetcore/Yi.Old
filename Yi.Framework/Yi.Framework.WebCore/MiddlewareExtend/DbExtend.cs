using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Common.IOCOptions;
using Yi.Framework.Model;
using Yi.Framework.Model.ModelFactory;

namespace Yi.Framework.WebCore.MiddlewareExtend
{
    public static class DbExtend
    {
        public static IServiceCollection AddDbService(this IServiceCollection services)
        {
            DbContextFactory.MutiDB_Enabled = Appsettings.appBool("MutiDB_Enabled");
            DataContext.DbSelect = Appsettings.app("DbSelect");
            services.Configure<DbConnOptions>(Appsettings.appConfiguration("DbConn"));
            return services;
        }
    }
}
