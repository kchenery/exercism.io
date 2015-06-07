using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.Meetup
{
    public enum Schedule
    {
        // Set the value to the first day of the month it could possibly be
        First = 1,
        Second = 8,
        Third = 15,
        Fourth = 22,
        Teenth = 13,
        Last = -1       // -1 = last and we'll start at the end of the month
    }

    public static class Extensions
    {
        public static int GetValue(this Schedule schedule)
        {
            return (int)schedule;
        }

        public static int GetValue(this DayOfWeek dayOfWeek)
        {
            return (int)dayOfWeek;
        }
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
            return GetNthDayFromDOM(dayOfWeek, schedule.GetValue());
        }

        private DateTime GetNthDayFromDOM(DayOfWeek dayOfWeek, int startAt)
        {
            startAt = (startAt > 0 ? startAt : DateTime.DaysInMonth(year, month) - 6);

            DateTime date = new DateTime(year, month, startAt);

            int delta = dayOfWeek.GetValue() - date.DayOfWeek.GetValue();

            return date.AddDays(delta < 0 ? delta + 7 : delta);
        }
    }
}
