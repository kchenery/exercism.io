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
            _series = series;
        }

        public int[][] Slices(int size)
        {
            if (size > _series.Length)
            {
                throw new ArgumentException("Slice size is larger than the length of the Series");
            }

            List<int[]> slices = new List<int[]>();

            for (int i = 0; i < _series.Length - size + 1; i++)
            {
                List<int> slice = new List<int>();

                for(int j = i; j < i + size; j++)
                {
                    int value;
                 
                    if (int.TryParse(_series[j].ToString(), out value))
                    {
                        slice.Add(value);
                    }
                    else{
                        throw new Exception("Invalid character found");
                    }
                }

                slices.Add(slice.ToArray());
            }

            return slices.ToArray<int[]>();
        }
    }
}
