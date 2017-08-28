using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync
{
    public partial class Root
    {
        // primary key
        //public string eid { get; set; }
        //public string weather { get; set; }
        //public string media { get; set; }
        //public string yl { get; set; }
        //public string qtr { get; set; }
        //public string note { get; set; }
        //public string down { get; set; }
        //public string togo { get; set; }
        //public string redzone { get; set; }
        //public string clock { get; set; }
        //public string posteam { get; set; }
        //public string stadium { get; set; }
        //[NotMapped]
        public Dictionary<string, ScrSummary> scrsummary { get; set; }
        //[NotMapped]

        // drives is for JSON, Drives is for EF
        public Dictionary<string, Drive> drives { get; set; }
        //[JsonIgnore]
        //[JsonProperty(Required = Required.Default)]
        //public List<drive> Drives
        //{
        //    get
        //    {
        //        var driveList = new List<drive>();
        //        foreach (string key in drives.Keys)
        //        {
        //            drive drv = new drive();
        //            drv.eid = eid;
        //            drv.drivenumber = key.ToString();
        //            drv.posteam = drives[key].posteam;
        //            drv.qtr = drives[key].qtr;
        //            drv.redzone = drives[key].redzone;
        //            drv.fds = drives[key].fds;
        //            drv.result = drives[key].result;
        //            drv.penyds = drives[key].penyds;
        //            drv.ydsgained = drives[key].ydsgained;
        //            drv.numplays = drives[key].numplays;
        //            drv.postime = drives[key].postime;
        //            drv.posteam = drives[key].posteam;
        //            drv.posteam = drives[key].posteam;
        //            drv.start_qtr = drives[key].Start.qtr;
        //            drv.start_time = drives[key].Start.time;
        //            drv.start_yrdln = drives[key].Start.yrdln;
        //            drv.start_team = drives[key].Start.team;

        //            drv.end_qtr = drives[key].End.qtr;
        //            drv.end_time = drives[key].End.time;
        //            drv.end_yrdln = drives[key].End.yrdln;
        //            drv.end_team = drives[key].End.team;

        //        }
        //        return driveList;
        //    }
        //}

        // away and home for for JSON deserializing
        // home_team and away_team are for EF persistance
        public Away away { get; set; }
        public Home home { get; set; }

        //[JsonIgnore]
        //[JsonProperty(Required = Required.Default)]
        //public home_team home_team { get
        //    {
        //        var hme = new home_team();
        //        hme.eid = eid;
        //        hme.abbr = home.abbr;
        //        hme.players = home.players;
        //        hme.team_to = home.to;
        //        hme.score_1 = home.score["1"];
        //        hme.score_2 = home.score["2"];
        //        hme.score_3 = home.score["3"];
        //        hme.score_4 = home.score["4"];
        //        hme.score_5 = home.score["5"];
        //        hme.score_t = home.score["T"];

        //        return hme;
        //    } }

        //[JsonIgnore]
        //[JsonProperty(Required = Required.Default)]
        //public away_team away_team
        //{
        //    get
        //    {
        //        var awy = new away_team();
        //        awy.eid = eid;
        //        awy.abbr = away.abbr;
        //        awy.players = away.players;
        //        awy.team_to = away.to;
        //        awy.score_1 = away.score["1"];
        //        awy.score_2 = away.score["2"];
        //        awy.score_3 = away.score["3"];
        //        awy.score_4 = away.score["4"];
        //        awy.score_5 = away.score["5"];
        //        awy.score_t = away.score["T"];

        //        return awy;
        //    }
        //}
       
        //[JsonIgnore]
        //[JsonProperty(Required = Required.Default)]
        //public List<ScrSummary> scrSummary { get ; set; }


    }
}
