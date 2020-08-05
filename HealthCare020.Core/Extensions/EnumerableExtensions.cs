using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HealthCare020.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> GetDuplicates<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IEqualityComparer<TKey> comparer)
        {
            var hash = new HashSet<TKey>(comparer);
            return source.Where(item => !hash.Add(selector(item))).ToList();
        }

        public static IEnumerable<TSource> GetDuplicates<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            return source.GetDuplicates(x => x, comparer);
        }

        public static IEnumerable<TSource> GetDuplicates<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            return source.GetDuplicates(selector, null);
        }

        public static IEnumerable<TSource> GetDuplicates<TSource>(this IEnumerable<TSource> source)
        {
            return source.GetDuplicates(x => x, null);
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable) {
            var col = new ObservableCollection<T>();
            foreach ( var cur in enumerable ) {
                col.Add(cur);
            }
            return col;
        }

    }
}