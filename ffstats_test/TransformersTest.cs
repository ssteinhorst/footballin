using DataSync;
using DataSync.Transformers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace ffstats_test
{
    class TransformersTest
    {
        [TestClass]
        public class UnitTest1
        {
            private string eid = "2013090500";
            
            private Root GetTestJSONObject()
            {
                //string json = File.ReadAllText(@"C:\Users\Scott\Documents\Visual Studio 2015\Projects\Footballin\ffstats_test\livegamedata.json");
                string json = File.ReadAllText(@".\livegamedata.json");

                JObject parsed = JObject.Parse(json);
                // remove unused node from JSON
                var jsonEdited = (JObject)parsed[eid]["drives"];
                jsonEdited.Property("crntdrv").Remove();
                Root root = JsonConvert.DeserializeObject<Root>(parsed[eid].ToString());
                return root;
            }

            [ExpectedException(typeof(JsonReaderException))]
            [TestMethod]
            public void TestParsingBadJSON()
            {
                string json = File.ReadAllText(@".\badjson.json");
                JObject parsed = JObject.Parse(json);
                // this assert should never be hit
                Assert.IsNull("notnull");

            }

            [TestMethod]
            public void TestParsingJSON()
            {
                string json = File.ReadAllText(@".\livegamedata.json");
                JObject parsed = JObject.Parse(json);
                Assert.IsNotNull(parsed);

            }

            [TestMethod]
            public void TestAwayStatsTransformer()
            {
                AwayStatsTransformer ast = new AwayStatsTransformer();
                Root root = GetTestJSONObject();

                away_team at = ast.TransformJSONAwayToEF(eid, "Away", root.away);
                Assert.IsTrue(at.abbr == "BAL");

                var passXformer = new PassingStatsTransformer();
                List<passing_stats> homePS = passXformer.TransformJSONPassingToEF(eid, "away", root.away.stats.passing);
                Assert.IsTrue(homePS[0].name == "J.Flacco");

                var rushXformer = new RushingStatsTransformer();
                List<rushing_stats> rushs = rushXformer.TransformJSONRushingToEF(eid, "away", root.away.stats.rushing);
                Assert.IsTrue(rushs[0].name == "R.Rice");

                var recXformer = new ReceivingStatsTransformer();
                List<receiving_stats> recs = recXformer.TransformJSONReceivingToEF(eid, "away", root.away.stats.receiving);
                Assert.IsTrue(recs[0].name == "R.Rice");

                var fumXformer = new FumblesStatsTransformer();
                List<fumbles_stats> fums = fumXformer.TransformJSONFumblesToEF(eid, "away", root.away.stats.fumbles);
                Assert.IsTrue(fums[0].name == "J.Flacco");

                var kickXformer = new KickingStatsTransformer();
                List<kicking_stats> kicks = kickXformer.TransformJSONKickingToEF(eid, "away", root.away.stats.kicking);
                Assert.IsTrue(kicks[0].name == "J.Tucker");

                var puntXformer = new PuntingStatsTransformer();
                List<punting_stats> punts = puntXformer.TransformJSONPuntingToEF(eid, "away", root.away.stats.punting);
                Assert.IsTrue(punts[0].name == "S.Koch");

                var kickretXformer = new KickretStatsTransformer();
                List<kickret_stats> kickrets = kickretXformer.TransformJSONKickretToEF(eid, "away", root.away.stats.kickret);
                Assert.IsTrue(kickrets[0].name == "D.Woodhead");

                var puntretXformer = new PuntretStatsTransformer();
                List<puntret_stats> puntrets = puntretXformer.TransformJSONPuntretToEF(eid, "away", root.away.stats.puntret);
                Assert.IsTrue(puntrets[0].name == "L.Webb");

                var defenseXformer = new DefenseStatsTransformer();
                List<defense_stats> defs = defenseXformer.TransformJSONDefenseToEF(eid, "away", root.away.stats.defense);
                Assert.IsTrue(defs[0].name == "J.Bynes");

                var teamXformer = new TeamStatsTransformer();
                team_stats team = teamXformer.TransformJSONTeamStatsToEF(eid, "home", root.away.abbr, root.away.stats.team);
                Assert.IsTrue(team.totfd == "24");
            }

            [TestMethod]
            public void TestHomeStatsTransformers()
            {
                // tests the transformers that take JSON and transform it into the DB objects
                HomeStatsTransformer hst = new HomeStatsTransformer();
                Root root = GetTestJSONObject();

                var homeXformer = new HomeStatsTransformer();
                home_team ht = homeXformer.TransformJSONHometoEF(eid, "home", root.home);
                Assert.IsTrue(ht.abbr == "DEN");

                var passXformer = new PassingStatsTransformer();
                List<passing_stats> homePS = passXformer.TransformJSONPassingToEF(eid, "home", root.home.stats.passing);
                Assert.IsTrue(homePS[0].name == "P.Manning");

                var rushXformer = new RushingStatsTransformer();
                List<rushing_stats> rushs = rushXformer.TransformJSONRushingToEF(eid, "home", root.home.stats.rushing);
                Assert.IsTrue(rushs[0].name == "K.Moreno");

                var recXformer = new ReceivingStatsTransformer();
                List<receiving_stats> recs = recXformer.TransformJSONReceivingToEF(eid, "home", root.home.stats.receiving);
                Assert.IsTrue(recs[0].name == "W.Welker");

                var fumXformer = new FumblesStatsTransformer();
                List<fumbles_stats> fums = fumXformer.TransformJSONFumblesToEF(eid, "home", root.home.stats.fumbles);
                Assert.IsTrue(fums[0].name == "W.Welker");

                var kickXformer = new KickingStatsTransformer();
                List<kicking_stats> kicks = kickXformer.TransformJSONKickingToEF(eid, "home", root.home.stats.kicking);
                Assert.IsTrue(kicks[0].name == "M.Prater");

                var puntXformer = new PuntingStatsTransformer();
                List<punting_stats> punts = puntXformer.TransformJSONPuntingToEF(eid, "home", root.home.stats.punting);
                Assert.IsTrue(punts[0].name == "B.Colquitt");

                var kickretXformer = new KickretStatsTransformer();
                List<kickret_stats> kickrets = kickretXformer.TransformJSONKickretToEF(eid, "home", root.home.stats.kickret);
                Assert.IsTrue(kickrets[0].name == "J.Rogers");

                var puntretXformer = new PuntretStatsTransformer();
                List<puntret_stats> puntrets = puntretXformer.TransformJSONPuntretToEF(eid, "home", root.home.stats.puntret);
                Assert.IsTrue(puntrets[0].name == "T.Holliday");

                var defenseXformer = new DefenseStatsTransformer();
                List<defense_stats> defs = defenseXformer.TransformJSONDefenseToEF(eid, "home", root.home.stats.defense);
                Assert.IsTrue(defs[0].name == "D.Ihenacho");

                var teamXformer = new TeamStatsTransformer();
                team_stats team = teamXformer.TransformJSONTeamStatsToEF(eid, "home", root.home.abbr, root.home.stats.team);
                Assert.IsTrue(team.totfd == "24");
            }

            [TestMethod]
            public void TestDrivesTransformers()
            {
                Root root = GetTestJSONObject();

                var driveXformer = new DriveTransformer();
                var playXformer = new DrivePlayTransformer();
                var dppXformer = new DrivePlayPlayersTransformer();

                List<data_drives> dd = driveXformer.TransformJSONTeamStatsToEF(eid, root.drives);
                Assert.IsTrue(dd[0].posteam == "BAL");
                Assert.IsTrue(dd[0].result == "Punt");

                List<drive_plays> play = playXformer.TransformDrivePlaysJSONtoEF(eid, "1", root.drives["1"].plays);
                Assert.IsTrue(play[0].yrdln == "DEN 35");

                List<drive_play_players> dpp = dppXformer.TransformPlayerJSONtoEF(eid, "1", "36", root.drives["1"].plays["36"].players);
                Assert.IsTrue(dpp[1].playerName == "M.Prater");
            }

            [TestMethod]
            public void TestScrTransformer()
            {
                Root root = GetTestJSONObject();

                var scrXformer = new ScrsummaryTransformer();
                List<scrsummary_data> sd = scrXformer.ScrsummaryJSONtoEF(eid, root.scrsummary);
                Assert.IsTrue(sd[0].team == "BAL");
                Assert.IsTrue(sd[0].scr_id == "522");
                Assert.IsTrue(sd[0].players.Contains("00-0026158"));

            }


        }
    }
}
