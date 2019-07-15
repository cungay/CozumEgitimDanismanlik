using Ekip.Framework.Core.Configuration;
using ServiceStack.Redis;
using System;

namespace Ekip.Framework.Core.Caching
{
    public class RedisCacheManager : IRedisCacheManager
    {
        private RedisEndpoint endPoint = null;

        public RedisCacheManager()
        {
            this.endPoint = new RedisEndpoint(
                RedisConfigurationManager.Config.Host, 
                RedisConfigurationManager.Config.Port, 
                RedisConfigurationManager.Config.Password, 
                RedisConfigurationManager.Config.DatabaseID);
        }

        public void Set<T>(string key, T value)
        {
            this.Set(key, value, TimeSpan.Zero);
        }

        public void Set<T>(string key, T value, TimeSpan timeout)
        {
            using (RedisClient client = new RedisClient(endPoint))
            {
                client.As<T>().SetValue(key, value, timeout);
            }
        }

        public T Get<T>(string key)
        {
            T result = default(T);

            using (RedisClient client = new RedisClient(endPoint))
            {
                var wrapper = client.As<T>();

                result = wrapper.GetValue(key);
            }

            return result;
        }

        public bool Remove(string key)
        {
            bool removed = false;

            using (RedisClient client = new RedisClient(endPoint))
            {
                removed = client.Remove(key);
            }

            return removed;
        }

        public bool IsSet(string key)
        {
            bool exists = false;

            using (RedisClient client = new RedisClient(endPoint))
            {
                exists = client.ContainsKey(key);
            }

            return exists;
        }
    }
}
