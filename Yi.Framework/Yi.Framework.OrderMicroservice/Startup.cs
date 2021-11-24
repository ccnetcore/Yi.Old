using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Interface;
using Yi.Framework.Service;
using Yi.Framework.WebCore.BuilderExtend;
using Yi.Framework.WebCore.MiddlewareExtend;

namespace Yi.Framework.OrderMicroservice
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
            #region
            //Ioc配置
            #endregion
            services.AddIocService(Configuration);
            services.AddControllers().AddJsonFileService();
            #region
            //Swagger服务配置
            #endregion
            services.AddSwaggerService<Program>();
            #region
            //跨域服务配置
            #endregion
            services.AddCorsService();
            #region
            //数据库配置
            #endregion
            services.AddDbService();
            #region
            //Redis服务配置
            #endregion
            services.AddRedisService();
            #region
            //RabbitMQ服务配置
            #endregion
            services.AddRabbitMQService();
            services.AddCAPService<Startup>();
            services.AddTransient<IOrderService, OrderService>();
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
                app.UseSwaggerService(new Common.Models.SwaggerModel("v1/swagger.json", "OrderMicroservice"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
           
            app.UseCorsService();
            app.UseHealthCheckMiddleware();
            app.UseConsulService(); 
            app.UseAuthorization();
            app.UseConsulService();
            app.UseHealthCheckMiddleware();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
