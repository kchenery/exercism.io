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
        private static Dictionary<char, char> RnaToDna = new Dictionary<char,char>(){ 
            { 'C', 'G' }, 
            { 'G', 'C' }, 
            { 'A', 'T' }, 
            { 'U', 'A' } 
        };

        public static string OfDna(string Dna)
        {
            return new string(Dna.ToCharArray().Select(x => DnaToRna[x]).ToArray());
        }

        public static string OfRna(string Rna)
        {
            return new string(Rna.ToCharArray().Select(x => RnaToDna[x]).ToArray());
        }
    }
}
