using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Common.IOCOptions;
using Yi.Framework.Interface;
using Yi.Framework.Model;
using Yi.Framework.Service;
using Yi.Framework.WebCore;
using Yi.Framework.WebCore.FilterExtend;
using Yi.Framework.WebCore.MiddlewareExtend;
using Yi.Framework.WebCore.Utility;

namespace Yi.Framework.ApiMicroservice
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

            #region
            //控制器+过滤器配置
            #endregion
            services.AddControllers(optios=> {
                //optios.Filters.Add(typeof(CustomExceptionFilterAttribute));
            });

            #region
            //Swagger服务配置
            #endregion
            services.AddSwaggerService<Program>();

            #region
            //跨域服务配置
            #endregion
            services.AddCorsService();

            #region
            //Jwt鉴权配置
            #endregion
            services.AddJwtService();

            #region
            //Sqlite服务配置
            #endregion
            services.AddSqliteService();

            #region
            //Redis服务配置
            #endregion
            //services.AddRedisService();

            #region
            //RabbitMQ服务配置
            #endregion
            //services.AddRabbitMQService();

            
        }

        #region Autofac容器注入
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            #region
            //交由Module依赖注入
            #endregion
            containerBuilder.RegisterModule<CustomAutofacModule>();
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public  void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            {
                #region
                //测试页面注入
                #endregion
                app.UseDeveloperExceptionPage();

                #region
                //Swagger服务注入
                #endregion
                app.UseSwaggerService();
            }
            #region
            //错误抓取反馈注入
            #endregion
            app.UseErrorHandlingService();

            #region
            //HttpsRedirection注入
            #endregion
            app.UseHttpsRedirection();

            #region
            //路由注入
            #endregion
            app.UseRouting();

            #region
            //跨域服务注入
            #endregion
            app.UseCorsService();

            #region
            //健康检查注入
            #endregion
            //app.UseHealthCheckMiddleware();

            #region
            //鉴权注入
            #endregion
            app.UseAuthentication();

            #region
            //授权注入
            #endregion
            app.UseAuthorization();

            #region
            //Consul服务注入
            #endregion
            //await app.UseConsulService();

            #region
            //Endpoints注入
            #endregion
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
