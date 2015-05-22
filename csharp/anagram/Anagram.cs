using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.anagram
{
    public class Anagram
    {
        private string anagram;

        public Anagram(string anagram)
        {
            this.anagram = anagram;
        }

        public string[] Match(string[] wordList)
        {
            List<string> results = new List<string>();

            foreach(var word in wordList.ToList())
            {
                if (IsAnagramPair(word, anagram))
                {
                    results.Add(word);
                }
            }

            return results.ToArray();
        }

        private bool IsAnagramPair(string source, string word)
        {
            var sortedWord = SortedWordCharacters(word.ToLower());
            var sortedAnagram = SortedWordCharacters(source.ToLower());

            bool isAnagram = sortedWord.Equals(sortedAnagram);
            bool isSameWord = source.ToLower().Equals(word.ToLower());

            return isAnagram && !isSameWord;
        }

        private string SortedWordCharacters(string word)
        {
            var characters = word.ToArray();
            Array.Sort(characters);
            return new String(characters);
        }
    }
}
