using GenericModConfigMenu;
using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmersiveWeathers
{
    internal class GMCMHandler
    {
        internal static void Register(ModConfig Config, IGenericModConfigMenuApi gMCM, StardewModdingAPI.IManifest ModManifest, IModHelper Helper)
        {
            // Register mod
            gMCM.Register(
                mod: ModManifest,
                reset: () => Config = new ModConfig(),
                save: () => Helper.WriteConfig(Config)
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
                getValue: () => Config.PrintToTerminal,
                setValue: value => Config.PrintToTerminal = value,
                name: () => "SMAPI Terminal",
                tooltip: () => "If true, weather predictions are printed to the SMAPI terminal."
                );

            // Add HUD logging
            gMCM.AddBoolOption(
                mod: ModManifest,
                getValue: () => Config.PrintHUDMessage,
                setValue: value => Config.PrintHUDMessage = value,
                name: () => "In-Game HUD",
                tooltip: () => "If true, weather predictions are printed using the in-game HUD.");
        }
    }
}
