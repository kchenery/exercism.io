using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercism.Luhn
{
    public class Luhn
    {
        private long luhnNumber;

        public long Number
        {
            get
            {
                return luhnNumber;
            }
        }

        public int CheckDigit
        {
            get
            {
                return (int)(Number % 10);
            }
        }

        public IEnumerable<int> Addends
        {
            get
            {
                return GetAddends();
            }
        }

        public int Checksum
        {
            get
            {
                return Addends.Sum();
            }
        }

        public bool Valid
        {
            get
            {
                return Checksum % 10 == 0;
            }
        }

        public Luhn(long luhn)
        {
            luhnNumber = luhn;
        }

        public static long Create(long luhn)
        {
            Luhn newLuhn = new Luhn(luhn * 10);

            return newLuhn.Number + (newLuhn.Valid ? 0 : 10 - newLuhn.Checksum % 10);
        }

        private IEnumerable<int> GetAddends()
        {
            Stack<int> Addends = new Stack<int>();

            long number = Number;

            int digits = (int)Math.Floor(Math.Log10(number)) + 1;
            int iteration = 0;

            do
            {
                iteration++;
                int digit = (int)(number % 10);

                if (iteration % 2 == 0)
                {
                    digit *= 2;

                    digit = digit > 9 ? digit - 9 : digit;
                }

                Addends.Push(digit);

                number /= 10;
            } while (number > 0);

            return Addends;
        }
    }
}