using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace Ekip.Framework.Core
{
    public static class EnumExtensions
    {
        public static Dictionary<Enum, string> ToList(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            Dictionary<Enum, string> list = new Dictionary<Enum, string>();
            Array enumValues = Enum.GetValues(type);
            foreach (Enum value in enumValues)
            {
                list.Add(value, GetDescription(value));
            }
            return list;

        }

        public static Dictionary<int, string> ToValueList(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            Dictionary<int, string> list = new Dictionary<int, string>();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                if (list.Keys.Contains(value.GetHashCode()))
                    continue;
                list.Add(value.GetHashCode(), GetDescription(value));

                //if (Convert.ToInt32(value) > 0)
                //{
                    
                //}
            }
            return list;
        }

        public static char GetChar(this Enum value)
        {
            return value.GetHashCode().ToString()[0];
        }

        public static string GetString(this Enum value)
        {
            return value.GetHashCode().ToString();
        }

        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
              (DescriptionAttribute[])fi.GetCustomAttributes
              (typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        public static object ToEnumObject(this object value, Type enumType)
        {
            return Enum.Parse(enumType, value.ToString());
        }

        public static List<T> ToList<T>(this Enum value)
        {
            List<T> values = new List<T>();
            Array array = Enum.GetValues(value.GetType());
            foreach (T item in array)
                values.Add(item);

            return values;
        }

        public static string[] GetNames(this Enum value)
        {
            return Enum.GetNames(value.GetType());
        }

        public static List<T> ToValues<T>(this Enum value)
        {
            List<T> values = new List<T>();
            Array array = Enum.GetValues(value.GetType());
            foreach (T item in array)
                values.Add(item);
            return values;
        }

        public static char ValueAsChar<TEnum>(TEnum value) where TEnum : struct //ideally enum
        {
            ThrowExceptionIfNotEnum<TEnum>();
            char ch = Convert.ToChar(Convert.ToInt16(value));
            return ch;

        }

        private static void ThrowExceptionIfNotEnum<TEnum>()
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException(typeof(TEnum).ToString() + " is not an Enum");
            }
        }
    }
}
