using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.Trinary
{
    public static class Trinary
    {
        private static char[] VALID_TRINARY = { '0', '1', '2' };

        public static int ToDecimal(string trinary)
        {
            int value = 0;
            int factor = (int)Math.Pow(3, trinary.Length - 1);

            foreach(var tri in trinary)
            {
                if (!(VALID_TRINARY.Contains(tri)))
                {
                    return 0;
                }

                value += ((int)Char.GetNumericValue(tri) * factor);
                factor /= 3;
            }

            return value;
        }
    }
}
