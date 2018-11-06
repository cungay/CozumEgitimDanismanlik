using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Linq.Expressions;
using System.Data;

namespace Ekip.Framework.Core
{
    public static class GenericExtensions
    {
        #region Hashtable

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this Hashtable t)
        {
            var dic = new Dictionary<TKey, TValue>();

            foreach (DictionaryEntry entry in t)
            {
                dic.Add((TKey)entry.Key, (TValue)entry.Value);
            }

            return dic;
        }

        #endregion

        #region IList

        /// <summary>
        /// This extension method replaces an item in a collection that implements the IList interface.
        /// </summary>
        /// <typeparam name="T">The type of the field that we are manipulating</typeparam>
        /// <param name="thisList">The input list</param>
        /// <param name="position">The position of the old item</param>
        /// <param name="item">The item we are goint to put in it's place</param>
        /// <returns>True in case of a replace, false if failed</returns>
        public static bool Replace<T>(this IList<T> thisList, int position, T item)
        {
            if (position > thisList.Count - 1)
                return false;
            // only process if inside the range of this list

            thisList.RemoveAt(position);
            // remove the old item
            thisList.Insert(position, item);
            // insert the new item at its position
            return true;
            // return success
        }

        /// <summary>
        /// Converts an arraylist to a generic List
        /// </summary>
        /// <typeparam name="T">The type of the elements in the arraylist</typeparam>
        /// <param name="l">The arraylist</param>
        /// <returns></returns>
        public static List<T> ToList<T>(this ArrayList l)
        {
            var list = new List<T>();

            foreach (T entry in l)
            {
                list.Add(entry);
            }

            return list;
        }

        public static TList With<TList, T>(this TList list, T item) where TList : IList<T>, new()
        {
            TList l = new TList();

            foreach (T i in list)
            {
                l.Add(i);
            }
            l.Add(item);

            return l;
        }

        public static TList Without<TList, T>(this TList list, T item) where TList : IList<T>, new()
        {
            TList l = new TList();

            foreach (T i in list.Where(n => !n.Equals(item)))
            {
                l.Add(i);
            }

            return l;
        }
        
        #endregion

        #region IEnumerable<T>

