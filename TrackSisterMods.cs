using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmersiveWeathers
{
    internal class TrackSisterMods
    {
        public bool ClimateControlPresent { get; set; } = false;
        public ClimateControl ClimateControl { get; set; }
        public TrackSisterMods()
        {
            ClimateControl = new ClimateControl();
        }
    }

    internal class ClimateControl
    {
        public bool ModelLoaded { get; set; } = false;
        public IWAPI.WeatherModel ModelType { get; set; }
    }
}
