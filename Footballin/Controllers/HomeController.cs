using DataSync;

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

            //JObject rootobj = JsonUtils.getJObject(@"C:\Users\Scott\Desktop\justroot.json");
            JObject rootobj = JsonUtils.getJObject(@"C:\Users\Scott\Desktop\formatted_gamedata.json");

            var jsonEdited = (JObject)rootobj["2013090500"]["drives"];
            jsonEdited.Property("crntdrv").Remove();

            Root justroot = JsonConvert.DeserializeObject<Root>(rootobj["2013090500"].ToString());
            justroot.eid = "2013090500";

            using (var db = new Entities())
            {
                db.Roots.Add(justroot);
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