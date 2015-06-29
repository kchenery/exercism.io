using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.Wordy
{
    public static class WordProblem
    {
        public static int Solve(string phrase)
        {
            if (!phrase.StartsWith("What is"))
            {
                throw new ArgumentException();
            }

            var phraseTokens = phrase.Substring(7).Replace("?", "").Split((" ").ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int b = 0;
            string op = null;
            int total = 0;

            for (int i = 0; i < phraseTokens.Length; i++)
            {
                if (op == null)
                {
                    int.TryParse(phraseTokens[i], out total);
                    i++;
                }

                op = phraseTokens[i];

                if (op == "cubed")
                {
                    throw new ArgumentException();
                }

                if (op == "multiplied" || op == "divided")
                {
                    // jump over by
                    i += 2;
                }
                else
                {
                    i++;                    
                }

                int.TryParse(phraseTokens[i], out b);

                // action
                if (op == "plus")
                {
                    total += b;
                    
                }
                else if (op == "minus")
                {
                    total -= b;
                }
                else if (op == "multiplied")
                {
                    total *= b;
                }
                else if (op == "divided")
                {
                    total /= b;
                }

                b = 0;
            }


            return total;
        }
    }
}
