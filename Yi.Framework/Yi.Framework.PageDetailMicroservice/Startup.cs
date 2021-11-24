using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yi.Framework.Interface;
using Yi.Framework.Service;
using Yi.Framework.WebCore.MiddlewareExtend;

namespace Yi.Framework.PageDetailMicroservice
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
            services.AddIocService(Configuration);
            services.AddSwaggerService<Program>();
            services.AddControllersWithViews();
            services.AddCorsService(); 
            services.AddDbService();
            services.AddScoped<IGoodsService,GoodsService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
           
            }
            app.UseCorsService();
            app.UseHttpsRedirection();
            #region
            //Swagger服务注入
            #endregion
            app.UseSwaggerService();
            app.UseRouting();
            app.UseStaticPageServer();
            app.UseAuthorization(); 
            app.UseConsulService();
            app.UseHealthCheckMiddleware();
            #region
            //开启静态化中间件
            #endregion
            app.UseStaticPageServer();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
