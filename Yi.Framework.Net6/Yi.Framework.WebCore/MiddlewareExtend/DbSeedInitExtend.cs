﻿using log4net;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.ModelFactory;
using Yi.Framework.WebCore.Init;

namespace Yi.Framework.WebCore.MiddlewareExtend
{
  public static class DbSeedInitExtend
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DbSeedInitExtend));
        public  static  void UseDbSeedInitService(this IApplicationBuilder app, IDbContextFactory _DbFactory)
        {

            if (Appsettings.appBool("DbSeed_Enabled"))
            {
                if (app == null) throw new ArgumentNullException(nameof(app));

                try
                {
                    DataSeed.SeedAsync(_DbFactory).Wait();
                }
                catch (Exception e)
                {
                    log.Error($"Error occured seeding the Database.\n{e.Message}");
                    throw;
                }
            }
        }
    }
}
