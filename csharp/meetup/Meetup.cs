using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.Meetup
{
    enum Schedule
    {
        // Set the value to the first day of the month it could possibly be
        First = 1,
        Second = 8,
        Third = 15,
        Fourth = 22,
        Teenth = 13,
        Last = -1       // -1 = last and we'll start at the end of the month
    }

    class Meetup
    {
        private int month;
        private int year;

        public Meetup(int month, int year)
        {
            this.month = month;
            this.year = year;
        }

        public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
        {
            return GetNthDayFromDOM(dayOfWeek, (int)schedule);
        }

        private DateTime GetNthDayFromDOM(DayOfWeek dayOfWeek, int startAt)
        {
            DateTime date = new DateTime(year, month, 1);
            int endAt = startAt + 6;

            if (startAt < 0)
            {
                // Finding the last day in the month, so reverse the approach
                endAt = date.AddMonths(1).AddDays(-1).Day;  // Find the end of the month
                startAt = endAt - 6;
            }

            for (int day = startAt; day <= endAt; day++)
            {
                date = new DateTime(year, month, day);

                if (date.DayOfWeek == dayOfWeek)
                {
                    return date;
                }
            }

            return date;
        }

    }
}
