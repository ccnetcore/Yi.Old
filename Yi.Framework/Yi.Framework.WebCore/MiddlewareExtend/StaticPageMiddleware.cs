//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CC.ElectronicCommerce.WebCore.MiddlewareExtend
//{
//    /// <summary>
//    /// 支持在返回HTML时，将返回的Stream保存到指定目录
//    /// </summary>
//    public class StaticPageMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private string _directoryPath = @"D:/cc-ec/";
//        private bool _supportDelete = false;
//        private bool _supportWarmup = false;

//        public StaticPageMiddleware(RequestDelegate next, string directoryPath, bool supportDelete, bool supportWarmup)
//        {
//            this._next = next;
//            this._directoryPath = directoryPath;
//            this._supportDelete = supportDelete;
//            this._supportWarmup = supportWarmup;
//        }

//        public async Task InvokeAsync(HttpContext context)
//        {
//            if (this._supportDelete && "Delete".Equals(context.Request.Query["ActionHeader"]))
//            {
//                this.DeleteHmtl(context.Request.Path.Value);
//                context.Response.StatusCode = 200;
//            }
//            else if (this._supportWarmup && "ClearAll".Equals(context.Request.Query["ActionHeader"]))
//            {
//                this.ClearDirectory(10);//考虑数据量
//                context.Response.StatusCode = 200;
//            }
//            else if (!context.Request.IsAjaxRequest())
//            {
//                Console.WriteLine($"This is StaticPageMiddleware InvokeAsync {context.Request.Path.Value}");
//                #region context.Response.Body
//                var originalStream = context.Response.Body;
//                using (var copyStream = new MemoryStream())
//                {
//                    context.Response.Body = copyStream;
//                    await _next(context);

//                    copyStream.Position = 0;
//                    var reader = new StreamReader(copyStream);
//                    var content = await reader.ReadToEndAsync();
//                    string url = context.Request.Path.Value;

//                    this.SaveHmtl(url, content);

//                    copyStream.Position = 0;
//                    await copyStream.CopyToAsync(originalStream);
//                    context.Response.Body = originalStream;
//                }
//                #endregion
//            }
//            else
//            {
//                await _next(context);
//            }
//        }

//        private void SaveHmtl(string url, string html)
//        {
//            try
//            {
//                //Console.WriteLine($"Response: {html}");
//                if (string.IsNullOrWhiteSpace(html))
//                    return;
//                if (!url.EndsWith(".html"))
//                    return;

//                if (Directory.Exists(_directoryPath) == false)
//                    Directory.CreateDirectory(_directoryPath);

//                var totalPath = Path.Combine(_directoryPath, url.Split("/").Last());
//                File.WriteAllText(totalPath, html);//直接覆盖
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//        }

//        /// <summary>
//        /// 删除某个页面
//        /// </summary>
//        /// <param name="url"></param>
//        /// <param name="index"></param>
//        private void DeleteHmtl(string url)
//        {
//            try
//            {
//                if (!url.EndsWith(".html"))
//                    return;
//                var totalPath = Path.Combine(_directoryPath, url.Split("/").Last());
//                File.Delete(totalPath);//直接删除
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Delete {url} 异常，{ex.Message}");
//            }
//        }

//        /// <summary>
//        /// 清理文件，支持重试
//        /// </summary>
//        /// <param name="index">最多重试次数</param>
//        private void ClearDirectory(int index)
//        {
//            if (index > 0)//简陋版---重试index次
//            {
//                try
//                {
//                    var files = Directory.GetFiles(_directoryPath);
//                    foreach (var file in files)
//                    {
//                        File.Delete(file);
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"ClearDirectory failed {ex.Message}");
//                    ClearDirectory(index--);
//                }
//            }
//        }
//    }

//    /// <summary>
//    /// 扩展中间件
//    /// </summary>
//    public static class StaticPageMiddlewareExtensions
//    {
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="app"></param>
//        /// <param name="directoryPath">文件写入地址,文件夹目录</param>
//        /// <param name="supportDelete">是否支持删除</param>
//        /// <param name="supportClear">是否支持全量删除</param>
//        /// <returns></returns>
//        public static IApplicationBuilder UseStaticPageMiddleware(this IApplicationBuilder app, string directoryPath, bool supportDelete, bool supportClear)
//        {
//            return app.UseMiddleware<StaticPageMiddleware>(directoryPath, supportDelete, supportClear);
//        }
//    }
//}