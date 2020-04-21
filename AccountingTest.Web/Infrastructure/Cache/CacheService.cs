using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace AccountingTest.Web.Services.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache memoryCache;

        private static readonly ConcurrentDictionary<string, bool> allKeys;

        public CacheService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public T GetOrAdd<T>(string cacheKey, Func<T> factory, DateTime absoluteExpiration)
        {
            // locks get and set internally
            if (this.memoryCache.TryGetValue<T>(cacheKey, out var result))
            {
                return result;
            }

            lock (TypeLock<T>.Lock)
            {
                if (this.memoryCache.TryGetValue(cacheKey, out result))
                {
                    return result;
                }

                result = factory();
                this.memoryCache.Set(cacheKey, result, absoluteExpiration);

                return result;
            }
        }

        public IEnumerable<T> GetAll<T>(string cacheKey, Func<T> factory, DateTime absoluteExpiration)
        {
        }

        private static class TypeLock<T>
        {
            public static object Lock { get; } = new object();
        }
    }
}