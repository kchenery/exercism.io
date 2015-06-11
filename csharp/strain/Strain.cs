using System;
using System.Collections.Generic;

namespace Exercism.Strain
{
    public static class Strain
    {
        public static IEnumerable<T> Keep<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Discard<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (!(predicate.Invoke(item)))
                {
                    yield return item;
                }
            }
        }
    }
}