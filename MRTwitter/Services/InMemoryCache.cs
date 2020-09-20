using MRTwitter.Interfaces;
using System;
using System.Runtime.Caching;

namespace MRTwitter.Services
{
    public class InMemoryCache : ICacheService
    {
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            if (item == null)
            {
                item = getItemCallback();
                if (item != null)
                {
                    MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(60));
                }
            }
            return item;
        }
    }
}