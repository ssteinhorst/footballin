using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync.Transformers
{
    public class PuntretStatsTransformer
    {
        public List<puntret_stats> TransformJSONPuntretToEF(string eid, string location, Dictionary<string, StatsPuntret> puntrets)
        {
            var puntretList = new List<puntret_stats>();
            if (puntrets != null)
            {
                foreach (string puntretkey in puntrets.Keys)
                {
                    var puntret = new puntret_stats()
                    {
                        eid_playerid = eid + "-" + puntretkey,
                        playerid = puntretkey,
                        home_or_away = location,
                        name = puntrets[puntretkey].name,
                        ret = puntrets[puntretkey].ret,
                        avg = puntrets[puntretkey].avg,
                        tds = puntrets[puntretkey].tds,
                        lng = puntrets[puntretkey].lng,
                        lngtd = puntrets[puntretkey].lngtd
                    };
                    puntretList.Add(puntret);
                }
            }
            return puntretList;
        }
    }
}
