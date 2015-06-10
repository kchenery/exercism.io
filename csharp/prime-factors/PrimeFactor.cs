using System;
using System.Collections.Generic;

namespace Exercism.PrimeFactors
{
    public static class PrimeFactors
    {
        public static long[] For(long valueToFactor)
        {
            var primeFactors = new List<long>();

            var factor = 2;

            while(valueToFactor > 1)
            {
                if(valueToFactor % factor > 0)
                {
                    factor = factor < 3 ? factor = 3 : factor;

                    do
                    {
                        if (valueToFactor % factor == 0)
                        {
                            break;
                        }

                        factor += 2;
                    } while (factor < valueToFactor);
                }

                valueToFactor /= factor;
                primeFactors.Add(factor);
            }

            return primeFactors.ToArray();
        }

    }
}