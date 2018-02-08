using System.Collections.Generic;

namespace DataSync
{
    public class Away
    {
        public Dictionary<string, string> score { get; set; }

        public string abbr { get; set; }

        public string to { get; set; }

        public Stats stats { get; set; }

        public string players { get; set; }
    }
}