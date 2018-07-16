using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightedTeamsGenerator.Models
{
    public class Player
    {
        public string name { get; set; }
        public int value { get; set; }

        public override bool Equals(object obj)
        {
            Player other = obj as Player;
            return other != null
                && (name.Equals(other.name))
                && value == other.value;
        }

        //FIX THIS BY COMBINING TWO TEAMS INTO ONE EASY FIX
        public override int GetHashCode()
        {
            return name.GetHashCode() + value.GetHashCode();
        }
    }

    public class Team
    {
        public string id { get; set; }
        public List<Player> players { get; set; }
        public int value { get; set; }

        public Team (List<Player> list, string id)
        {
            this.id = id;
            players = list;
            value = 0;
            foreach (var item in list)
            {
                value += item.value;
            }
        }
    }

    public class TwoTeam
    {
        public Team team1 { get; set; }
        public Team team2 { get; set; }
        public int team1Value { get; set; }
        public int team2Value { get; set; }
        public int difference { get; set; }

        public override bool Equals(object obj)
        {
            TwoTeam other = obj as TwoTeam;
            return other != null
                && (GetTeamName().Equals(other.GetTeamName())
                || GetTeamName().Equals(other.GetTeamNameOtherWayAround())
                || GetTeamNameOtherWayAround().Equals(other.GetTeamName()));
        }

        //FIX THIS BY COMBINING TWO TEAMS INTO ONE EASY FIX
        public override int GetHashCode()
        {
            return GetTeamName().GetHashCode();
        }

        public string GetTeamName()
        {
            string teamName1 = "";
            string teamName2 = "";

            foreach (var player in team1.players.OrderBy(p => p.name))
            {
                teamName1 += player.name;
            }

            foreach (var player in team2.players.OrderBy(p => p.name))
            {
                teamName2 += player.name;
            }

            if(string.Compare(teamName1, teamName2) < 0)
            {
                return teamName1 + teamName2;
            }
            else
            {
                return teamName2 + teamName1;
            }
        }

        public string GetTeamNameOtherWayAround()
        {
            string teamName = "";

            foreach (var player in team2.players.OrderBy(p => p.name))
            {
                teamName += player.name;
            }

            foreach (var player in team1.players.OrderBy(p => p.name))
            {
                teamName += player.name;
            }

            return teamName;
        }
    }
}
