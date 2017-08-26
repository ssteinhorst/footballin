using DataSync;
//using DataSync.Services;
using DataSync.Transformers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Footballin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var xml = "<game />";
            //var model = new game();
            //games.Add(model);
            //var dataService = new NflDataRetriver();
            //var xmlDoc = dataService.GetSheduleDataFromURL(2015, "REG", 1);
            //string path = @"C:\Users\Scott\Desktop\formatted gamedata.json";

            return View();
        }
        public void SaveGameData()
        {
            string jsonPath = @"C:\Users\Scott\Desktop\formatted_gamedata.json";
            //JObject rootobj = JsonUtils.getJObject(@"C:\Users\Scott\Desktop\justroot.json");
            //JObject rootobj = JsonUtils.getJObject(jsonPath);

            //var jsonEdited = (JObject)rootobj["2013090500"]["drives"];
            //jsonEdited.Property("crntdrv").Remove();

            //Root justroot = JsonConvert.DeserializeObject<Root>(rootobj["2013090500"].ToString());
            //justroot.eid = "2013090500";

            JObject jsonObj = JsonUtils.getJObject(jsonPath);
            // the 2 lines below remove the 'crntdrv' node
            var jsonEdited = (JObject)jsonObj["2013090500"]["drives"];
            jsonEdited.Property("crntdrv").Remove();
            Root root = JsonConvert.DeserializeObject<Root>(jsonObj["2013090500"].ToString());
            string eid = "2013090500";
            root.eid = eid;

            using (var db = new Entities())
            {

                // add new entries
                db.Roots.Add(root);
                db.home_team.Add(root.home_team);
                db.away_team.Add(root.away_team);
                var passXformer = new PassingStatsTransformer();
                foreach (passing_stats ps in passXformer.TransformJSONPassingToEF(eid, "home", root.home.stats.passing))
                {
                    db.passing_stats.Add(ps);
                }
                var rushXformer = new RushingStatsTransformer();
                foreach(rushing_stats rs in rushXformer.TransformJSONRushingToEF(eid, "home", root.home.stats.rushing))
                {
                    db.rushing_stats.Add(rs);
                }
                var recXformer = new ReceivingStatsTransformer();
                foreach(receiving_stats rs in recXformer.TransformJSONReceivingToEF(eid, "home", root.home.stats.receiving))
                {
                    db.receiving_stats.Add(rs);
                }
                var fumXformer = new FumblesStatsTransformer();
                foreach(fumbles_stats fs in fumXformer.TransformJSONFumblesToEF(eid, "home", root.home.stats.fumbles))
                {
                    db.fumbles_stats.Add(fs);
                }

                db.SaveChanges();


                // remove changes
                var root_remove = db.Roots.SingleOrDefault(e => e.eid == root.eid);
                if(root_remove != null)
                {
                    db.Roots.Remove(root_remove);
                }
                var remove_home = db.home_team.SingleOrDefault(e => e.eid == root.eid);
                if (remove_home != null)
                {
                    db.home_team.Remove(remove_home);
                }
                var remove_away = db.away_team.SingleOrDefault(e => e.eid == root.eid);
                if (remove_away != null)
                {
                    db.away_team.Remove(remove_away);
                }

                //var remove_passing = db.passing_stats.SingleOrDefault(e => e.eid_playerid.StartsWith(eid));
                //if(remove_passing != null)
                //{
                //    db.passing_stats.Remove(remove_passing);
                //}
                db.passing_stats.RemoveRange(db.passing_stats.Where(e => e.eid_playerid.StartsWith(eid)));
                db.rushing_stats.RemoveRange(db.rushing_stats.Where(e => e.eid_playerid.StartsWith(eid)));
                db.receiving_stats.RemoveRange(db.receiving_stats.Where(e => e.eid_playerid.StartsWith(eid)));
                db.fumbles_stats.RemoveRange(db.fumbles_stats.Where(e => e.eid_playerid.StartsWith(eid)));

                db.SaveChanges();
            }
        }

        public void SyncScheduleDataFromUrl()
        {
            //var dataService = new NflDataRetriver();

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
                        DataSync.NflDataRetriver.AddSheduleDataFromURL(year, seasonType, week);
                    }
                }
            }
            

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";


            return View();
        }
    }
}