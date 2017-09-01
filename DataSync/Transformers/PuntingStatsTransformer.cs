using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync.Transformers
{
    public class PuntingStatsTransformer
    {
        public List<punting_stats> TransformJSONPuntingToEF(string eid, string location, Dictionary<string, StatsPunting> punting)
        {
            var puntList = new List<punting_stats>();
            if (punting != null)
            {
                foreach (string puntKey in punting.Keys)
                {
                    var punt = new punting_stats()
                    {
                        eid_playerid = eid + "-" + puntKey,
                        playerid = puntKey,
                        home_or_away = location,
                        name = punting[puntKey].name,
                        pts = punting[puntKey].pts,
                        yds = punting[puntKey].yds,
                        avg = punting[puntKey].avg,
                        i20 = punting[puntKey].i20,
                        lng = punting[puntKey].lng
                    };
                    puntList.Add(punt);
                }
            }
            return puntList;
        }
    }
}
