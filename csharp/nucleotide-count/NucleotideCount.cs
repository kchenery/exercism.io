using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercism.NucleotideCount
{
    internal class DNA
    {
        private string _dna;
        private static readonly char[] _validNucleotides = { 'A', 'T', 'C', 'G' };

        public Dictionary<char, int> NucleotideCounts
        {
            get
            {
                return CalculateNucleotideCounts(_dna);
            }
        }

        public DNA(string dna)
        {
            _dna = dna.ToUpper();
        }

        /// <summary>
        /// Counts the specified nucleotide.
        /// </summary>
        /// <param name="nucleotide">The nucleotide.</param>
        /// <returns></returns>
        /// <exception cref="InvalidNucleotideException"></exception>
        public int Count(char nucleotide)
        {
            try
            {
                return NucleotideCounts[nucleotide];
            }
            catch
            {
                throw new InvalidNucleotideException();
            }
        }

        /* Helper Methods */

        /// <summary>
        /// Calculates the nucleotide counts.
        /// </summary>
        /// <param name="dna">The dna strand to test</param>
        /// <returns></returns>
        private static Dictionary<char, int> CalculateNucleotideCounts(string dna)
        {
            Dictionary<char, int> nucleotideCounts = EmptyNucleotideCount();

            foreach(var nucleotide in dna)
            {
                try
                {
                    nucleotideCounts[nucleotide]++;
                }
                catch
                {
                    throw new InvalidNucleotideException();
                }
            }

            return nucleotideCounts;
        }

        /// <summary>
        /// Generates and returns an empty the nucleotide count.
        /// </summary>
        /// <returns></returns>
        private static Dictionary<char, int> EmptyNucleotideCount()
        {
            Dictionary<char, int> emptyNucleotideCounts = new Dictionary<char, int>();

            foreach (var nucleotide in _validNucleotides)
            {
                emptyNucleotideCounts.Add(nucleotide, 0);
            }

            return emptyNucleotideCounts;
        }
    }

    /// <summary>
    /// Definition for InvalidNucleotideException.
    /// Would normally put this in its own file but keeping it here to make reviewing easier
    /// </summary>
    class InvalidNucleotideException : Exception
    {
    }
}