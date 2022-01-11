using Autofac.Extensions.DependencyInjection;
using Yi.Framework.WebCore.BuilderExtend;
using Yi.Framework.Core;
using Yi.Framework.Model.ModelFactory;
using Yi.Framework.WebCore.MiddlewareExtend;
using Yi.Framework.WebCore.Utility;
using Autofac;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
 {
     configurationBuilder.AddCommandLine(args);
     configurationBuilder.AddJsonFileService();
     #region 
     //Apollo配置
     #endregion
     configurationBuilder.AddApolloService("Yi");
 });
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    #region
    //交由Module依赖注入
    #endregion
    containerBuilder.RegisterModule<CustomAutofacModule>();
});
builder.Host.ConfigureLogging(loggingBuilder =>
                {
                    loggingBuilder.AddFilter("System", Microsoft.Extensions.Logging.LogLevel.Warning);
                    loggingBuilder.AddFilter("Microsoft", Microsoft.Extensions.Logging.LogLevel.Warning);
                    loggingBuilder.AddLog4Net();
                });
#region
//配置类配置
//builder.Host.ConfigureWebHostDefaults(webBuilder =>
//                {
//                    //webBuilder.UseStartup<Startup>();
//                });
#endregion
//-----------------------------------------------------------------------------------------------------------
#region
//Ioc配置
#endregion
builder.Services.AddIocService(builder.Configuration);

#region
//Quartz任务调度配置
#endregion
builder.Services.AddQuartzService();
#region
//控制器+过滤器配置
#endregion
builder.Services.AddControllers(optios => {
    //optios.Filters.Add(typeof(CustomExceptionFilterAttribute));
}).AddJsonFileService();
#region
//Swagger服务配置
#endregion
builder.Services.AddSwaggerService<Program>();
#region
//跨域服务配置
#endregion
builder.Services.AddCorsService();
#region
//Jwt鉴权配置
#endregion
builder.Services.AddJwtService();
#region
//授权配置
#endregion
builder.Services.AddAuthorizationService();
#region
//数据库配置
#endregion
builder.Services.AddDbService();
#region
//Redis服务配置
#endregion
builder.Services.AddRedisService();
#region
//RabbitMQ服务配置
#endregion
builder.Services.AddRabbitMQService();
#region
//ElasticSeach服务配置
#endregion
builder.Services.AddElasticSeachService();
#region
//短信服务配置
#endregion
builder.Services.AddSMSService();
#region
//CAP服务配置
#endregion
builder.Services.AddCAPService<Program>();
//-----------------------------------------------------------------------------------------------------------
var app = builder.Build();
//if (app.Environment.IsDevelopment())
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
//静态文件注入
#endregion
//app.UseStaticFiles();
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
app.UseConsulService();
#region
//数据库种子注入
#endregion
app.UseDbSeedInitService(app.Services.GetService<IDbContextFactory>());
#region
//redis种子注入
#endregion
app.UseRedisSeedInitService(app.Services.GetService<CacheClientDB>());
#region
//Endpoints注入
#endregion
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();