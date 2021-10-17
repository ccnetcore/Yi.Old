using Com.Ctrip.Framework.Apollo;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Com.Ctrip.Framework.Apollo.Enums;
using Com.Ctrip.Framework.Apollo.Logging;
using Microsoft.Extensions.Primitives;
using System.Reflection;

namespace Yi.Framework.WebCore.BuilderExtend
{
    public static class ApolloExtension
    {
        /// <summary>
        /// 接入Apollo
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="jsonPath">apollo配置文件路径 如果写入appsettings.json中 则jsonPath传null即可</param>
        public static void AddApolloService(this IConfigurationBuilder builder, params string[] NameSpace)
        {
            //阿波罗的日志级别调整
            LogManager.UseConsoleLogging(LogLevel.Warn);
            var root = builder.Build();
            var apolloBuilder = builder.AddApollo(root.GetSection("apollo")).AddDefault();



            foreach (var item in NameSpace)
            {
                apolloBuilder.AddNamespace(item, ConfigFileFormat.Json);
            }
            //监听apollo配置
            Monitor(builder.Build());


        }
        #region private
        /// <summary>
        /// 监听配置
        /// </summary>
        private static void Monitor(IConfigurationRoot root)
        {
            //TODO 需要根据改变执行特定的操作 如 mq redis  等其他跟配置相关的中间件
            //TODO 初步思路：将需要执行特定的操作key和value放入内存字典中，在赋值操作时通过标准事件来执行特定的操作。

            //要重新Build 此时才将Apollo provider加入到ConfigurationBuilder中
            ChangeToken.OnChange(() => root.GetReloadToken(), () =>
            {
                foreach (var apolloProvider in root.Providers.Where(p => p is ApolloConfigurationProvider))
                {
                    var property = apolloProvider.GetType().BaseType.GetProperty("Data", BindingFlags.Instance | BindingFlags.NonPublic);
                    var data = property.GetValue(apolloProvider) as IDictionary<string, string>;
                    foreach (var item in data)
                    {
                        Console.WriteLine($"key {item.Key}   value {item.Value}");
                    }
                }
            });
        }
        #endregion
    }
}