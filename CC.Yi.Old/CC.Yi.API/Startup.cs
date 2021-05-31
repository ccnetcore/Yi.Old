
using Autofac;
using Autofac.Extras.DynamicProxy;
using CC.Yi.API.Extension;
using CC.Yi.API.Filter;
using CC.Yi.BLL;
using CC.Yi.Common.Cache;
using CC.Yi.Common.Castle;
using CC.Yi.Common.Jwt;
using CC.Yi.DAL;
using CC.Yi.IBLL;
using CC.Yi.IDAL;
using CC.Yi.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Yi.API
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            // 配置Jwt
            services.AddAuthorization(options =>
            {
                //配置基于策略的验证
                options.AddPolicy("myadmin", policy =>
                    policy.RequireRole("admin"));
            });

           
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options => {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,//是否验证Issuer
                           ValidateAudience = true,//是否验证Audience
                           ValidateLifetime = true,//是否验证失效时间
                           ClockSkew = TimeSpan.FromSeconds(30),
                           ValidateIssuerSigningKey = true,//是否验证SecurityKey
                           ValidAudience = JwtConst.Domain,//Audience
                           ValidIssuer = JwtConst.Domain,//Issuer，这两项和前面签发jwt的设置一致
                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConst.SecurityKey))//拿到SecurityKey
                       };
                   });


            services.AddControllers();
            services.AddSwaggerService();
            services.AddSession();



            //配置过滤器
            Action<MvcOptions> filters = new Action<MvcOptions>(r => {
                //r.Filters.Add(typeof(DbContextFilter));
            });
            services.AddMvc(filters);

            //配置数据库连接
            string connection1 = Configuration["ConnectionStringBySQL"];
            string connection2 = Configuration["ConnectionStringByMySQL"];
            string connection3 = Configuration["ConnectionStringBySQLite"];
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connection1, b => b.MigrationsAssembly("CC.Yi.API"));//设置数据库
            });


            //依赖注入转交给Autofac
            //services.AddScoped(typeof(IBaseDal<>), typeof(BaseDal<>));
            //services.AddScoped(typeof(IstudentBll), typeof(studentBll));

            //reids注册
            //services.AddSingleton(typeof(ICacheWriter), new RedisCacheService(new Microsoft.Extensions.Caching.Redis.RedisCacheOptions()
            //{
            //    Configuration = Configuration.GetSection("Cache.ConnectionString").Value,
            //    InstanceName = Configuration.GetSection("Cache.InstanceName").Value
            //}));


            //配置Identity身份认证
            //services.AddIdentity<result_user, IdentityRole>(options =>
            // {
            //     options.Password.RequiredLength = 6;//密码最短长度
            //     options.Password.RequireDigit = false;//密码需求数字
            //     options.Password.RequireLowercase = false;//密码需求小写字母
            //     options.Password.RequireNonAlphanumeric = false;//密码需求特殊字符
            //     options.Password.RequireUppercase = false;//密码需求大写字母
            //    //options.User.RequireUniqueEmail = false;//注册邮箱是否可以不重复
            //    //options.User.AllowedUserNameCharacters="abcd"//密码只允许在这里的字符
            //}).AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

            //解决跨域问题
            services.AddCors(options => options.AddPolicy("CorsPolicy",
             builder =>
             {
                 builder.AllowAnyMethod()
                     .SetIsOriginAllowed(_ => true)
                     .AllowAnyHeader()
                     .AllowCredentials();
             }));
        }

        //初始化使用函数
        private void InitData(IServiceProvider serviceProvider)
        {
            //var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();

            //var context = serviceScope.ServiceProvider.GetService<DataContext>();
            //DbContentFactory.Initialize(context);//调用静态类方法注入
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerService();
            }

            //app.UseAuthentication();
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            InitData(app.ApplicationServices);
        }
    }
}
