using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataSync
{

    class WebRequester : WebRequesterInterface
    {
        public string GetJSONfromUrl(string eid)
        {
            string json = null;
            try
            {

                using (WebClient wc = new WebClient())
                {
                    json = wc.DownloadString(@"http://www.nfl.com/liveupdate/game-center/" + eid + @"/" + eid + @"_gtd.json");
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex);
            }
            return json;
        }

        public XDocument GetSchedule(int year, string seasonType, int week)
        {
            //throw new NotImplementedException();
            return XDocument.Load("http://www.nfl.com/ajax/scorestrip?season=" + year + "&seasonType=" + seasonType + "&week=" + week);

        }
    }
}
