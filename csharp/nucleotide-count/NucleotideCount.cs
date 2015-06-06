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
            if (!IsValidNucleotide(nucleotide))
            {
                throw new InvalidNucleotideException();
            }

            return NucleotideCounts.Where(c => c.Key == nucleotide).First().Value;
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

            var interimCounts = dna.GroupBy(c => c)
                .OrderBy(g => g.Key)
                .ToDictionary(res => res.Key, res => res.Count());

            foreach (var nucleotideCount in interimCounts)
            {
                nucleotideCounts[nucleotideCount.Key] = nucleotideCount.Value;
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

        /// <summary>
        /// Determines whether the supplied nucleotide is a valid one as listed in
        /// _validNucleotides
        /// </summary>
        /// <param name="nucleotide">The nucleotide to test.</param>
        /// <returns></returns>
        private bool IsValidNucleotide(char nucleotide)
        {
            return _validNucleotides.Contains(nucleotide);
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