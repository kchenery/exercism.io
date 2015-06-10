using System;
using System.Linq;
using System.Text;

namespace Exercism.RomanNumerals
{
    public static class RomanNumerals
    {
        public static string ToRoman(this int arabic)
        {
            if (arabic < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            StringBuilder romanNumberals = new StringBuilder();

            int[] decimals = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            string[] romans = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

            while (arabic > 0)
            {
                for (int i = decimals.Count() - 1; i >= 0; i--)
                {
                    if (arabic / decimals[i] >= 1)
                    {
                        romanNumberals.Append(romans[i]);
                        arabic -= decimals[i];
                        break;
                    }
                }
            }

            return romanNumberals.ToString();
        }
    }
}