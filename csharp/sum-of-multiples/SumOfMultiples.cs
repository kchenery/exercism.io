using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism
{
    public class SumOfMultiples
    {
        private List<int> _multiples;

        public SumOfMultiples(List<int> multiples)
        {
            _multiples = multiples;
        }

        public SumOfMultiples() : this(new List<int> { 3, 5 })
        {
        }

        public int To(int upto)
        {
            return To(1, upto);
        }

        private int To(int current, int upto)
        {
            if (current == upto)
                return 0;
            else
                return (IsMultiple(current) ? current : 0) + To(current + 1, upto);
        }

        private bool IsMultiple(int value)
        {
            foreach (var multiple in _multiples)
            {
                if (value % multiple == 0)
                    return true;
            }

            return false;
        }

    
    }
}
