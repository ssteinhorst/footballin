using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync.Transformers
{
    public class ReceivingStatsTransformer
    {
        public List<receiving_stats> TransformJSONReceivingToEF(string eid, string location, Dictionary<string, StatsReceiving> sRec)
        {
            var rs = new List<receiving_stats>();
            foreach (string recKey in sRec.Keys)
            {
                var rec = new receiving_stats()
                {
                    eid_playerid = eid + "-" + recKey,
                    name = sRec[recKey].name,
                    rec = sRec[recKey].rec,
                    yds = sRec[recKey].yds,
                    tds = sRec[recKey].tds,
                    playerid = recKey,
                    lng = sRec[recKey].lng,
                    lngtd = sRec[recKey].lngtd,
                    twopta = sRec[recKey].twopta,
                    twoptm = sRec[recKey].twoptm,
                    home_or_away = location
                };
                rs.Add(rec);
            }
            return rs;
        }
    }
}
