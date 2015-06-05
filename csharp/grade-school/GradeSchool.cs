using System.Collections.Generic;

namespace Exercism.GradeSchool
{
    public class School
    {
        public Dictionary<int, List<string>> Roster { get; private set; }

        public School()
        {
            Roster = new Dictionary<int, List<string>>();
        }

        public void Add(string pupil, int grade)
        {
            if (!Roster.ContainsKey(grade))
            {
                Roster[grade] = new List<string>(); ;
            }

            Roster[grade].Add(pupil);
            Roster[grade].Sort();
        }

        public List<string> Grade(int grade)
        {
            if (Roster.ContainsKey(grade))
                return Roster[grade];

            return new List<string>();
        }
    }
}