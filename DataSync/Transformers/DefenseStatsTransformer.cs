using System.Collections.Generic;

namespace DataSync.Transformers
{
    public class DefenseStatsTransformer
    {
        public List<defense_stats> TransformJSONDefenseToEF(string eid, string location, Dictionary<string, StatsDefense> sDef)
        {
            var defenseList = new List<defense_stats>();
            foreach (string defKey in sDef.Keys)
            {
                var defense = new defense_stats()
                {
                    eid_playerid = eid + "-" + defKey,
                    playerid = defKey,
                    name = sDef[defKey].name,
                    tkl = sDef[defKey].tkl,
                    ast = sDef[defKey].ast,
                    sk = sDef[defKey].sk,
                    @int = sDef[defKey].@int,
                    ffum = sDef[defKey].ffum
                };
                defenseList.Add(defense);
            }
            return defenseList;
        }
    }
}