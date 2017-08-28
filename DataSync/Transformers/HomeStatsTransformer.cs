using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync.Transformers
{
    public class HomeStatsTransformer
    {
        public home_team TransformJSONHometoEF(string eid, string location, Home home)
        {
            var hme = new home_team()
            {
                eid = eid,
                abbr = home.abbr,
                players = home.players,
                team_to = home.to,
                score_1 = home.score["1"],
                score_2 = home.score["2"],
                score_3 = home.score["3"],
                score_4 = home.score["4"],
                score_5 = home.score["5"],
                score_t = home.score["T"]
            };
            return hme;
        }
    }
}
