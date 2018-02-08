using System.Collections.Generic;

namespace DataSync.Transformers
{
    public class DriveTransformer
    {
        public List<data_drives> TransformJSONTeamStatsToEF(string eid, Dictionary<string, Drive> drv)
        {
            var drives = new List<data_drives>();
            foreach (string key in drv.Keys)
            {
                var dr = new data_drives()
                {
                    eid_drivenumber = eid + key,
                    drivenumber = key,
                    posteam = drv[key].posteam,
                    qtr = drv[key].qtr,
                    redzone = drv[key].redzone,
                    fds = drv[key].fds,
                    result = drv[key].result,
                    penyds = drv[key].penyds,
                    ydsgained = drv[key].ydsgained,
                    numplays = drv[key].numplays,
                    postime = drv[key].postime,
                    start_qtr = drv[key].Start.qtr,
                    start_time = drv[key].Start.time,
                    start_yrdln = drv[key].Start.yrdln,
                    start_team = drv[key].Start.team,
                    end_qtr = drv[key].End.qtr,
                    end_time = drv[key].End.time,
                    end_yrdln = drv[key].End.yrdln,
                    end_team = drv[key].End.team
                };
                drives.Add(dr);
            }
            return drives;
        }
    }
}