using System.Runtime.Serialization;

namespace Footballin.Models
{
    public class game_data
    {
    }

    [DataContract()]
    public partial class game_data_root
    {
        [DataMember(Name = "eid")]
        public string eid { get; set; }

        public string weather { get; set; }
        public string media { get; set; }
        public string yl { get; set; }
        public string qtr { get; set; }
        public string note { get; set; }
        public string down { get; set; }
        public string togo { get; set; }
        public string redzone { get; set; }
        public string clock { get; set; }
        public string posteam { get; set; }
        public string stadium { get; set; }
        public string nextupdate { get; set; }
    }
}