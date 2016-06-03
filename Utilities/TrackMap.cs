using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicIdentification.Utilities
{
    public class TrackMap
    {
        public string title { get; set; }
        public string artist { get; set; }
        public string gnid { get; set; }
        public string song_duration { get; set; }
        public List<TrackPosition> match_positions { get; set; }
    }
}
