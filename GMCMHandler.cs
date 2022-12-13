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
        }
    }
}
