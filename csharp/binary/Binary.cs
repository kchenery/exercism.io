using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.Binary
{
    public static class Binary
    {
        public static int ToDecimal(string binary)
        {
            int total = 0;

            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '1')
                {
                    total += (int)Math.Pow(2, binary.Length - (i + 1));
                }
                else if (binary[i] != '0')
                {
                    return 0;
                }
            }

            return total;
        }
    }
}
