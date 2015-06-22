using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.SecretHandshake
{
    public static class SecretHandshake
    {
        private static Dictionary<int, string> _handshakeMoves = new Dictionary<int, string>() { 
            {1, "wink" },
            {2, "double blink"},
            {4, "close your eyes"},
            {8, "jump"},
            {16, "reverse"}
        };

        public static IEnumerable<string> Commands(int code)
        {
            List<string> handshake = new List<string>();

            for (int mod = 16; mod >= 1; mod /= 2)
            {
                if (code / mod >= 1)
                {
                    code -= mod;
                    handshake.Add(_handshakeMoves[mod]);
                }

                if (code == 0)
                    break;
            }

            // Seems counter intuitive.  But we read from left to right and answer is really right to left.
            if (handshake.Contains("reverse"))
            {
                handshake.Remove("reverse");
            }
            else
            {
                handshake.Reverse();
            }

            return handshake;
        }

    }
}
