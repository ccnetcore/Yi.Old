using System;

namespace CC.Yi.Common
{
    public static class JsonHelper
    {
        public static string JsonToString(object data=null, int code = 200, bool flag = true, string message = "成功")
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new { code = code, flag = flag, message = message, data = data });
        }
        public static string JsonToString2(object data = null, int code = 200, bool flag = true, string message = "成功",int count=0)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new { code = code, flag = flag, message = message, count=count,data = data });
        }
        public static string ToString(object data)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        public static T ToJson<T>(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data);
        }
    }
}
