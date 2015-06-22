using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.difference_of_squares
{
    public class Squares
    {
        int _square;

        public Squares(int square)
        {
            if (square < 0)
            {
                throw new ArgumentException("Value of square must be positive");
            }
            _square = square;
        }

        public int SumOfSquares()
        {
            return Enumerable.Range(0, _square + 1).Select(i => i * i).Sum();
        }

        public int SquareOfSums()
        {
            int sum = Enumerable.Range(0, _square + 1).Sum();
            return (sum * sum);
        }

        public int DifferenceOfSquares()
        {
            return SquareOfSums() - SumOfSquares();
        }
    }
}
