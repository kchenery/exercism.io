using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Exercism.SimpleCipher
{
    public class Cipher
    {
        private const int DEFAULT_KEY_LENGTH = 100;
        private const bool ENCODE = true;
        private const bool DECODE = false;
        private const string ALLOWED_KEY_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
        private static Random random = new Random();

        public string Key { get; private set; }

        public Cipher(string key)
        {
            if (!(Regex.IsMatch(key, String.Format("^[{0}]+$", ALLOWED_KEY_CHARACTERS))))
            {
                throw new ArgumentException();
            }

            Key = key;
        }

        public Cipher()
            : this(RandomStrings.Generate(ALLOWED_KEY_CHARACTERS, 100, 100, 1, random).First())
        {
        }

        public string Encode(string message)
        {
            return CodeMessage(message, ENCODE);
        }

        public string Decode(string message)
        {
            return CodeMessage(message, DECODE);
        }

        private string CodeMessage(string message, bool direction)
        {
            var codedMessage = new StringBuilder();

            var index = 0;

            foreach (var letter in message)
            {
                codedMessage.Append(ShiftChar(letter, index, direction));
                index++;
            }

            return codedMessage.ToString();
        }

        private char ShiftChar(char letter, int index, bool isEncode = true)
        {
            index = index % Key.Length; // Wrap around if needed
            int shift = Math.Abs((int)('a' - Key[index]));

            if (!(isEncode))
            {
                shift = 26 - shift;
            }

            return (char)((((int)letter - 97 + shift) % 26) + 97);
        }
    }

    /// <summary>
    /// Random string generator. Taken from: http://stackoverflow.com/questions/4616685/how-to-generate-a-random-string-and-specify-the-length-you-want-or-better-gene
    /// </summary>
    public static class RandomStrings
    {
        public static IEnumerable<string> Generate(string allowedChars,
                                                    int minLength,
                                                    int maxLength,
                                                    int count,
                                                    Random rng)
        {
            char[] chars = new char[maxLength];
            int setLength = allowedChars.Length;

            while (count-- > 0)
            {
                int length = rng.Next(minLength, maxLength + 1);

                for (int i = 0; i < length; ++i)
                {
                    chars[i] = allowedChars[rng.Next(setLength)];
                }

                yield return new string(chars, 0, length);
            }
        }
    }
}