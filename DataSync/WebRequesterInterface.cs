using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataSync
{
    interface WebRequesterInterface
    {
        string GetJSONfromUrl(string eid);

        XDocument GetSchedule(int year, string seasonType, int week);
    }
}
