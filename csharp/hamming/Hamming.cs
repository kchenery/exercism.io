using System;
using System.Linq;

namespace Exercism.hamming
{
    public static class Hamming
    {
        public static int Compute(string firstSequence, string secondSequence)
        {
            if (firstSequence.Length != secondSequence.Length)
            {
                throw new ArgumentException("Sequences must be of the same length to compute Hamming");
            }

            int result = 0;

            for (int i = 0; i < firstSequence.Length; i++)
            {
                result += firstSequence[i] != secondSequence[i] ? 1 : 0;
            }

            return result;
        }
    }
}