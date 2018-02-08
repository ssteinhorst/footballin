using System.Collections.Generic;

namespace DataSync.Transformers
{
    public class RushingStatsTransformer
    {
        public List<rushing_stats> TransformJSONRushingToEF(string eid, string location, Dictionary<string, StatsRushing> sRush)
        {
            var rs = new List<rushing_stats>();
            if (sRush != null)
            {
                foreach (string rushKey in sRush.Keys)
                {
                    var rush = new rushing_stats();
                    rush.eid_playerid = eid + "-" + rushKey;
                    rush.att = sRush[rushKey].att;
                    rush.lng = sRush[rushKey].lng;
                    rush.lngtd = sRush[rushKey].lngtd;
                    rush.name = sRush[rushKey].name;
                    rush.playerid = rushKey;
                    rush.tds = sRush[rushKey].tds;
                    rush.twopta = sRush[rushKey].twopta;
                    rush.twoptm = sRush[rushKey].twoptm;
                    rush.yds = sRush[rushKey].yds;
                    rush.home_or_away = location;
                    rs.Add(rush);
                }
            }
            return rs;
        }
    }
}