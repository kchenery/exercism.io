using System;
using System.Linq;
using System.Threading;

namespace Exercism.RobotName
{
    internal class Robot
    {
        public string Name { get; private set; }

        private Random _random = RandomHelper.Instance;

        public Robot()
        {
            Reset();
        }

        public void Reset()
        {
            Name = GenerateNewName();
        }

        private string GenerateNewName()
        {
            return String.Format("{0}{1}", GenerateRandomChars("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 2), GenerateRandomChars("0123456789", 3));
        }

        private string GenerateRandomChars(string validChars, int numberToGenerate)
        {
            return new string(
                Enumerable.Repeat(validChars, numberToGenerate)
                    .Select(s => s[_random.Next(s.Length)])
                    .ToArray()
                );
        }
    }

    public static class RandomHelper
    {
        private static int seedCounter = new Random().Next();

        [ThreadStatic]
        private static Random randomNumberGenerator;

        public static Random Instance
        {
            get
            {
                if (randomNumberGenerator == null)
                {
                    int seed = Interlocked.Increment(ref seedCounter);
                    randomNumberGenerator = new Random(seed);
                }
                return randomNumberGenerator;
            }
        }
    }
}