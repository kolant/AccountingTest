using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingTest.Web.Services.Cache
{
    public interface ICacheService
    {
        T GetOrAdd<T>(string cacheKey, Func<T> factory, DateTime absoluteExpiration);
    }
}
