using System;

namespace Ekip.Framework.Core.Caching
{
    public class RedisCacheManager : ICacheManager
    {
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public bool IsSet(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveByPattern(string pattern)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, object data, int cacheTime = 60)
        {
            throw new NotImplementedException();
        }
    }
}
