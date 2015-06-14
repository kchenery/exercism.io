using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercism.SimpleCipher
{
    public class Cipher
    {
        private const int DEFAULT_KEY_LENGTH = 100;
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

            Console.WriteLine("Cipher key: {0}", Key);
        }

        public Cipher() : this(RandomStrings.Generate(ALLOWED_KEY_CHARACTERS, 100, 100, 1, random).First())
        {
        }

        public string Encode(string message)
        {
            var encodedMessage = new StringBuilder();
            var index = 0;

            foreach(var letter in message)
            {
                encodedMessage.Append(EncodeShift(letter, index));
                index ++;
            }

            return encodedMessage.ToString();
        }

        public string Decode(string message)
        {
            var decodedMessage = new StringBuilder();
            var index = 0;

            foreach (var letter in message)
            {
                decodedMessage.Append(DecodeShift(letter, index));
                index++;
            }

            return decodedMessage.ToString();
        }

        private char EncodeShift(char letter, int index)
        {
            index = index % Key.Length; // Wrap around if needed
            int shift = Math.Abs((int)('a' - Key[index]));

            return (char)((((int)letter - 97 + shift) % 26) + 97);
        }

        private char DecodeShift(char letter, int index)
        {
            index = index % Key.Length; // Wrap around if needed
            int shift = 26 - Math.Abs((int)('a' - Key[index]));

            return (char)((((int)letter - 97 + shift) % 26) + 97);
        }
    }

    public static class RandomStrings {
    
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
