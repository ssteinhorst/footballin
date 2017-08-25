using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync
{
    public class Drive
    {
        public string posteam { get; set; }
        public int qtr { get; set; }
        public string redzone { get; set; }
        public int fds { get; set; }
        public string result { get; set; }
        public int penyds { get; set; }
        public int ydsgained { get; set; }
        public int numplays { get; set; }
        public string postime { get; set; }
        public StartEnd Start { get; set; }
        public StartEnd End { get; set; }
        public Dictionary<string, Play> plays { get; set; }

    }
}
