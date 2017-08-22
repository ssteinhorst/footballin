using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync
{
    public class StatsFumbles
    {
        public string name { get; set; }
        public string tot { get; set; }
        public string rcv { get; set; }
        public string trcv { get; set; }
        public string yds { get; set; }
        public string lost { get; set; }

    }
    public class Fumbles
    {
        public Dictionary<string, StatsFumbles> fumbles { get; set; }
    }
}
