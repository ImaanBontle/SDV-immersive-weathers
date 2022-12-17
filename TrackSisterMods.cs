using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmersiveWeathers
{
    internal class TrackSisters
    {
        public bool ClimateControlPresent { get; set; } = false;
        public ClimateControl ClimateControl { get; set; }
        public MorningUpdate MorningUpdate { get; set; }
        public TrackSisters()
        {
            ClimateControl = new ClimateControl();
            MorningUpdate = new MorningUpdate();
        }
    }

    internal class ClimateControl
    {
        public bool ModelLoaded { get; set; } = false;
        public IIWAPI.WeatherModel ModelType { get; set; }
        public bool ChangedWeather { get; set; }
        public IIWAPI.WeatherType ChangedToType { get; set; }
    }

    internal class MorningUpdate
    {
        public bool ClimateControl { get; set; } = false;
    }
}
