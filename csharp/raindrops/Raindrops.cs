using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Exercism.Raindrops
{
    public static class Raindrops
    {
        private static Dictionary<long, string> rainDrops = new Dictionary<long, string> { { 3, "Pling" }, { 5, "Plang" }, { 7, "Plong" } };

        public static String Convert(int number)
        {
            StringBuilder drops = new StringBuilder();

            foreach (var factor in PrimeFactors.For(number).Distinct())
            {
                drops.Append(FindDrop(factor));
            }

            String rain = drops.ToString();

            return (rain == String.Empty) ? number.ToString() : rain;
        }

        private static String FindDrop(long factor)
        {
            String drop = String.Empty;
            rainDrops.TryGetValue(factor, out drop);

            return drop;
        }
    }

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

                primeFactors.Add(factor);
                valueToFactor /= factor;
            }

            return primeFactors.ToArray();
        }

    }
}
