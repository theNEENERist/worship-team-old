using System;
using System.Runtime.Caching;
using System.Configuration;

namespace Common
{
    public class CacheLayer
    {
        private static readonly ObjectCache cache = MemoryCache.Default;

        public static T Get<T>(string key) where T : class
        {
            try
            {
                return (T)cache[key];
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return null;
            }
        }

        public static void Add(object objectToCache, string key)
        {
            ObjectCache cache = MemoryCache.Default;
            CacheItemPolicy policy = new CacheItemPolicy() { AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration };

            cache.Add(new CacheItem(key, objectToCache), policy);
        }

        public static void Remove(string key)
        {
            ObjectCache cache = MemoryCache.Default;

            cache.Remove(key);
        }
    }
}
