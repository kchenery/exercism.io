using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.hexadecimal
{
    public static class Hexadecimal
    {
        public static Dictionary<char, int> HexValues = new Dictionary<char,int> {
            {'0', 0}, 
            {'1', 1},
            {'2', 2},
            {'3', 3},
            {'4', 4},
            {'5', 5},
            {'6', 6},
            {'7', 7},
            {'8', 8},
            {'9', 9},
            {'a', 10},
            {'b', 11},
            {'c', 12},
            {'d', 13},
            {'e', 14},
            {'f', 15},
        };

        public static int ToDecimal(string hexString)
        {
            hexString = new string(hexString.ToLower().Reverse().ToArray());

            int depth = 0;
            int value = 0;
            int total = 0;

            foreach(var letter in hexString)
            {
                if(!TryParseHexValue(letter, depth, out value))
                {
                    total = 0;
                    break;
                }

                total += value;
                depth++;
            }

            return total;
        }

        private static bool TryParseHexValue(char letter, int depth, out int value)
        {
            value = 0;
            if (!HexValues.ContainsKey(letter)) return false;

            int factor = (int)Math.Pow(16, depth);
            value = (factor * HexValues[letter]);
            return true;
        }
    }
}
