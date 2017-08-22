using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync
{
    public partial class Root
    {
        // primary key
        //public string eid { get; set; }
        //public string weather { get; set; }
        //public string media { get; set; }
        //public string yl { get; set; }
        //public string qtr { get; set; }
        //public string note { get; set; }
        //public string down { get; set; }
        //public string togo { get; set; }
        //public string redzone { get; set; }
        //public string clock { get; set; }
        //public string posteam { get; set; }
        //public string stadium { get; set; }
        public Dictionary<string, ScrSummary> scrsummary { get; set; }
        public Dictionary<string, Drive> drives { get; set; }
        public Away away { get; set; }
        public Home home { get; set; }
    }
}
