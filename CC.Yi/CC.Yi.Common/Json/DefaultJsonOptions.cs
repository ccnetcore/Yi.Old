using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace CC.Yi.Common.Json
{
    /// <summary>
    /// https://blog.csdn.net/sD7O95O/article/details/103797885
    /// </summary>
    public class DefaultJsonOptions
    {
        public static JsonSerializerOptions Get()
        {
            var options = new JsonSerializerOptions();
            //options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            options.IgnoreNullValues = true;//排除所有属性值为 null 属性
            //// 自定义名称策略
            //options.PropertyNamingPolicy = new LowerCaseNamingPolicy();
            return options;
        }
    }
}
