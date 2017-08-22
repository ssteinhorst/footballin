using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
