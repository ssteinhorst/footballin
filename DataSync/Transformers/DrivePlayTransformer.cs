using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync.Transformers
{
    public class DrivePlayTransformer
    {
        public List<drive_plays> TransformDrivePlaysJSONtoEF(string eid, string drivenum, Dictionary<string, Play> playstats)
        {
            var plays = new List<drive_plays>();
            foreach(string key in playstats.Keys)
            {
                var play = new drive_plays()
                {
                    eid_drivenum_playnum = eid + "-" + drivenum + "-" + key,
                    drive_num = drivenum,
                    playnum = key,
                    sp = playstats[key].sp,
                    qtr = playstats[key].qtr,
                    down = playstats[key].down,
                    time = playstats[key].time,
                    yrdln = playstats[key].yrdln,
                    ydstogo = playstats[key].ydstogo,
                    ydsnet = playstats[key].ydsnet,
                    posteam = playstats[key].posteam,
                    desc = playstats[key].desc,
                    note = playstats[key].note
                };
                plays.Add(play);
            }

            return plays;
        }
    }
}
