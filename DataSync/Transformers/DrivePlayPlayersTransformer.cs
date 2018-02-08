using System.Collections.Generic;

namespace DataSync.Transformers
{
    public class DrivePlayPlayersTransformer
    {
        public List<drive_play_players> TransformPlayerJSONtoEF(string eid, string drivenum, string playnum, Dictionary<string, List<Player>> pl)
        {
            var playerList = new List<drive_play_players>();
            foreach (string key in pl.Keys)
            {
                foreach (Player player in pl[key])
                {
                    var p = new drive_play_players()
                    {
                        eid_drive_play_playerid_sequence = eid + "-" + drivenum + "-" + playnum + "-" + key + "-" + player.sequence,
                        drivenum = drivenum,
                        playnum = playnum,
                        playerid = key,
                        sequence = player.sequence,
                        clubcode = player.clubcode,
                        playerName = player.playerName,
                        statId = player.statId,
                        yards = player.yards
                    };
                    playerList.Add(p);
                }
            }
            return playerList;
        }
    }
}