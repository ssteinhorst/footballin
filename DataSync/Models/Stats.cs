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
        //[JsonIgnore]
        //[JsonProperty(Required = Required.Default)]
        //public List<passing_stats> passing_stats { get
        //    {
        //        var passingList = new List<passing_stats>();
        //        foreach(string playerkey in passing.Keys)
        //        {
        //            var pass = new passing_stats();
        //            pass.eid_playerid = eid
        //        }
        //        return passingList;
        //    } }

        public Dictionary<string, StatsRushing> rushing { get; set; }
        public Dictionary<string, StatsReceiving> receiving { get; set; }
        public Dictionary<string, StatsFumbles> fumbles { get; set; }
        public Dictionary<string, StatsKicking> kicking { get; set; }
        public Dictionary<string, StatsPunting> punting { get; set; }
        public Dictionary<string, StatsKickret> kickret { get; set; }

    }
}
