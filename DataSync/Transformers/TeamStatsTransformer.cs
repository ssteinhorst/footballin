namespace DataSync.Transformers
{
    public class TeamStatsTransformer
    {
        public team_stats TransformJSONTeamStatsToEF(string eid, string location, string teamAbbr, StatsTeam ts)
        {
            var teamstats = new team_stats()
            {
                eid_location = eid + "-" + location,
                home_or_away = location,
                totfd = ts.totfd,
                totyds = ts.totyds,
                pyds = ts.pyds,
                ryds = ts.ryds,
                pen = ts.pen,
                penyds = ts.penyds,
                trnovr = ts.trnovr,
                pt = ts.pt,
                ptyds = ts.ptyds,
                ptavg = ts.ptavg,
                top = ts.top,
                team_abbr = teamAbbr
            };
            return teamstats;
        }
    }
}