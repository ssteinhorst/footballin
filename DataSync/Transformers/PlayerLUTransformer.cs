using DataSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync.Transformers
{
    public class PlayerLUTransformer
    {
        public List<lu_player> PlayerListLUJSONtoEF(string eid, Dictionary<string, string> players)
        {
            var playerList = new List<lu_player>();
            foreach(string key in players.Keys)
            {
                var luplayers = new lu_player()
                {
                    PlayerId = players[key],
                    PlayerName = key
                };
                playerList.Add(luplayers);
            }
            return playerList;

        }
    }
}
