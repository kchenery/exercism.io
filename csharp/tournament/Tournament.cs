using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.Tournament
{
    public class Tournament
    {
        private List<Team> tournamentTable = new List<Team>();

        private string GetTable()
        {
            tournamentTable.Sort();

            string table = TeamResultLine.FormatResultLine("Team", "MP", "W", "D", "L", "P");
                
            return String.Concat(table, String.Concat(tournamentTable));
        }

        private void ParseResultLine(string rawResult)
        {
            var splits = rawResult.Split(';');

            if (splits.Length != 3) return;

            var home = splits[0];
            var away = splits[1];
            var result = splits[2];

            if (result != "win" && result != "loss" && result != "draw") return;

            AddResult(home, away, result);
        }

        private void AddResult(string home, string away, string result)
        {
            var homeTeam = tournamentTable.Where(x => x.Name == home).FirstOrDefault();
            if (homeTeam == null)
            {
                homeTeam = new Team(home);
                tournamentTable.Add(homeTeam);
            }

            var awayTeam = tournamentTable.Where(x => x.Name == away).FirstOrDefault();
            if (awayTeam == null)
            {
                awayTeam = new Team(away);
                tournamentTable.Add(awayTeam);
            }

            switch(result)
            {
                case "win":
                    homeTeam.Wins++;
                    awayTeam.Losses++;
                    break;
                case "loss":
                    homeTeam.Losses++;
                    awayTeam.Wins++;
                    break;
                case "draw":
                    homeTeam.Draws++;
                    awayTeam.Draws++;
                    break;
                default: break;
            }
        }

        public static void Tally(MemoryStream source, MemoryStream table)
        {
            var tournament = new Tournament();
            using (var reader = new StreamReader(source))
            {
                while(reader.Peek() > 0)
                {
                    tournament.ParseResultLine(reader.ReadLine());
                }
            }

            using (var writer = new StreamWriter(table))
            {
                writer.Write(tournament.GetTable());
            }
        }
    }

    public class Team : IComparable
    {
        private static readonly int PointsForWin = 3;
        private static readonly int PointsForDraw = 1;
        private static readonly int PointsForLoss = 0;

        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public int MatchesPlayed
        {
            get
            {
                return Wins + Losses + Draws;
            }
        }

        public int Points
        {
            get {
                return (Wins * PointsForWin) + (Losses * PointsForLoss) + (Draws * PointsForDraw);
            }
        }

        public Team(string name)
        {
            Name = name;
            Wins = 0;
            Losses = 0;
            Draws = 0;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return -1;

            Team otherTeam = obj as Team;

            if (this.Points > otherTeam.Points) return -1;
            else if (this.Points == otherTeam.Points)
            {
                if (this.Wins > otherTeam.Wins) return -1;
                else if (this.Wins == otherTeam.Wins)
                {
                    return String.Compare(this.Name, otherTeam.Name, true);
                }
            }
            
            return 1;
        }

        public override string ToString()
        {
            return TeamResultLine.FormatResultLine(this);
        }
    }

    public static class TeamResultLine
    {
        private static readonly int TeamNameLength = 31;
        private static readonly int PointsLength = 3;

        public static string FormatResultLine(string name, string played, string wins, string draws, string losses, string points)
        {
            return String.Format("{0}|{1} |{2} |{3} |{4} |{5}\r\n",
                name.Trim().PadRight(TeamNameLength),
                played.Trim().PadLeft(PointsLength),
                wins.Trim().PadLeft(PointsLength),
                draws.Trim().PadLeft(PointsLength),
                losses.Trim().PadLeft(PointsLength),
                points.Trim().PadLeft(PointsLength)
                );
        }

        public static string FormatResultLine(Team team)
        {
            return FormatResultLine(team.Name, team.MatchesPlayed.ToString(), team.Wins.ToString(), team.Draws.ToString(), team.Losses.ToString(), team.Points.ToString());
        }
    }
}
