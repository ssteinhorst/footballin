using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync
{
    public class StatsKicking
    {
        public string name { get; set; }
        public string fgm { get; set; }
        public string fga { get; set; }
        public string fgyds { get; set; }
        public string totpfg { get; set; }
        public string xpmade { get; set; }
        public string xpmissed { get; set; }
        public string xpa { get; set; }
        public string xpb { get; set; }
        public string xptot { get; set; }
    }
    public class Kicking
    {
        public Dictionary<string, StatsKicking> kicking { get; set; }
    }
}
