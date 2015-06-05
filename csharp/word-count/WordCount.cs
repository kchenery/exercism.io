using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Exercism.word_count
{
    public static class Phrase
    {
        public static Dictionary<string, int> WordCount(string phrase)
        {
            Dictionary<string, int> results = new Dictionary<string,int>();

            Match match = Regex.Match(phrase.ToLower(), @"\w+'\w+|\w+");

            while(match.Success)
            {
                string word = match.Value;

                results[word] = results.ContainsKey(word) ? results[word] + 1 : 1;

                match = match.NextMatch();
            }

            return results;
        }
    }
}
