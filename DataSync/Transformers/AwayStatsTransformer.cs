namespace DataSync.Transformers
{
    public class AwayStatsTransformer
    {
        public away_team TransformJSONAwayToEF(string eid, string location, Away away)
        {
            var awy = new away_team()
            {
                eid = eid,
                abbr = away.abbr,
                players = away.players,
                team_to = away.to,
                score_1 = away.score["1"],
                score_2 = away.score["2"],
                score_3 = away.score["3"],
                score_4 = away.score["4"],
                score_5 = away.score["5"],
                score_t = away.score["T"]
            };
            return awy;
        }
    }
}