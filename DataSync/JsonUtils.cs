using Newtonsoft.Json.Linq;
using System.IO;

namespace DataSync
{
    public class JsonUtils
    {
        public static JObject getJObject(string path)
        {
            JObject parsed = JObject.Parse(getJson(path));
            return parsed;
        }

        public static string getJson(string path)
        {
            string json = "";
            using (StreamReader r = new StreamReader(path))
            {
                json = r.ReadToEnd();
            }
            return json;
        }
    }
}