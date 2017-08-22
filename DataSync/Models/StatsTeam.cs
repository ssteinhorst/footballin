using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync
{
    public class StatsTeam
    {
        public string totfd { get; set; }
        public string totyds { get; set; }
        public string pyds { get; set; }
        public string ryds { get; set; }
        public string pen { get; set; }
        public string penyds { get; set; }
        public string trnovr { get; set; }
        public string pt { get; set; }
        public string ptyds { get; set; }
        public string ptavg { get; set; }
        public string top { get; set; }

    }
    public class Team
    {
        public StatsTeam team { get; set; }
    }
}
