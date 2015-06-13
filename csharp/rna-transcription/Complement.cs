using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.RNATranscription
{
    public static class Complement
    {
        private static Dictionary<char, char> DnaToRna = new Dictionary<char,char>(){
            { 'G', 'C' }, 
            { 'C', 'G' }, 
            { 'T', 'A' }, 
            { 'A', 'U' } 
        };
        private static Dictionary<char, char> RnaToDna
        {
            get { return DnaToRna.ToDictionary(kvp => kvp.Value, kvp => kvp.Key); }
        }

        public static string OfDna(string Dna)
        {
            return String.Concat(Dna.Select(x => DnaToRna[x]));
        }

        public static string OfRna(string Rna)
        {
            return String.Concat(Rna.Select(x => RnaToDna[x]));
        }
    }
}
