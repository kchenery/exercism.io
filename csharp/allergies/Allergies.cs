using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercism.Allergies
{
    [Flags]
    public enum Allergy
    {
        None = 0,
        Eggs = 1,
        Peanuts = 2,
        Shellfish = 4,
        Strawberries = 8,
        Tomatoes = 16,
        Chocolate = 32,
        Pollen = 64,
        Cats = 128
    }

    public class Allergies
    {
        private int allergyFlags;

        public Allergies(int allergyFlags)
        {
            this.allergyFlags = allergyFlags;
        }

        public bool AllergicTo(String allergy)
        {
            return EnumUtils.GetValues<Allergy>()
                .Where(x => (allergyFlags & (int)x) > 0)
                .Select(x => x.ToString().ToLower())
                .Contains(allergy);
        }

        public List<string> List()
        {
            return EnumUtils.GetValues<Allergy>()
                .Where(x => (allergyFlags & (int)x) > 0)
                .Select(x => x.ToString().ToLower())
                .ToList();
        }
    }

    public static class EnumUtils
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}