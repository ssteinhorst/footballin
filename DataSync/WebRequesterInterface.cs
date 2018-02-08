using System.Xml.Linq;

namespace DataSync
{
    internal interface WebRequesterInterface
    {
        string GetJSONfromUrl(string eid);

        XDocument GetSchedule(int year, string seasonType, int week);
    }
}