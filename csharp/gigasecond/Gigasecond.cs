using System;

namespace Exercism.Gigasecond
{
    public static class Gigasecond
    {
        private const int GIGASECONDS = 1000000000;

        public static DateTime Date(DateTime from)
        {
            return from.AddSeconds(GIGASECONDS);
        }
    }
}