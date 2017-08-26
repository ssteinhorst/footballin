using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync.Transformers
{
    public class KickretStatsTransformer
    {
        public List<kickret_stats> TransformJSONKickretToEF(string eid, string location, Dictionary<string, StatsKickret> sKickret)
        {
            var kickretList = new List<kickret_stats>();
            foreach(string retKey in sKickret.Keys)
            {
                var kret = new kickret_stats()
                {
                    eid_playerid = eid + "-" + retKey,
                    playerid = retKey,
                    home_or_away = location,
                    name = sKickret[retKey].name,
                    ret = sKickret[retKey].ret,
                    avg = sKickret[retKey].avg,
                    tds = sKickret[retKey].tds,
                    lng = sKickret[retKey].lng,
                    lngtd = sKickret[retKey].lngtd
                };
                kickretList.Add(kret);
            }
            return kickretList;
        }
    }
}
