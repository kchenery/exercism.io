using System;
using System.Collections.Generic;

namespace Exercism.PrimeFactors
{
    public static class PrimeFactors
    {
        private static List<long> FoundPrimes = new List<long> { 2, 3 };

        public static long[] For(long valueToFactor)
        {
            List<long> primeFactors = new List<long>();

            /* Loop over the existing found primes to see if they work */
            for (int x = 0; x < FoundPrimes.Count; x++)
            {
                long prime = FoundPrimes[x];

                while (valueToFactor % prime == 0)
                {
                    primeFactors.Add(prime);
                    valueToFactor /= prime;
                }
            }

            for (long i = FoundPrimes[FoundPrimes.Count - 1]; i <= valueToFactor; i++)
            {
                if (IsPrime(i))
                {
                    while (valueToFactor % i == 0)
                    {
                        primeFactors.Add(i);
                        valueToFactor /= i;
                    }
                }
            }

            return primeFactors.ToArray();
        }

        private static bool IsPrime(long prime)
        {
            if (prime == 1)
            {
                return false;
            }

            if(FoundPrimes.Contains(prime))
            {
                return true;
            }

            if (prime % 2 == 0)
            {
                return false;
            }



            long factor = prime / 2;
            long startAt = FoundPrimes[FoundPrimes.Count - 1];
 

            
            for (long i = 3; i <= factor; i+=2)
            {
                if ((prime % i) == 0)
                    return false;
            }

            // Found a new prime!
            FoundPrimes.Add(prime);

            return true;
        }

    }
}