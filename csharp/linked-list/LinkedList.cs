using System.Collections.Generic;
using System.Linq;

namespace Exercism.LinkedList
{
    public class Deque<T>
    {
        private LinkedList<T> theList;

        public Deque()
        {
            theList = new LinkedList<T>();
        }

        public void Push(T item)
        {
            theList.AddLast(item);
        }

        public T Pop()
        {
            var item = theList.Last<T>();
            theList.RemoveLast();

            return item;
        }

        public void Unshift(T item)
        {
            theList.AddFirst(item);
        }

        public T Shift()
        {
            var item = theList.First<T>();
            theList.RemoveFirst();

            return item;
        }
    }
}