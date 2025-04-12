using System;
using System.Collections.Generic;

namespace LinqInternals
{
    public static class IEunumerableExtension
    {
        public static IEnumerable<T> NewWhere<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            var list = new List<T>();
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
