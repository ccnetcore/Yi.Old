using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CC.Yi.Common.Json
{
    /// <summary>
    /// 自定义名称策略
    /// </summary>
    public class LowerCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.ToLower();
    }

}
