using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.Clock
{
    public class Clock : IEquatable<Clock>
    {
        private int _hour;
        private int _minute;

        public Clock(int hours, int minutes = 0)
        {
            _hour = 0;
            _minute = 0;

            Add((hours * 60 ) + minutes);
        }

        public Clock Add(int minutes)
        {
            _minute += minutes;

            int hours = (_minute / 60);
            _minute -= (hours * 60);

            _hour = (_hour + hours) % 24;

            return this;
        }

        public Clock Subtract(int minutes)
        {
            _minute -= minutes;

            while (_minute < 0)
            {
                _hour--;
                _minute += 60;
            }

            while (_hour < 0)
            {
                _hour += 24;
            }

            return this;
        }

        public override string ToString()
        {
            return String.Format("{0:00}:{1:00}", _hour, _minute);
        }

        public bool Equals(Clock other)
        {
            return (this._hour == other._hour && this._minute == other._minute);
        }
    }
}
