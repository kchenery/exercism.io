using System;
using System.Linq;

namespace Exercism.Triangle
{
    public enum TriangleKind
    {
        Equilateral,
        Isosceles,
        Scalene
    }

    public static class Triangle
    {
        public static TriangleKind Kind(decimal a, decimal b, decimal c)
        {
            // Test its a triangle
            if (IsTriangle(a, b, c))
            {
                decimal[] sides = new decimal[] {a, b, c};

                switch (sides.Distinct().Count())
                {
                    case 1: return TriangleKind.Equilateral;
                    case 2: return TriangleKind.Isosceles;
                    case 3: return TriangleKind.Scalene;
                    default: throw new TriangleException();
                }
            }

            // Wasn't a triangle
            throw new TriangleException();
        }

        private static bool IsTriangle(decimal a, decimal b, decimal c)
        {
            return (a + b > c) && (b + c > a) && (c + a > b);
        }
    }

    // Exception type for an invalid triangle. I would have named it InvalidTriangleException
    public class TriangleException : Exception
    {
    }
}