using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
