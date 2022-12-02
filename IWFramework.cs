using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks.Dataflow;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace ImmersiveWeathers
{
    internal sealed class IWFramework : Mod
    {
        // Share API
        public override object GetApi()
        {
            return new IWAPI();
        }

        // Main method
        public override void Entry(IModHelper helper)
        {
            // When day begins, generate a weather forecast
            this.Helper.Events.GameLoop.DayStarted += StartDay_WeatherMachine;
        }

        // Handle weather forecasting steps
        private void StartDay_WeatherMachine(object sender, DayStartedEventArgs e)
        {
            // Grab information about the game's current weather state
            IWAPI.WeatherState weatherForecast = new IWAPI.WeatherState();
            weatherForecast = WeatherUtils.PopulateWeather.Populate(weatherForecast);

            // Print appropriate weather update to SMAPI terminal
            string weatherString = WeatherMan.Predict(weatherForecast);
            BroadCast(weatherString);
        }

        // Broadcast weather to SMAPI terminal
        private void BroadCast(string weatherString)
        {
            this.Monitor.Log($"{weatherString}", LogLevel.Info);
        }
    }
}