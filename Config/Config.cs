namespace ImmersiveWeathers
{
    /// <summary>
    /// Contains configuration data for ImmersiveWeathers.
    /// </summary>
    internal class ModConfig
    {
        /// <summary>
        /// Should weather predictions be printed to the SMAPI terminal?
        /// </summary>
        /// <remarks>Defaults to <see langword="true"/>.</remarks>
        public bool PrintToTerminal { get; set; } = true;
        /// <summary>
        /// Should weather predictions be printed to player HUD?
        /// </summary>
        /// <remarks>Defaults to <see langword="false"/></remarks>
        public bool PrintHUDMessage { get; set; } = false;
    }
}
