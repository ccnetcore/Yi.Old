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
using Yi.Framework.ApiMicroservice.Utility;
using Yi.Framework.Common.IOCOptions;
using Yi.Framework.Interface;
using Yi.Framework.Model;
using Yi.Framework.Service;
using Yi.Framework.WebCore.MiddlewareExtend;

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
            //控制器+过滤器配置
            #endregion
            services.AddControllers();

            #region
            //Swagger服务配置
            #endregion
            services.AddSwaggerService<Program>();

            #region
            //跨域服务配置
            #endregion
            services.AddCorsService();

            #region
            //数据库服务配置
            #endregion
            services.AddDataBaseService<SqliteOptions>("SqliteConn");

            //下面这些应自动注入
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();


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
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseHealthCheckMiddleware();

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
            await app.UseConsulService();

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
