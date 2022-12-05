using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks.Dataflow;
using EvenBetterRNG;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Locations;
using StardewValley.Monsters;
using StardewValley.Tools;

// TODO: Update API <----- v0.5.0
// TODO: Implement broadcast in Framework and cache values <----- v0.6.0
// TODO: Standardise trace vs info messages. Add traces for every time a mod does an action, framework receives a broadcast, and messages sent to player <----- v0.6.0
// TODO: Add config for SMAPI logging <----- v0.6.0
// TODO: Write custom log messages for weather changes <----- v0.7.0
// TODO: Add mod config menu (make sure to reload any changes from player) <----- v0.8.0
// TODO: Improve comments <----- v1.0.0

namespace ImmersiveWeathers
{
    // Main mod class
    internal sealed class IWFramework : Mod
    {
        // Share ImmersiveWeathers API
        public override object GetApi()
        {
            return new IWAPI();
        }

        // Define PRNG field for use by sister mods
        public static Random PRNG = new();

        // Main method
        public override void Entry(IModHelper helper)
        {
            // Grab PRNG from EvenBetterRNG Mod API, if present
            this.Helper.Events.GameLoop.GameLaunched += GameLoop_LoadPRNG;

            // When day begins, generate a weather forecast
            //this.Helper.Events.GameLoop.DayStarted += StartDay_WeatherForecaster; // Commented out during CC testing. Likely will repurpose for preventing TV chances
        }

        private void GameLoop_LoadPRNG(object sender, GameLaunchedEventArgs e)
        {
            IEvenBetterRNGAPI api = this.Helper.ModRegistry.GetApi<IEvenBetterRNGAPI>("pepoluan.EvenBetterRNG");
            if (api != null)
            {
                PRNG = api.GetNewRandom();
            }
        }
        // Handle weather forecasting steps
        private void StartDay_WeatherForecaster(object sender, DayStartedEventArgs e)
        {
            // Grab information about the game's current weather state
            WeatherUtils.WeatherState weatherForecast = WeatherUtils.PopulateWeather.Populate();

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