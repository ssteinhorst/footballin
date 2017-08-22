using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync
{
    public class StatsKickret
    {
        public string name { get; set; }
        public string ret { get; set; }
        public string avg { get; set; }
        public string tds { get; set; }
        public string lng { get; set; }
        public string lngtd { get; set; }

    }
    public class Kickret
    {
        public Dictionary<string, StatsKickret> kickret { get; set; }
    }
}
