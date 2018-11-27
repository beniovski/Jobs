using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace JobsPortal.Services
{
    public class CacheService : ICacheService
    {
        private readonly Cache _cache;

        private readonly CacheDependency _cacheDependency;

        private const int cacheDuration = 30;

        public CacheService()
        {
            _cache = new Cache();
            _cacheDependency = new CacheDependency(@"C:\Users\Daniel\Documents\visual studio 2017\Projects\JobsPortal\JobsPortal");
        }

        public T GetFromCache<T>(string cacheKey) where T : class
        {
            T value = (T)_cache.Get(cacheKey);
            return value;
        }

        public void SetCache<T>(string cacheKey, T value) where T : class
        {         

            if (_cache.Get(cacheKey) == null)
            {
                _cache.Add(cacheKey, value, _cacheDependency, DateTime.Now.AddMinutes(cacheDuration), TimeSpan.Zero, CacheItemPriority.Normal, null);
            }
            else
            {
                _cache[cacheKey] = value;
            }
        }
    }
}