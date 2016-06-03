using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicIdentification.Utilities
{
    public class TrackPosition
    {
        public string match_start { get; set; }
        public string match_end { get; set; }
        public string match_duration { get; set; }
        public string query_start { get; set; }
        public string query_end { get; set; }
        public string query_duration { get; set; }
    }
}
