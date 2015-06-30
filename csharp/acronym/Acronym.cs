using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism
{
    public static class Acronym
    {
        private static Dictionary<string, string> specialAbbreviations = new Dictionary<string, string>() { { "HyperText", "HT" }, { "metal-oxide", "MO" } };

        public static string Abbreviate(string phrase)
        {
            if (phrase == String.Empty) return String.Empty;

            char[] splitters = new char[] { ' ', '-' };

            var split = phrase.Split(splitters);
            var acronym = "";
            
            foreach(var word in split)
            {
                if (specialAbbreviations.ContainsKey(word))
                {
                    acronym += specialAbbreviations[word];
                }
                else
                {
                    acronym += word.ToUpper()[0];
                }
            }

            return acronym;
        }
    }
}
