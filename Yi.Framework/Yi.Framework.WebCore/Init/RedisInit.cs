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
            
            if (_cacheClientDB.Get<SettingDto>(RedisConst.key)==null)
            {
                _cacheClientDB.Add(RedisConst.key, new SettingDto()
                {
                    ImageList_key = { "默认图片", "默认图片" } ,
                    InitRole_key= "默认角色",
                    Title_key= "默认标题",
                    InitIcon_key= "默认头像"
                }) ;
            }
          
            Console.WriteLine(nameof(RedisInit) + ":Redis初始成功！");
        }
    }
}
