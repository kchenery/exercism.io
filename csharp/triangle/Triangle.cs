using System;

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
            if ((a + b) > c && (b + c) > a && (c + a) > b)
            {
                // If all sides are equal its an equilateral triangle
                if (a == b && b == c)
                {
                    return TriangleKind.Equilateral;
                }
                // If two sides are equal its an equilateral triangle
                else if (a == b || b == c || a == c)
                {
                    return TriangleKind.Isosceles;
                }
                // None of the above so it must be a scalene triangle
                else
                {
                    return TriangleKind.Scalene;
                }
            }

            // Wasn't a triangle
            throw new TriangleException();
        }
    }

    // Exception type for an invalid triangle. I would have named it InvalidTriangleException
    public class TriangleException : Exception
    {
    }
}