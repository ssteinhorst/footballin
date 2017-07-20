using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Footballin
{
    public partial class game_schedule
    {
        public static  List<game_schedule> ByDay(string dayNumber)
        {
            using(var db = new ffstatsEntities1())
            {
                return db.game_schedule.Where(g => g.day == dayNumber).ToList();
            }
        }

        public static void AddSingleGameSchedule(game_schedule newModel)
        {
            using (var db = new ffstatsEntities1())
            {                
                db.game_schedule.Add(newModel);
                db.SaveChanges();
            }
        }

        public static void AddMultipleGameSchedules(List<game_schedule> newModels)
        {
            using (var db = new ffstatsEntities1())
            {
                foreach(game_schedule game in newModels)
                {
                    var gameexists = db.game_schedule.FirstOrDefault(g => g.gsis == game.gsis);
                    if (gameexists == null)
                    {
                        db.game_schedule.Add(game);
                    }

                }
                db.SaveChanges();
            }
        }

    }
}