using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.PigLatin
{
    public enum PigLatinRule
    {
        Vowel,
        SingleConsonent,
        CombinedConsonent
    }

    public static class PigLatin
    {
        public static Dictionary<string, PigLatinRule> pigRuleList = new Dictionary<string, PigLatinRule>() {
            {"sch", PigLatinRule.CombinedConsonent},
            {"thr", PigLatinRule.CombinedConsonent},
            {"th", PigLatinRule.CombinedConsonent},
            {"?qu", PigLatinRule.CombinedConsonent},
            {"qu", PigLatinRule.CombinedConsonent},
            {"ch", PigLatinRule.CombinedConsonent},
            {"yt", PigLatinRule.Vowel},
            {"xr", PigLatinRule.Vowel},
            {"a", PigLatinRule.Vowel},
            {"e", PigLatinRule.Vowel},
            {"i", PigLatinRule.Vowel},
            {"o", PigLatinRule.Vowel},
            {"u", PigLatinRule.Vowel}
        };

        public static string Translate(string message)
        {
            return String.Join(" ", message.Split(' ').Select(x => PigLatinify(x))).Trim();
        }

        private static string PigLatinify(string word)
        {
            word = word.ToLower();
            PigLatinRule ruleToApply = PigLatinRule.SingleConsonent;
            string lettersToSwitch = "";

            foreach (var pig in pigRuleList.OrderBy(kvp => kvp.Key))
            {
                if (pig.Key == "?qu") // Must be a better way to do this
                {
                    if (word.Right(word.Length - 1).StartsWith("qu"))
                    {
                        ruleToApply = pig.Value;
                        lettersToSwitch = word.Substring(0, 3);
                    }
                }
                else if (word.StartsWith(pig.Key))
                {
                    ruleToApply = pig.Value;
                    lettersToSwitch = pig.Key;
                }
            }

            string startsWith;

            switch (ruleToApply)
            {
                case PigLatinRule.Vowel:
                    return String.Join("", word, "ay");

                case PigLatinRule.CombinedConsonent:
                    startsWith = word.Substring(0, lettersToSwitch.Length);
                    return String.Join("", word.Right(word.Length - lettersToSwitch.Length), startsWith, "ay");

                case PigLatinRule.SingleConsonent:
                    startsWith = word.Substring(0, 1);
                    return String.Join("", word.Right(word.Length - 1), startsWith, "ay");
            }

            return word;
        }
    }

    public static class StringExtensions
    {
        public static string Right(this string sValue, int iMaxLength)
        {
            //Check if the value is valid
            if (string.IsNullOrEmpty(sValue))
            {
                //Set valid empty string as string could be null
                sValue = string.Empty;
            }
            else if (sValue.Length > iMaxLength)
            {
                //Make the string no longer than the max length
                sValue = sValue.Substring(sValue.Length - iMaxLength, iMaxLength);
            }

            //Return the string
            return sValue;
        }

        public static bool StartsWithAny(this string word, IEnumerable<string> stringList)
        {
            foreach(var value in stringList)
            {
                if(word.StartsWith(value))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool StartsWithAny(this string word, Dictionary<string, PigLatinRule> stringList)
        {
            foreach (var value in stringList)
            {
                if (word.StartsWith(value.Key))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
