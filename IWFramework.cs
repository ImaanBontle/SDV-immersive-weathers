using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace ImmersiveWeathers
{
    internal sealed class IWFramework : Mod
    {
        public override void Entry(IModHelper helper)
        {
            this.Helper.Events.GameLoop.DayStarted += GameLoop_DayStarted;
        }

        private void GameLoop_DayStarted(object sender, DayStartedEventArgs e)
        {
            // Grab information about today's weather.
            Dictionary<string, bool> weatherCheck = new Dictionary<string, bool>(){
                { "rainCheck", Game1.isRaining },
                { "stormCheck", Game1.isLightning },
                { "windCheck", Game1.isDebrisWeather },
                { "snowCheck", Game1.isSnowing }
            };

            // Print weather update to SMAPI terminal.
            if (weatherCheck["stormCheck"] == true)
            {
                Monitor.Log("There is a thunderstorm today.", LogLevel.Info);
            }
            else if (weatherCheck["rainCheck"] == true)
            {
                Monitor.Log("It is raining today.", LogLevel.Info);
            }
            else if (weatherCheck["windCheck"] == true)
            {
                Monitor.Log("It is windy today.", LogLevel.Info);
            }
            else if (weatherCheck["snowCheck"] == true)
            {
                Monitor.Log("It is snowing today.", LogLevel.Info);
            }
            else
            {
                Monitor.Log("It is sunny today.", LogLevel.Info);
            }

            //weatherCheck.Add("rainCheck", Game1.isRaining);
            //weatherCheck.Add("stormCheck", Game1.isLightning);

            //List<bool> weatherCheck = new List<bool>()
            //{
            //    Game1.isRaining
            //};
            //bool rainCheck = Game1.isRaining;
        }


       
        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;

            // print button presses to the console window
            this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}.", LogLevel.Debug);
        }
    }
}