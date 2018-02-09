using DataSync.Transformers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace DataSync
{
    public class GameDataService
    {
        public bool GetAndSaveGameData(List<string> eids)
        {
            var gameDataEids = this.GetAllGameDataEIDs();
            var dups = eids.Where(e => gameDataEids.Any(p => e == p));
            foreach (string eid in eids)
            {
                if (!dups.Contains(eid))
                {
                    // sample of url
                    //http://www.nfl.com/liveupdate/game-center/2012010101/2012010101_gtd.json

                    // loads the JSON
                    WebRequester webReq = new WebRequester();
                    string json = webReq.GetJSONfromUrl(eid);

                    if (json != null)
                    {
                        // create JObject
                        JObject parsed = JObject.Parse(json);
                        // remove unused node from JSON
                        var jsonEdited = (JObject)parsed[eid]["drives"];
                        jsonEdited.Property("crntdrv").Remove();
                        // deserialize the JSON into classes
                        Root root = JsonConvert.DeserializeObject<Root>(parsed[eid].ToString());
                        root.eid = eid.ToString();
                        SaveDeserializedJSONtoEF(root, eid);
                    }
                }
            }
            return true;
        }

        public bool SaveDeserializedJSONtoEF(Root root, string eid)
        {
            using (var db = new Entities())
            {
                // add new entries
                db.Roots.Add(root);
                var homeXformer = new HomeStatsTransformer();
                db.home_team.Add(homeXformer.TransformJSONHometoEF(eid, "home", root.home));

                var awayXformer = new AwayStatsTransformer();
                db.away_team.Add(awayXformer.TransformJSONAwayToEF(eid, "away", root.away));

                var passXformer = new PassingStatsTransformer();
                foreach (passing_stats ps in passXformer.TransformJSONPassingToEF(eid, "home", root.home.stats.passing))
                {
                    db.passing_stats.Add(ps);
                }
                foreach (passing_stats ps in passXformer.TransformJSONPassingToEF(eid, "away", root.away.stats.passing))
                {
                    db.passing_stats.Add(ps);
                }
                var rushXformer = new RushingStatsTransformer();
                foreach (rushing_stats rs in rushXformer.TransformJSONRushingToEF(eid, "home", root.home.stats.rushing))
                {
                    db.rushing_stats.Add(rs);
                }
                foreach (rushing_stats rs in rushXformer.TransformJSONRushingToEF(eid, "away", root.away.stats.rushing))
                {
                    db.rushing_stats.Add(rs);
                }
                var recXformer = new ReceivingStatsTransformer();
                foreach (receiving_stats rs in recXformer.TransformJSONReceivingToEF(eid, "home", root.home.stats.receiving))
                {
                    db.receiving_stats.Add(rs);
                }
                foreach (receiving_stats rs in recXformer.TransformJSONReceivingToEF(eid, "away", root.away.stats.receiving))
                {
                    db.receiving_stats.Add(rs);
                }
                var fumXformer = new FumblesStatsTransformer();
                foreach (fumbles_stats fs in fumXformer.TransformJSONFumblesToEF(eid, "home", root.home.stats.fumbles))
                {
                    db.fumbles_stats.Add(fs);
                }
                foreach (fumbles_stats fs in fumXformer.TransformJSONFumblesToEF(eid, "away", root.away.stats.fumbles))
                {
                    db.fumbles_stats.Add(fs);
                }
                var kickXformer = new KickingStatsTransformer();
                foreach (kicking_stats ks in kickXformer.TransformJSONKickingToEF(eid, "home", root.home.stats.kicking))
                {
                    db.kicking_stats.Add(ks);
                }
                foreach (kicking_stats ks in kickXformer.TransformJSONKickingToEF(eid, "away", root.away.stats.kicking))
                {
                    db.kicking_stats.Add(ks);
                }
                var puntXformer = new PuntingStatsTransformer();
                foreach (punting_stats ps in puntXformer.TransformJSONPuntingToEF(eid, "home", root.home.stats.punting))
                {
                    db.punting_stats.Add(ps);
                }
                foreach (punting_stats ps in puntXformer.TransformJSONPuntingToEF(eid, "away", root.away.stats.punting))
                {
                    db.punting_stats.Add(ps);
                }
                var kickretXformer = new KickretStatsTransformer();
                foreach (kickret_stats ks in kickretXformer.TransformJSONKickretToEF(eid, "home", root.home.stats.kickret))
                {
                    db.kickret_stats.Add(ks);
                }
                foreach (kickret_stats ks in kickretXformer.TransformJSONKickretToEF(eid, "away", root.away.stats.kickret))
                {
                    db.kickret_stats.Add(ks);
                }
                var puntretXformer = new PuntretStatsTransformer();
                foreach (puntret_stats ps in puntretXformer.TransformJSONPuntretToEF(eid, "home", root.home.stats.puntret))
                {
                    db.puntret_stats.Add(ps);
                }
                foreach (puntret_stats ps in puntretXformer.TransformJSONPuntretToEF(eid, "away", root.away.stats.puntret))
                {
                    db.puntret_stats.Add(ps);
                }
                var defenseXformer = new DefenseStatsTransformer();
                foreach (defense_stats ds in defenseXformer.TransformJSONDefenseToEF(eid, "home", root.home.stats.defense))
                {
                    db.defense_stats.Add(ds);
                }
                foreach (defense_stats ds in defenseXformer.TransformJSONDefenseToEF(eid, "away", root.away.stats.defense))
                {
                    db.defense_stats.Add(ds);
                }
                var teamXformer = new TeamStatsTransformer();
                db.team_stats.Add(teamXformer.TransformJSONTeamStatsToEF(eid, "home", root.home.abbr, root.home.stats.team));
                db.team_stats.Add(teamXformer.TransformJSONTeamStatsToEF(eid, "away", root.away.abbr, root.away.stats.team));

                var driveXformer = new DriveTransformer();
                var playXformer = new DrivePlayTransformer();
                var dppXformer = new DrivePlayPlayersTransformer();

                foreach (data_drives dd in driveXformer.TransformJSONTeamStatsToEF(eid, root.drives))
                {
                    db.data_drives.Add(dd);
                    foreach (drive_plays play in playXformer.TransformDrivePlaysJSONtoEF(eid, dd.drivenumber, root.drives[dd.drivenumber].plays))
                    {
                        db.drive_plays.Add(play);
                        foreach (drive_play_players dpp in dppXformer.TransformPlayerJSONtoEF(eid, dd.drivenumber, play.playnum, root.drives[dd.drivenumber].plays[play.playnum].players))
                        {
                            db.drive_play_players.Add(dpp);
                        }
                    }
                }
                var scrXformer = new ScrsummaryTransformer();
                foreach (scrsummary_data sd in scrXformer.ScrsummaryJSONtoEF(eid, root.scrsummary))
                {
                    db.scrsummary_data.Add(sd);
                    var playerLU = new PlayerLUTransformer();
                    foreach (lu_player lp in playerLU.PlayerListLUJSONtoEF(eid, root.scrsummary[sd.scr_id].players))
                    {
                        db.lu_player.Add(lp);
                    }
                }

                db.SaveChanges();
            }

            return true;
        }

        public void DeleteGameData(string eid)
        {
            using (var db = new Entities())
            {
                // remove changes
                var root_remove = db.Roots.SingleOrDefault(e => e.eid == eid);
                if (root_remove != null)
                {
                    db.Roots.Remove(root_remove);
                }
                var remove_home = db.home_team.SingleOrDefault(e => e.eid == eid);
                if (remove_home != null)
                {
                    db.home_team.Remove(remove_home);
                }
                var remove_away = db.away_team.SingleOrDefault(e => e.eid == eid);
                if (remove_away != null)
                {
                    db.away_team.Remove(remove_away);
                }

                db.passing_stats.RemoveRange(db.passing_stats.Where(e => e.eid_playerid.StartsWith(eid)));
                db.rushing_stats.RemoveRange(db.rushing_stats.Where(e => e.eid_playerid.StartsWith(eid)));
                db.receiving_stats.RemoveRange(db.receiving_stats.Where(e => e.eid_playerid.StartsWith(eid)));
                db.fumbles_stats.RemoveRange(db.fumbles_stats.Where(e => e.eid_playerid.StartsWith(eid)));
                db.kicking_stats.RemoveRange(db.kicking_stats.Where(e => e.eid_playerid.StartsWith(eid)));
                db.punting_stats.RemoveRange(db.punting_stats.Where(e => e.eid_playerid.StartsWith(eid)));
                db.kickret_stats.RemoveRange(db.kickret_stats.Where(e => e.eid_playerid.StartsWith(eid)));
                db.puntret_stats.RemoveRange(db.puntret_stats.Where(e => e.eid_playerid.StartsWith(eid)));
                db.defense_stats.RemoveRange(db.defense_stats.Where(e => e.eid_playerid.StartsWith(eid)));
                db.team_stats.RemoveRange(db.team_stats.Where(e => e.eid_location.StartsWith(eid)));
                db.data_drives.RemoveRange(db.data_drives.Where(e => e.eid_drivenumber.StartsWith(eid)));
                db.drive_plays.RemoveRange(db.drive_plays.Where(e => e.eid_drivenum_playnum.StartsWith(eid)));
                db.drive_play_players.RemoveRange(db.drive_play_players.Where(e => e.eid_drive_play_playerid_sequence.StartsWith(eid)));
                db.scrsummary_data.RemoveRange(db.scrsummary_data.Where(e => e.eid_scrid.StartsWith(eid)));
                db.SaveChanges();
            }
        }

        public List<string> GetAllGameDataEIDs()
        {
            using (var db = new Entities())
            {
                return db.Roots.Select(u => u.eid).ToList();
            }
        }
    }
}