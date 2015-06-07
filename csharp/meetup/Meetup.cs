using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.Meetup
{
    enum Schedule
    {
        First,
        Second,
        Third,
        Fourth,
        Last,
        Teenth
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
            DateTime day;

            switch(schedule){
                case Schedule.Teenth:
                    day = GetTeenth(dayOfWeek, month, year);
                    break;

                case Schedule.First:
                    day = GetFirst(dayOfWeek, month, year);
                    break;

                case Schedule.Second:
                    day = GetSecond(dayOfWeek, month, year);
                    break;

                case Schedule.Third:
                    day = GetThird(dayOfWeek, month, year);
                    break;

                case Schedule.Fourth:
                    day = GetFourth(dayOfWeek, month, year);
                    break;

                case Schedule.Last:
                    day = GetLast(dayOfWeek, month, year);
                    break;

                default:
                    day = DateTime.Now;
                    break;
            }

            return day;
        }

        private static DateTime GetTeenth(DayOfWeek dayOfWeek, int month, int year)
        {
            DateTime day = GetFirst(dayOfWeek, month, year);

            if (day.Day > 5)
                return day.AddDays(7);
            else
                return day.AddDays(14);

        }

        private static DateTime GetFirst(DayOfWeek dayOfWeek, int month, int year)
        {
            DateTime date = DateTime.Now;

            for (int day = 1; day < 8; day++)
            {
                date = new DateTime(year, month, day);

                if (date.DayOfWeek == dayOfWeek)
                {
                    return date;
                }
            }

            return date;
        }

        private static DateTime GetLast(DayOfWeek dayOfWeek, int month, int year)
        {
            DateTime date = DateTime.Now;
            int eom = new DateTime(year, month, 1).AddMonths(1).AddDays(-1).Day;

            for (int day = eom; day > (eom - 7); day--)
            {
                date = new DateTime(year, month, day);

                if (date.DayOfWeek == dayOfWeek)
                {
                    return date;
                }
            }

            return date;
        }

        private static DateTime GetSecond(DayOfWeek dayOfWeek, int month, int year)
        {
            return GetFirst(dayOfWeek, month, year).AddDays(7);
        }

        private static DateTime GetThird(DayOfWeek dayOfWeek, int month, int year)
        {
            return GetFirst(dayOfWeek, month, year).AddDays(14);
        }

        private static DateTime GetFourth(DayOfWeek dayOfWeek, int month, int year)
        {
            return GetFirst(dayOfWeek, month, year).AddDays(21);
        }
    }
}
