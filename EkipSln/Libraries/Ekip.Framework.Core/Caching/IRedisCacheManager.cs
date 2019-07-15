using System;

namespace Ekip.Framework.Core.Caching
{
    public interface IRedisCacheManager
    {
        void Set<T>(string key, T value);

        void Set<T>(string key, T value, TimeSpan timeout);

        T Get<T>(string key);

        bool Remove(string key);

        bool IsSet(string key);
    }
}
