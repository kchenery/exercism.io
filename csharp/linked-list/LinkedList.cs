using System.Collections.Generic;
using System.Linq;

namespace Exercism.LinkedList
{
    public class Deque<T> : LinkedList<T>
    {
        
    }
    
    public static class LinkedListExtensions
    {
        public static void Push<T>(this LinkedList<T> list, T item)
        {
            list.AddLast(item);
        }

        public static T Shift<T>(this LinkedList<T> list)
        {
            T item = list.First<T>();
            list.RemoveFirst();

            return item;
        }

        public static T Pop<T>(this LinkedList<T> list)
        {
            T item = list.Last<T>();
            list.RemoveLast();

            return item;
        }

        public static void Unshift<T>(this LinkedList<T> list, T item)
        {
            list.AddFirst(item);
            
        }
    }
}