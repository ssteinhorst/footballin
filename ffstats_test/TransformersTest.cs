using DataSync;
using DataSync.Transformers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

            [TestMethod]
            public void TestAwayStatsTransformer()
            {
                AwayStatsTransformer ast = new AwayStatsTransformer();
                Root root = GetTestJSONObject();

                ast.TransformJSONAwayToEF(eid, "Away", root.away);
            }
        }
    }
}
