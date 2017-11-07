using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class LinqHelper
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();

            foreach (TSource element in source)
                if (seenKeys.Add(keySelector(element)))
                    yield return element;
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(IEnumerable<T> source, int size)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / size)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        public static string Flatten(IEnumerable<string> source, string seperator)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (string individual in source)
                stringBuilder.Append(individual).Append(seperator);

            stringBuilder.Remove(stringBuilder.Length - seperator.Length, seperator.Length);

            return stringBuilder.ToString();
        }
    }
}
