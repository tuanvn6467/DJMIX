using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicIdentification.Utilities
{
    public class MusicMap
    {
        public string filename { get; set; }
        public string fp_created { get; set; }
        public string fp_duration { get; set; }
        public string tracks_matched { get; set; }
        public List<TrackMap> matches { get; set; }
    }
}
