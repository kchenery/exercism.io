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

            // Count the non matching characters by generating a range of values for the length of the string
            // and using Linq to do the count.
            return Enumerable.Range(0, firstSequence.Length)
                .Count(i => firstSequence[i] != secondSequence[i]);
        }
    }
}