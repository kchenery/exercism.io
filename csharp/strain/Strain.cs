using System;
using System.Collections.Generic;

namespace Exercism.Strain
{
    public static class Strain
    {
        public static IEnumerable<T> Keep<T>(this IEnumerable<T> source, Predicate<T> keep)
        {
            foreach (var item in source)
            {
                if (keep(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Discard<T>(this IEnumerable<T> source, Predicate<T> discard)
        {
            foreach (var item in source)
            {
                if (!(discard(item)))
                {
                    yield return item;
                }
            }
        }
    }
}