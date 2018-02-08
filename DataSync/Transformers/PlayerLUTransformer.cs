using System.Collections.Generic;

namespace DataSync.Transformers
{
    public class PlayerLUTransformer
    {
        public List<lu_player> PlayerListLUJSONtoEF(string eid, Dictionary<string, string> players)
        {
            var playerList = new List<lu_player>();
            foreach (string key in players.Keys)
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