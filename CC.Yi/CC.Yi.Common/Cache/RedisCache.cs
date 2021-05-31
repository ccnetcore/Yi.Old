using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.Yi.Common.Cache
{
    public class RedisCache : ICacheWriter
    {
        private RedisClient client;
        public RedisCache()
        {
            client = new RedisClient("127.0.0.1", 6379, "52013142020.");
        }

        public bool AddCache<T>(string key, T value, DateTime expDate)
        {
          return  client.Add<T>(key, value, expDate);
        }

        public bool AddCache<T>(string key, T value)
        {
           return client.Add<T>(key, value);
        }

        public bool RemoveCache(string key)
        {
         return  client.Remove(key);
        }

        public T GetCache<T>(string key)
        {
            return client.Get<T>(key);
        }

        public bool SetCache<T>(string key,T value, DateTime expDate)
        {
            return client.Set<T>(key, value, expDate);
        }

        public bool SetCache<T>(string key, T value)
        {
            return client.Set<T>(key, value);
        }
    }
}
