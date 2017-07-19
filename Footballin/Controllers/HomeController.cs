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


            return View(games.ByDay("Sun"));
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