using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Common.Const
{
    public class RedisConst
    {
        /// <summary>
        /// 前缀
        /// </summary>
        public const string key = "YiFramework:data";

        public const string keyCode = "YiFramework:code";

        public const string userMenusApi = "YiFramework:userMenusApi";
        ///// <summary>
        ///// 初始化角色名
        ///// </summary>
        //public const string InitRole_key = nameof(InitRole_key);

        ///// <summary>
        ///// 标题名
        ///// </summary>
        //public const string Title_key = nameof(Title_key);

        ///// <summary>
        ///// 图片列表名
        ///// </summary>
        //public const string ImageList_key = nameof(ImageList_key);

        //public static Dictionary<string, string> stringData = new Dictionary<string, string>()
        //{
        //      {prefix+nameof(InitRole_key), "普通用户"},
        //      {prefix+nameof(Title_key), "YiFramework"},
        //};

        //public static Dictionary<string, List<string>> listData = new Dictionary<string, List<string>>()
        //{
        //     {prefix+nameof(ImageList_key), new List<string>(){"图片地址1", "图片地址2", "图片地址3", "图片地址4" } }
        //};
    }
}
