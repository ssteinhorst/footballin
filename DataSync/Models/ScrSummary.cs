using System.Collections.Generic;

namespace DataSync
{
    public class ScrSummary
    {
        public string type { get; set; }
        public string desc { get; set; }
        public string qtr { get; set; }
        public string team { get; set; }
        public Dictionary<string, string> players { get; set; }
    }
}