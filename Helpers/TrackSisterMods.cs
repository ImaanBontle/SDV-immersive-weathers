namespace ImmersiveWeathers
{
    /// <summary>
    /// Tracks relevant properties related to sister mods.
    /// </summary>
    internal class TrackSisters
    {
        /// <summary>
        /// Is ClimateControl installed?
        /// </summary>
        /// <remarks>Defaults to <see langword="false"/>.</remarks>
        public bool ClimateControlPresent { get; set; } = false;
        /// <summary>
        /// All relevant properties related to ClimateControl.
        /// </summary>
        public ClimateControl ClimateControl { get; set; }
        /// <summary>
        /// Tracks when expected morning messages are received from sister mods.
        /// </summary>
        public MorningUpdate MorningUpdate { get; set; }
        public TrackSisters()
        {
            ClimateControl = new ClimateControl();
            MorningUpdate = new MorningUpdate();
        }
    }

    /// <summary>
    /// Tracks all relevant properties related to ClimateControl.
    /// </summary>
    internal class ClimateControl
    {
        /// <summary>
        /// Has a model already been loaded?
        /// </summary>
        /// <remarks>Defaults to <see langword="false"/>.</remarks>
        public bool ModelLoaded { get; set; } = false;
        /// <summary>
        /// If a model has been loaded, which one?
        /// </summary>
        public IIWAPI.WeatherModel ModelType { get; set; }
        /// <summary>
        /// Was the weather successfully changed today?
        /// </summary>
        public bool ChangedWeather { get; set; }
        /// <summary>
        /// If the weather was changed, what was it changed to?
        /// </summary>
        public IIWAPI.WeatherType ChangedToType { get; set; }
    }

    /// <summary>
    /// Tracks when expected morning messages are received from sister mods.
    /// </summary>
    internal class MorningUpdate
    {
        /// <summary>
        /// Has ClimateControl reported in this morning?
        /// </summary>
        /// <remarks>Defaults to <see langword="false"/>.</remarks>
        public bool ClimateControl { get; set; } = false;
    }
}
