using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.Series
{
    public class Series
    {
        private string _series;

        public Series(string series)
        {
            if(series.Select(c => c).Where(c => !char.IsDigit(c)).Any())
            {
                throw new ArgumentException("Series contains non numeric values");
            }

            _series = series;
        }

        public IEnumerable<IEnumerable<int>> Slices(int size)
        {
            if (size > _series.Length)
            {
                throw new ArgumentException("Slice size is larger than the length of the Series");
            }

            return Enumerable.Range(0, _series.Length - size + 1)
                .Select(i => _series.Substring(i, size).Select(c => int.Parse(c.ToString())));
            
        }
    }
}
