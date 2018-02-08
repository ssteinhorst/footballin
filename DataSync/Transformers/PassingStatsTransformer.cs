using System.Collections.Generic;

namespace DataSync.Transformers
{
    public class PassingStatsTransformer
    {
        public List<passing_stats> TransformJSONPassingToEF(string eid, string location, Dictionary<string, StatsPassing> sPass)
        {
            var ps = new List<passing_stats>();
            if (sPass != null)
            {
                foreach (string passKey in sPass.Keys)
                {
                    var pass = new passing_stats();
                    pass.eid_playerid = eid + "-" + passKey;
                    pass.playerid = passKey;
                    pass.att = sPass[passKey].att;
                    pass.cmp = sPass[passKey].cmp;
                    pass.ints = sPass[passKey].ints;
                    pass.name = sPass[passKey].name;
                    pass.tds = sPass[passKey].tds;
                    pass.att = sPass[passKey].att;
                    pass.twopta = sPass[passKey].twopta;
                    pass.twoptm = sPass[passKey].twoptm;
                    pass.yds = sPass[passKey].yds;
                    pass.home_or_away = location;
                    ps.Add(pass);
                }
            }
            return ps;
        }
    }
}