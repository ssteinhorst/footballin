using System.Collections.Generic;

namespace DataSync.Transformers
{
    public class KickingStatsTransformer
    {
        public List<kicking_stats> TransformJSONKickingToEF(string eid, string location, Dictionary<string, StatsKicking> kicking)
        {
            var kickList = new List<kicking_stats>();
            if (kicking != null)
            {
                foreach (string kickKey in kicking.Keys)
                {
                    var kick = new kicking_stats()
                    {
                        eid_playerid = eid + "-" + kickKey,
                        playerid = kickKey,
                        home_or_away = location,
                        name = kicking[kickKey].name,
                        fgm = kicking[kickKey].fgm,
                        fga = kicking[kickKey].fga,
                        fgyds = kicking[kickKey].fgyds,
                        totpfg = kicking[kickKey].totpfg,
                        xpmade = kicking[kickKey].xpmade,
                        xpmissed = kicking[kickKey].xpmissed,
                        xpa = kicking[kickKey].xpa,
                        xpb = kicking[kickKey].xpb,
                        xptot = kicking[kickKey].xptot
                    };
                    kickList.Add(kick);
                }
            }
            return kickList;
        }
    }
}