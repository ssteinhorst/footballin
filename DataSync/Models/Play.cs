using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync
{
    public class Play
    {
        public string sp { get; set; }
        public string qtr { get; set; }
        public string down { get; set; }
        public string time { get; set; }
        public string yrdln { get; set; }
        public string ydstogo { get; set; }
        public string ydsnet { get; set; }
        public string posteam { get; set; }
        public string desc { get; set; }
        public string note { get; set; }
        public Dictionary<string, List<Player>> players { get; set; }
    }
}
