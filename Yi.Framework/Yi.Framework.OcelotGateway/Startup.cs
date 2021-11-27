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
using Yi.Framework.WebCore;

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
            services.AddSingleton(new Appsettings(Configuration));
            services.AddControllers();
            //#region
            ////跨域服务配置
            //#endregion
            //services.AddCorsService();

            #region
            //Swagger服务配置
            #endregion
            services.AddSwaggerService<Program>("OcelotGateway");
            //#region
            ////Jwt鉴权配置
            //#endregion
            //services.AddJwtService();

            #region
            //网关服务配置
            #endregion
            services.AddOcelot().AddConsul().AddCacheManager(x => { x.WithDictionaryHandle(); }).AddPolly();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            {

                app.UseSwaggerService(
                     new SwaggerModel("api/v1/swagger.json", "ApiMicroservice"),
    new SwaggerModel("order/v1/swagger.json", "OrderMicroservice"),
    new SwaggerModel("search/v1/swagger.json", "SearchMicroservice"),
    new SwaggerModel("item/v1/swagger.json", "PageDetailMicroservice"),
    new SwaggerModel("stock/v1/swagger.json", "StockMicroservice")
   
    );
                app.UseOcelot();


            }
        }
    }
}
