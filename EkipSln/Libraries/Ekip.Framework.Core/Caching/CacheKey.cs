using Ekip.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekip.Framework.Core.Caching
{
    public class CacheKey
    {
        public CacheKey(EntityKeys entityKey, int entityId)
        {
            this.GeneratedKey = string.Format(Pattern, entityKey.ToString(), entityId.ToString());
        }

        public string GeneratedKey { get; } = null;

        public string Pattern { get; } = "{0}-{1}";

        public static CacheKey New(EntityKeys entityKey, int entityId)
        {
            return new CacheKey(entityKey, entityId);
        }

        public override string ToString()
        {
            return GeneratedKey;
        }
    }

    public enum EntityKeys
    {
        None,
        Client
    }
}
