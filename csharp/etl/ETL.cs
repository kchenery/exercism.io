using System.Collections.Generic;
using System.Linq;

namespace Exercism.ETL
{
    public static class ETL
    {
        public static Dictionary<string, int> Transform(Dictionary<int, IList<string>> scrabbleInput)
        {
            return scrabbleInput
                .SelectMany(orig => orig.Value, (originalKey, originalValue) => new { NewKey = originalValue.ToLower(), NewValue = originalKey.Key })
                .ToDictionary(letter => letter.NewKey, score => score.NewValue);
        }
    }
}