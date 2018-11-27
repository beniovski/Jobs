using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.Services
{
    public interface ICacheService
    {
        T GetFromCache<T>(string cacheKey) where T : class;

        void SetCache<T>(string cacheKey, T value) where T : class;
    }
}
