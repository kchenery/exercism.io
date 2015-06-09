using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.TwelveDays
{
    class TwelveDaysSong
    {
        private Dictionary<int, string> TwelveDays = new Dictionary<int, string>();
        private Dictionary<int, string> DayName = new Dictionary<int, string>();
        private readonly string Opening = "On the {0} day of Christmas my true love gave to me";

        public TwelveDaysSong()
        {
            LoadTwelveDays();
        }

        private void LoadTwelveDays()
        {
            TwelveDays.Add(1, "a Partridge in a Pear Tree");
            TwelveDays.Add(2, "two Turtle Doves");
            TwelveDays.Add(3, "three French Hens");
            TwelveDays.Add(4, "four Calling Birds");
            TwelveDays.Add(5, "five Gold Rings");
            TwelveDays.Add(6, "six Geese-a-Laying");
            TwelveDays.Add(7, "seven Swans-a-Swimming");
            TwelveDays.Add(8, "eight Maids-a-Milking");
            TwelveDays.Add(9, "nine Ladies Dancing");
            TwelveDays.Add(10, "ten Lords-a-Leaping");
            TwelveDays.Add(11, "eleven Pipers Piping");
            TwelveDays.Add(12, "twelve Drummers Drumming");

            DayName.Add(1, "first");
            DayName.Add(2, "second");
            DayName.Add(3, "third");
            DayName.Add(4, "fourth");
            DayName.Add(5, "fifth");
            DayName.Add(6, "sixth");
            DayName.Add(7, "seventh");
            DayName.Add(8, "eighth");
            DayName.Add(9, "ninth");
            DayName.Add(10, "tenth");
            DayName.Add(11, "eleventh");
            DayName.Add(12, "twelfth");
        }

        public string Verse(int verseNumber)
        {
            return String.Format("{0}, {1}", String.Format(Opening, DayName[verseNumber]), GenerateVerseLine(verseNumber));
        }

        private string GenerateVerseLine(int verseNumber)
        {
            if (verseNumber == 1)
                return TwelveDays[verseNumber] + ".\n";
            else if (verseNumber == 2)
                return TwelveDays[verseNumber] + ", and " + GenerateVerseLine(verseNumber - 1);
            else
                return TwelveDays[verseNumber] + ", " + GenerateVerseLine(verseNumber - 1);
        }

        public string Verses(int start, int end)
        {
            if (end < start)
            {
                throw new ArgumentException("End verse must come after start verse");
            }

            string verses = "";

            for (int i = start; i <= end; i++)
            {
                verses += Verse(i) + "\n";
            }

            return verses;
        }

        public string Sing()
        {
            return Verses(1, 12);
        }
    }
}
