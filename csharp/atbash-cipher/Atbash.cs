using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercism.atbash_cipher
{
    public static class Atbash
    {
        private const int CIPHER_PHRASE_SIZE = 5;

        public static string Encode(string unencoded)
        {
            return new string(unencoded.ToCharArray()
                                       .Where(x => Char.IsLetterOrDigit(x))
                                       .Select(x => x.Encode())
                                       .CipherText(5)
                                       .ToArray()
                                );
        }

        private static IEnumerable<char> CipherText(this IEnumerable<char> source, int length)
        {
            int i = 0;
            foreach (var letter in source)
            {
                if (i >= CIPHER_PHRASE_SIZE)
                {
                    yield return ' ';
                    i = 0;
                }

                yield return letter;
                i++;
            }
        }

        private static char Encode(this char letter)
        {
            letter = Char.ToLower(letter);

            if (Char.IsLetter(letter))
            {
                int ascii = (int)letter - 97;
                letter = (char)(25 - ascii + 97);
            }

            return letter;
        }
    }
}