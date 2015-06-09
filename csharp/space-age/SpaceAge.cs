using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.SpaceAge
{
    class SpaceAge
    {
        private const double EARTH_YEAR_IN_SECONDS = (60 * 60 * 24 * 365.25);
        private const double MERCURY_TO_EARTH_ORBIT_RATIO = 0.2408467;
        private const double VENUS_TO_EARTH_ORBIT_RATIO = 0.61519726;
        private const double MARS_TO_EARTH_ORBIT_RATIO = 1.8808158;
        private const double JUPITER_TO_EARTH_ORBIT_RATIO = 11.862615;
        private const double SATURN_TO_EARTH_ORBIT_RATIO = 29.447498;
        private const double URANUS_TO_EARTH_ORBIT_RATIO = 84.016846;
        private const double NEPTUNE_TO_EARTH_ORBIT_RATIO = 164.79132;

        public ulong Seconds { get; private set; }


        public SpaceAge(ulong age)
        {
            Seconds = age;
        }

        public double OnMercury()
        {
            return OnEarth() / MERCURY_TO_EARTH_ORBIT_RATIO;
        }

        public double OnVenus()
        {
            return OnEarth() / VENUS_TO_EARTH_ORBIT_RATIO;
        }

        public double OnEarth()
        {
            return Seconds / EARTH_YEAR_IN_SECONDS;
        }

        public double OnMars()
        {
            return OnEarth() / MARS_TO_EARTH_ORBIT_RATIO;
        }

        public double OnSaturn()
        {
            return OnEarth() / SATURN_TO_EARTH_ORBIT_RATIO;
        }

        public double OnJupiter()
        {
            return OnEarth() / JUPITER_TO_EARTH_ORBIT_RATIO;
        }

        public double OnNeptune()
        {
            return OnEarth() / NEPTUNE_TO_EARTH_ORBIT_RATIO;
        }

        public double OnUranus()
        {
            return OnEarth() / URANUS_TO_EARTH_ORBIT_RATIO;
        }
    }
}
