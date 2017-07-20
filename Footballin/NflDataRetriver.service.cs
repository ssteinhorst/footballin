using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Footballin
{
    public class NflDataRetriver
    {
        public static void AddSheduleDataFromURL(int year, string seasonType, int week)
        {
            //  Returns the NFL.com XML schedule URL. `year` should be an
            //  integer, `stype` should be one of the strings `PRE`, `REG` or
            //  `POST`, and `gsis_week` should be a value in the range
            //  `[0, 17]`.
            var document = XDocument.Load("http://www.nfl.com/ajax/scorestrip?season=" + year + "&seasonType=" + seasonType + "&week=" + week);
            //string week = document.Root.Element("gms").Value;
            List<game_schedule> games = new List<game_schedule>();
            if (document.Root.Element("gms") != null && document.Root.Element("gms").Elements("g") != null)
            {
                foreach (XElement element in document.Root.Element("gms").Elements("g"))
                {
                    game_schedule gs = new game_schedule();
                    gs.season = year;
                    gs.seasontype = seasonType;
                    gs.week = week;
                    gs.day = element.Attribute("d").Value;
                    gs.eid = (int)element.Attribute("eid");
                    gs.ga = element.Attribute("ga").Value;
                    gs.gametype = seasonType; //?? I think
                    gs.gsis = element.Attribute("gsis").Value;
                    gs.hometeamabbv = element.Attribute("h").Value;
                    gs.hometeamname = element.Attribute("hnn").Value;
                    gs.hs = element.Attribute("hs").Value;
                    gs.k = element.Attribute("k").Value;
                    gs.p = element.Attribute("p").Value;
                    gs.q = element.Attribute("q").Value;
                    gs.rz = element.Attribute("rz").Value;
                    gs.time = element.Attribute("t").Value;
                    gs.visitingteamabbv = element.Attribute("v").Value;
                    gs.visitingteamname = element.Attribute("vnn").Value;
                    gs.vs = element.Attribute("vs").Value;

                    games.Add(gs);
                }
                game_schedule.AddMultipleGameSchedules(games);
            }
        }
    }
}