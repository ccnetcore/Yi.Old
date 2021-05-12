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




        public bool AddCache<T>(string key, T value, DateTime expDate)
        {
            return CacheWriter.AddCache<T>(key,value,expDate);
        }

        public bool AddCache<T>(string key, T value)
        {
            return CacheWriter.AddCache<T>(key, value);
        }

        public bool RemoveCache(string key)
        {
            return CacheWriter.RemoveCache(key);
        }

        public T GetCache<T>(string key)
        {
            return CacheWriter.GetCache<T>(key);
        }

        public bool SetCache<T>(string key, T value, DateTime expDate)
        {
            return CacheWriter.SetCache<T>(key,value,expDate);
        }

        public bool SetCache<T>(string key, T value)
        {
            return CacheWriter.SetCache<T>(key, value);
        }

    }
}
