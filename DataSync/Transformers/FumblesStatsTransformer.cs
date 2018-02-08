using System.Collections.Generic;

namespace DataSync.Transformers
{
    public class FumblesStatsTransformer
    {
        public List<fumbles_stats> TransformJSONFumblesToEF(string eid, string location, Dictionary<string, StatsFumbles> sFum)
        {
            var fumbList = new List<fumbles_stats>();
            if (sFum != null)
            {
                foreach (string fumKey in sFum.Keys)
                {
                    var fum = new fumbles_stats()
                    {
                        eid_playerid = eid + "-" + fumKey,
                        playerid = fumKey,
                        name = sFum[fumKey].name,
                        tot = sFum[fumKey].tot,
                        rcv = sFum[fumKey].rcv,
                        trcv = sFum[fumKey].trcv,
                        yds = sFum[fumKey].yds,
                        lost = sFum[fumKey].lost,
                        home_or_away = location
                    };
                    fumbList.Add(fum);
                }
            }
            return fumbList;
        }
    }
}