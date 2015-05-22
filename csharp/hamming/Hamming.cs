using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var first = firstSequence.ToCharArray();
            var second = secondSequence.ToCharArray();

            for (int i = 0; i < first.Length; i++)
            {
                result += first[i] != second[i] ? 1 : 0;
            }

            return result;
        }
    }
}
