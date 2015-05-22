using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.ETL
{
    public static class ETL
    {
        public static Dictionary<string, int> Transform(Dictionary<int, IList<string>> scrabbleInput)
        {
            Dictionary<string, int> scrabbleOutput = new Dictionary<string,int>();

            foreach(var scoreTupple in scrabbleInput)
            {
                var score = scoreTupple.Key;

                foreach(var letter in scoreTupple.Value)
                {
                    scrabbleOutput.Add(letter.ToLower(), score);
                }
            }

            return scrabbleOutput;
        }
    }
}
