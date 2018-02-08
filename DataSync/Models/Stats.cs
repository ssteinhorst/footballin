using System.Collections.Generic;

namespace DataSync
{
    public class Stats
    {
        public Dictionary<string, StatsPassing> passing { get; set; }
        public Dictionary<string, StatsRushing> rushing { get; set; }
        public Dictionary<string, StatsReceiving> receiving { get; set; }
        public Dictionary<string, StatsFumbles> fumbles { get; set; }
        public Dictionary<string, StatsKicking> kicking { get; set; }
        public Dictionary<string, StatsPunting> punting { get; set; }
        public Dictionary<string, StatsKickret> kickret { get; set; }
        public Dictionary<string, StatsPuntret> puntret { get; set; }
        public Dictionary<string, StatsDefense> defense { get; set; }
        public StatsTeam team { get; set; }
    }
}