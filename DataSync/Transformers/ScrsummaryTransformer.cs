using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync.Transformers
{
    public class ScrsummaryTransformer
    {
        public List<scrsummary_data> ScrsummaryJSONtoEF(string eid, Dictionary<string, ScrSummary> scrsummary)
        {
            var scrList = new List<scrsummary_data>();
            foreach(string key in scrsummary.Keys)
            {
                var scr = new scrsummary_data()
                {
                    eid_scrid = eid + "-" + key,
                    scr_id = key,
                    type = scrsummary[key].type,
                    desc = scrsummary[key].desc,
                    qtr = scrsummary[key].qtr,
                    team = scrsummary[key].team,
                    players = string.Join(",", scrsummary[key].players.Select(x => x.Value).ToArray())
            };
                scrList.Add(scr);
            }
            return scrList;
        }
    }
}
