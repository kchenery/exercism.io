using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.Octal
{
    public static class Octal
    {
        private const int FACTOR = 8;

        public static int ToDecimal(string octal)
        {
            int total = 0;
            int currentFactor = 1;
            int position = octal.Length - 1;

            do
            {
                int octet;

                try {
                    octet = Int32.Parse(octal[position].ToString());

                    if (octet > (FACTOR - 1))
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch {
                    return 0;
                }

                total += octet * currentFactor;
                currentFactor *= FACTOR;
                position--;
            } while (position >= 0);

            return total;
        }
    }
}
