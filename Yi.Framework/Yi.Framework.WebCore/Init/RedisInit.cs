using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Common.Const;
using Yi.Framework.Core;
using Yi.Framework.DTOModel;

namespace Yi.Framework.WebCore.Init
{
   public class RedisInit
    {
        public  static void Seed(CacheClientDB _cacheClientDB)
        {
            var setDto = Common.Helper.JsonHelper.ObjToStr(new SettingDto()
            {
                ImageList_key =new List<string> { "默认图片", "默认图片" },
                InitRole_key = "普通用户",
                Title_key = "YiFramework",
                InitIcon_key = "默认头像"
            });
            if (_cacheClientDB.Get<SettingDto>(RedisConst.key)==null)
            {
                _cacheClientDB.Add(RedisConst.key,setDto) ;
            }
          
            Console.WriteLine(nameof(RedisInit) + ":Redis初始成功！");
        }
    }
}
