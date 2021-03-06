﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DataSync
{
    public class GameScheduleService
    {
        public static void AddSheduleDataFromURL(int year, string seasonType, int week)
        {
            //  Returns the NFL.com XML schedule URL. `year` should be an
            //  integer, `stype` should be one of the strings `PRE`, `REG` or
            //  `POST`, and `gsis_week` should be a value in the range
            //  `[0, 17]`.
            WebRequester webReq = new WebRequester();
            //var document = XDocument.Load("http://www.nfl.com/ajax/scorestrip?season=" + year + "&seasonType=" + seasonType + "&week=" + week);
            var document = webReq.GetSchedule(year, seasonType, week);

            List<game_schedule> games = new List<game_schedule>();
            if (document.Root.Element("gms") != null && document.Root.Element("gms").Elements("g") != null)
            {
                foreach (XElement element in document.Root.Element("gms").Elements("g"))
                {
                    game_schedule gs = new game_schedule()
                    {
                        season = year,
                        seasontype = seasonType,
                        week = week,
                        day = element.Attribute("d").Value,
                        eid = (int)element.Attribute("eid"),
                        ga = element.Attribute("ga").Value,
                        gsis = element.Attribute("gsis").Value,
                        hometeamabbv = element.Attribute("h").Value,
                        hometeamname = element.Attribute("hnn").Value,
                        hs = element.Attribute("hs").Value,
                        k = element.Attribute("k").Value,
                        p = element.Attribute("p").Value,
                        q = element.Attribute("q").Value,
                        rz = element.Attribute("rz").Value,
                        time = element.Attribute("t").Value,
                        visitingteamabbv = element.Attribute("v").Value,
                        visitingteamname = element.Attribute("vnn").Value,
                        vs = element.Attribute("vs").Value
                    };
                    games.Add(gs);
                }
                game_schedule.AddMultipleGameSchedules(games);
            }
        }

        public static void SyncScheduleDataFromUrl()
        {
            int[] years = { 2017, 2016, 2015, 2014, 2013 };
            //string[] seasonTypes = {"PRE", "REG", "POST"};
            string seasonType = "";
            var weeks = Enumerable.Range(1, 22).ToArray();
            foreach (int year in years)
            {
                foreach (int week in weeks)
                {
                    if (week != 21)
                    {
                        if (week <= 17)
                        {
                            seasonType = "REG";
                        }
                        else
                        {
                            seasonType = "POST";
                        }
                        GameScheduleService.AddSheduleDataFromURL(year, seasonType, week);
                    }
                }
            }
        }

        public List<int> GetScheduleEIDsForYear(string year)
        {
            int.TryParse(year, out int intYear);
            using (var db = new ffstatsEntities())
            {
                return db.game_schedule.Where(e => e.season == intYear).Select(u => u.eid).ToList();
            }
        }

        public List<string> GetAllScheduleEIDs()
        {
            using (var db = new ffstatsEntities())
            {
                return db.game_schedule.Select(u => u.eid.ToString()).ToList();
            }
        }
    }
}