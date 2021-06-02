using Autofac;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.Yi.Common.Cache
{
    public class CacheHelper
    {
        public static ICacheWriter CacheWriter { get; set; }
        static CacheHelper()
        {
            CacheHelper.CacheWriter = new RedisCache();
        }




        public static bool AddCache<T>(string key, T value, DateTime expDate)
        {
            return CacheWriter.AddCache<T>(key,value,expDate);
        }

        public static bool AddCache<T>(string key, T value)
        {
            return CacheWriter.AddCache<T>(key, value);
        }

        public static bool RemoveCache(string key)
        {
            return CacheWriter.RemoveCache(key);
        }

        public static T GetCache<T>(string key)
        {
            return CacheWriter.GetCache<T>(key);
        }

        public static bool SetCache<T>(string key, T value, DateTime expDate)
        {
            return CacheWriter.SetCache<T>(key,value,expDate);
        }

        public static bool SetCache<T>(string key, T value)
        { 
            return CacheWriter.SetCache<T>(key, value);
        }

    }
}
