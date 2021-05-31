using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Yi.Common.Cache
{
    public interface ICacheWriter
    {
        bool AddCache<T>(string key, T value, DateTime expDate);
        bool AddCache<T>(string key, T value);
        bool RemoveCache(string key);
        T GetCache<T>(string key);
        bool SetCache<T>(string key, T value, DateTime expDate);
        bool SetCache<T>(string key, T value);
    }
}
