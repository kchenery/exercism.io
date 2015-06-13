using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.sieve
{
    public static class Sieve
    {
        public static IEnumerable<int> Primes(int upto)
        {
            IEnumerable<int> candidates = Enumerable.Range(2, upto - 1);

            do
            {
                int prime = candidates.First();
                yield return prime;
                candidates = candidates.Where(x => x % prime != 0);
            } while (candidates.Any());
        }
    }
}
