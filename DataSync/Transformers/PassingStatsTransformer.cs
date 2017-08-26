using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync.Services
{
    public class PassingStatsTransformer
    {
        public List<passing_stats> TransformJSONPassingToEF(string eid, Dictionary<string, StatsPassing> sPass)
        {
            var ps = new List<passing_stats>();
            foreach(string passKey in sPass.Keys)
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
                ps.Add(pass);
            }
            return ps;
        }
    }
}
