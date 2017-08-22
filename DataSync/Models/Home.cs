using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync
{
    public class Home
    {
        public Dictionary<string, string> score { get; set; }

        public string abbr { get; set; }

        public string to { get; set; }

        public Stats stats { get; set; }

        public string players { get; set; }
    }
}
