using GenericModConfigMenu;
using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmersiveWeathers
{
    /// <summary>
    /// Handles integration with Generic Mod Config Menu.
    /// </summary>
    internal class GMCMHandler
    {
        /// <summary>
        /// Register mod configuration with Generic Mod Config Menu.
        /// </summary>
        /// <param name="s_config">The configuration data.</param>
        /// <param name="gMCM">The Generic Mod Config Menu API.</param>
        /// <param name="ModManifest">This mod's manifest.</param>
        /// <param name="Helper">The mod class' helper object.</param>
        internal static void Register(ModConfig s_config, IGenericModConfigMenuApi gMCM, IManifest ModManifest, IModHelper Helper)
        {
            // Register mod
            gMCM.Register(
                mod: ModManifest,
                reset: () => s_config = new ModConfig(),
                save: () => Helper.WriteConfig(s_config)
                );

            // Add section title
            gMCM.AddSectionTitle(
                mod: ModManifest,
                text: () => "Weather Reports",
                tooltip: () => "Each morning, players can choose to receive a forecast of the weather today and tomorrow. These options determine whether the player receives these messages, and if so, how."
                );

            // Add terminal logging
            gMCM.AddBoolOption(
                mod: ModManifest,
                getValue: () => s_config.PrintToTerminal,
                setValue: value => s_config.PrintToTerminal = value,
                name: () => "SMAPI Terminal:",
                tooltip: () => "If true, weather predictions are printed to the SMAPI terminal."
                );

            // Add HUD logging
            gMCM.AddBoolOption(
                mod: ModManifest,
                getValue: () => s_config.PrintHUDMessage,
                setValue: value => s_config.PrintHUDMessage = value,
                name: () => "In-Game HUD:",
                tooltip: () => "If true, weather predictions are printed using the in-game HUD.");
        }
    }
}
