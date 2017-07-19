using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Footballin
{
    public partial class games
    {
        public static  List<game> ByDay(string dayNumber)
        {
            using(var db = new ffstatsEntities())
            {
                return db.games.Where(g => g.day == dayNumber).ToList();
            }
        }

        public static void Add(game newModel)
        {
            using (var db = new ffstatsEntities())
            {                
                db.games.Add(newModel);
                db.SaveChanges();
            }
        }
    }
}