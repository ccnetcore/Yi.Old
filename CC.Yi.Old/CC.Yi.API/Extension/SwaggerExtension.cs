using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace CC.Yi.API.Extension
{
    /// <summary>
    /// Swagger文档扩展方法
    /// </summary>
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            var apiInfo = new OpenApiInfo
            {
                Title = "Yi意框架-API接口",
                Version = "v1",
                Contact = new OpenApiContact { Name = "橙子", Email = "454313500@qq.com", Url = new System.Uri("https://jiftcc.com") }
            };
            #region 注册Swagger服务
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", apiInfo);

                //添加注释服务
                //为 Swagger JSON and UI设置xml文档注释路径
                //获取应用程序所在目录(绝对路径，不受工作目录影响，建议采用此方法获取路径使用windwos&Linux）
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                var apiXmlPath = Path.Combine(basePath, @"ApiDoc.xml");//控制器层注释
                var entityXmlPath = Path.Combine(basePath, @"Model\ModelDoc.xml");//实体注释
                //c.IncludeXmlComments(apiXmlPath, true);//true表示显示控制器注释
                //c.IncludeXmlComments(entityXmlPath);

                //添加控制器注释
                //c.DocumentFilter<SwaggerDocTag>();

                //添加header验证信息
                //c.OperationFilter<SwaggerHeader>();
                //var security = new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } }, };

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "文本框里输入从服务器获取的Token。格式为：Bearer + 空格+token",//JWT授权(数据将在请求头中进行传输) 参数结构: \"Authorization: Bearer {token}\"
                    Name = "Authorization",////jwt默认的参数名称
                    In = ParameterLocation.Header,////jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey,
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference()
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    }, Array.Empty<string>() }
                });
            });
            #endregion

            return services;
        }

        public static void UseSwaggerService(this IApplicationBuilder app)
        {
            //在 Startup.Configure 方法中，启用中间件为生成的 JSON 文档和 Swagger UI 提供服务：
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JwtTest v1"));
        }

    }
}
