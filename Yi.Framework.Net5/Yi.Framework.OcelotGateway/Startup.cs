using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Common.Models;
using Ocelot.Cache.CacheManager;
using Yi.Framework.WebCore.MiddlewareExtend;
using Ocelot.Provider.Polly;

namespace Yi.Framework.OcelotGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            #region
            //跨域服务配置
            #endregion
            services.AddCorsService();

            #region
            //网关服务配置
            #endregion
            services.AddOcelot().AddConsul().AddCacheManager(x =>{x.WithDictionaryHandle();}).AddPolly();

            #region
            //Swagger服务配置
            #endregion
            services.AddSwaggerService<Program>("Yi.Framework.OcelotGateway");
            #region
            //Jwt鉴权配置
            #endregion
            services.AddJwtService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                #region
                //Swagger服务注入
                #endregion
                app.UseSwaggerService(new SwaggerModel("api/api/swagger/v1/swagger.json","API服务"), new SwaggerModel("api/item/swagger/v1/swagger.json", "静态页服务"));
            }
            #region
            //网关服务注入
            #endregion
            app.UseOcelot();

            #region
            //鉴权注入
            #endregion
            app.UseAuthentication();
        }
    }
}
