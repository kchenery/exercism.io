using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.Accumulate
{
    public static class Accumulator
    {
        public static IEnumerable<T> Accumulate<T>(this IEnumerable<T> source, Func<T, T> accumulation)
        {
            foreach(var item in source)
            {
                yield return accumulation(item);
            }
        }
    }
}
