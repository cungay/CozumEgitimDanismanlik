﻿using System;

namespace Ekip.Framework.Core
{
    public static class TypeExtensions
    {
        public static bool IsNullable(this Type t)
        {
            return t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }
    }
}