        public static string ToString<T>(this IEnumerable<T> list, string separator)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var obj in list)
            {
                if (sb.Length > 0)
                {
                    sb.Append(separator);
                }
                sb.Append(obj);
            }
            return sb.ToString();
        }

        public static IEnumerable<TDestination> Convert<TSource, TDestination>(this IEnumerable<TSource>
            enumerable, Func<TSource, TDestination> converter)
        {
            if (enumerable == null)
            {
                return null;
            }

            List<TDestination> items = new List<TDestination>();

            foreach (TSource item in enumerable)
            {
                items.Add(converter(item));
            }

            return items.ToArray();
        }

        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException("sequence");
            }
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            foreach (var item in sequence)
            {
                action(item);
            }
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> sequence, Predicate<T> predicate)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException("sequence");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            foreach (var item in sequence)
            {
                if (predicate(item))
                {
                    // Yield makes this perform like a Custom Iterator
                    // Returns control after each item
                    // Retains its position in the sequence
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Sort<T>(this IEnumerable<T> sequence, Comparison<T> comparison)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException("sequence");
            }
            if (comparison == null)
            {
                throw new ArgumentNullException("comparison");
            }

            var list = new List<T>(sequence);
            list.Sort(comparison);
            foreach (var item in list)
            {
                // Yield makes this perform like a Custom Iterator
                // Returns control after each item
                // Retains its position in the sequence
                yield return item;
            }
        }

        public static List<T> NotIn<T>(this IEnumerable<T> source, IEnumerable<T> dest)
        {
            List<T> notinList = new List<T>();
            foreach (T s in source)
            {
                bool found = false;
                foreach (T d in dest)
                {
                    if (d != null && s != null)
                    {
                        if (d.Equals(s))
                        {
                            found = true;
                            break;
                        }
                    }
                }
                if (found == false)
                    notinList.Add(s);
            }
            return notinList;
        }

        public static IEnumerable<T> Descendants<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> DescendBy)
        {
            foreach (T value in source)
            {
                yield return value;

                foreach (T child in DescendBy(value).Descendants<T>(DescendBy))
                {
                    yield return child;
                }
            }
        }

        #endregion

        #region IOrderedEnumerable

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> enumerable,
            Func<TSource, TKey> keySelector, bool descending)
        {
            if (enumerable == null)
            {
                return null;
            }

            if (descending)
            {
                return enumerable.OrderByDescending(keySelector);
            }

            return enumerable.OrderBy(keySelector);
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> enumerable,
            Func<TSource, IComparable> keySelector1,
            Func<TSource, IComparable> keySelector2,
            params Func<TSource, IComparable>[] keySelectors)
        {
            if (enumerable == null)
            {
                return null;
            }

            IEnumerable<TSource> current = enumerable;

            if (keySelectors != null)
            {
                for (int i = keySelectors.Length - 1; i >= 0; i--)
                {
                    current = current.OrderBy(keySelectors[i]);
                }
            }

            current = current.OrderBy(keySelector2);

            return current.OrderBy(keySelector1);
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> enumerable,
            bool descending, Func<TSource, IComparable> keySelector,
            params Func<TSource, IComparable>[] keySelectors)
        {
            if (enumerable == null)
            {
                return null;
            }

            IEnumerable<TSource> current = enumerable;

            if (keySelectors != null)
            {
                for (int i = keySelectors.Length - 1; i >= 0; i--)
                {
                    current = current.OrderBy(keySelectors[i], descending);
                }
            }

            return current.OrderBy(keySelector, descending);
        }

        #endregion

        #region Queryable

        public static IQueryable<TEntity> StartsWith<TEntity>(this IQueryable<TEntity> query,
            string propertyName, string value)
        {
            ParameterExpression param = System.Linq.Expressions.Expression.Parameter(typeof(TEntity), "p");

            MethodCallExpression testExp = LambdaExpression.Call(
            System.Linq.Expressions.Expression.Property(param, propertyName),
            "StartsWith",
            new Type[] { typeof(string), typeof(System.StringComparison) },
            new System.Linq.Expressions.Expression[] { System.Linq.Expressions.Expression.Constant(value),
            System.Linq.Expressions.Expression.Constant(System.StringComparison.CurrentCultureIgnoreCase) });
            return query.Where(System.Linq.Expressions.Expression.Lambda<Func<TEntity, bool>>(testExp, param));
        }

        public static IQueryable<TSource> Between<TSource, TKey>(this IQueryable<TSource> source,
           Expression<Func<TSource, TKey>> keySelector,
           TKey low, TKey high) where TKey : IComparable<TKey>
        {
            Expression key = Expression.Invoke(keySelector,
                 keySelector.Parameters.ToArray());
            Expression lowerBound = Expression.Equal
                (Expression.Constant(low), key);
            Expression upperBound = Expression.Equal
                (key, Expression.Constant(high));
            Expression and = Expression.AndAlso(lowerBound, upperBound);
            Expression<Func<TSource, bool>> lambda =
                Expression.Lambda<Func<TSource, bool>>(and, keySelector.Parameters);
            return source.Where(lambda);
        }

        #endregion

        #region IDictionary

        public static void ExecuteOnValues<K, V>(this IDictionary<K, V> sequence, Action<V> action)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException("sequence");
            }

            foreach (var item in sequence.Values)
            {
                action(item);
            }
        }

        #endregion

        #region IComparable

        public static bool Between<T>(this T me, T lower, T upper) where T : IComparable<T>
        {
            return me.CompareTo(lower) >= 0 && me.CompareTo(upper) < 0;
        }

        public static bool LessThan<T>(this IComparable<T> comparable, T other)
        {
            return comparable.CompareTo(other) < 0;
        }

        public static bool AtLeast<T>(this T instance, T value) where T : IComparable<T>
        {
            var result = instance.CompareTo(value);
            return result == 0 || result == 1;
        }

        public static bool Before<T>(this T instance, T value) where T : IComparable<T>
        {
            return instance.CompareTo(value) == -1;
        }

        public static bool MoreThan<T>(this T instance, T value) where T : IComparable<T>
        {
            return instance.CompareTo(value) == 1;
        }

        public static bool After<T>(this T instance, T value) where T : IComparable<T>
        {
            return instance.MoreThan(value);
        }

        #endregion

       
    }
}
