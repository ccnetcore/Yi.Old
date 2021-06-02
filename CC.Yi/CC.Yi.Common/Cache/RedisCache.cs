using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.Yi.Common.Cache
{
    public class RedisCache : ICacheWriter
    {
        private RedisClient client;
        private string ip = "49.235.212.122";
        private int port = 6379;
        private string pwd = "Qz52013142020.";
        public RedisCache()
        {
        }

        public void Dispose()
        {
            client.Dispose();
        }

        public bool AddCache<T>(string key, T value, DateTime expDate)
        {
            try
            {
                using (client = new RedisClient(ip, port, pwd))
                {
                    return client.Add<T>(key, value, expDate);
                }
            }
            catch
            {

                return false;
            }
        }

        public bool AddCache<T>(string key, T value)
        {
            return client.Add<T>(key, value);
        }

        public bool RemoveCache(string key)
        {
            return client.Remove(key);
        }

        public T GetCache<T>(string key)
        {
            try
            {
                using (client = new RedisClient(ip, port, pwd))
                {
                    return client.Get<T>(key);
                }
            }
            catch
            {
                object p = new object();
                return (T)p;
            }
        }



        public bool SetCache<T>(string key, T value, DateTime expDate)
        {
            try
            {
                using (client = new RedisClient(ip, port, pwd))
                {
                    return client.Set<T>(key, value, expDate);
                }
            }
            catch
            {
                return false;
            }
        }

        public bool SetCache<T>(string key, T value)
        {
            try
            {
                using (client = new RedisClient(ip, port, pwd))
                {
                    return client.Set<T>(key, value);
                }
            }
            catch
            {
                object p = new object();
                return false;
            }

        }
    }
}
