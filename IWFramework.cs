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
            this.Helper.Events.GameLoop.DayStarted += StartDay_WeatherMachine;
        }

        private void StartDay_WeatherMachine(object sender, DayStartedEventArgs e)
        {
            // Grab information about today's weather
            Dictionary<string, bool> weatherCheck = CheckWeather();

            // Print weather update to SMAPI terminal
            BroadCaster(weatherCheck);
        }

        // Checks today's weather
        private static Dictionary<string, bool> CheckWeather()
        {
            Dictionary<string, bool> weatherCheck = new Dictionary<string, bool>(){
                { "rainCheck", Game1.isRaining },
                { "stormCheck", Game1.isLightning },
                { "windCheck", Game1.isDebrisWeather },
                { "snowCheck", Game1.isSnowing }
            };
            return weatherCheck;
        }
       
        // Broadcasts today's weather to the terminal
        private void BroadCaster(Dictionary<string, bool> weatherCheck)
        {
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
        }
    }
}