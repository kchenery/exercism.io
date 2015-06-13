using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.Trinary
{
    public static class Trinary
    {
        private static char[] VALID_TRINARY_LIST = { '0', '1', '2' };

        public static int ToDecimal(string trinary)
        {
            int total = 0;
            int factor = 1;
            int position = trinary.Length - 1;

            do
            {
                var tri = trinary[position];

                if (!(VALID_TRINARY_LIST.Contains(tri)))
                {
                    return 0;
                }

                total += ((int)Char.GetNumericValue(tri) * factor);

                factor *= 3;
                position--;
            } while (position >= 0);

            return total;
        }
    }
}
