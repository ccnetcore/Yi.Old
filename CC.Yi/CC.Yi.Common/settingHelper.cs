using CC.Yi.Common.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.Yi.Common
{
    public static class settingHelper
    {
        public static ICacheWriter CacheWriter { get; set; }

        static settingHelper()
        {
            settingHelper.CacheWriter = new RedisCache();
        }

        public static int commentPage()
        {
            return CacheWriter.GetCache<int>("commentPage");
        }
        public static int discussPage()
        {
            return CacheWriter.GetCache<int>("discussPage");
        }
        public static int commentExperience()
        {
            return CacheWriter.GetCache<int>("commentExperience");
        }
        public static int discussExperience()
        {
            return CacheWriter.GetCache<int>("discussExperience");
        }
        public static string title()
        {
            return CacheWriter.GetCache<string>("title");
        }

        //配置设置
        //public static void update(setting data)
        //{
        //    CacheWriter.SetCache<int>("commentPage", data.commentPage);
        //    CacheWriter.SetCache<int>("discussPage", data.discussPage);
        //    CacheWriter.SetCache<int>("commentExperience", data.commentExperience);
        //    CacheWriter.SetCache<int>("discussExperience", data.discussExperience);
        //    CacheWriter.SetCache<string>("title", data.title);
        //}
    }
}
