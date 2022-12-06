using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Linq;
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
using static ImmersiveWeathers.IWAPI;

// TODO: Nvm, it's possible, but you need to ensure there is a shared project reference!

// TODO: Update API <----- v0.5.0
// TODO: Implement broadcast in Framework and cache values <----- v0.6.0
// TODO: Standardise trace vs info messages. Add traces for every time a mod does an action, framework receives a broadcast, and messages sent to player <----- v0.6.0
// TODO: Add config for SMAPI logging <----- v0.6.0
// TODO: Write custom log messages for weather changes <----- v0.7.0
// TODO: Add mod config menu (make sure to reload any changes from player) <----- v0.8.0
// TODO: Improve comments <----- v1.0.0

namespace ImmersiveWeathers
{
    // ----------
    // MAIN CLASS
    // ----------
    // SMAPI loads this on launch
    internal sealed class IWFramework : Mod
    {
        // --------
        // SEND API
        // --------
        // Tells SMAPI how to get an API copy for each mod
        public override object GetApi(IModInfo mod)
        {
            return new IWAPI();
        }

        // --------------------
        // FIELDS AND VARIABLES
        // --------------------
        // SMAPI initialises fields on launch
        // Define PRNG field for use by sister mods
        public static Random PRNG = new();

        // Define field for storing list of sister mods
        public static Dictionary<IWAPI.FollowTheWhiteRabbit, bool> sisterMods = new();

        // Define field for handling event calls
        public static DialTheMatrix dialTheMatrix = new();

        // -----------
        // MAIN METHOD
        // -----------
        // SMAPI calls this on launch
        public override void Entry(IModHelper helper)
        {
            // ---------
            // GAME LOAD
            // ---------
            // When game loaded, initialised variables
            this.Helper.Events.GameLoop.GameLaunched += GameLoop_InitializeVariables;
            // Also set up internal event handler
            dialTheMatrix.PickUpNeo += TrinityIsCalling;

            // When day begins, generate a weather forecast
            //this.Helper.Events.GameLoop.DayStarted += StartDay_WeatherForecaster; // Commented out during CC testing. Likely will repurpose for preventing TV chances
        }

        // --------------------
        // INITIALIZE VARIABLES
        // --------------------
        // Initialize variables on game launch
        private void GameLoop_InitializeVariables(object sender, GameLaunchedEventArgs e)
        {
            // Grab PRNG from EvenBetterRNG Mod API, if present
            IEvenBetterRNGAPI eBRNG = this.Helper.ModRegistry.GetApi<IEvenBetterRNGAPI>("pepoluan.EvenBetterRNG");
            if (eBRNG != null)
            {
                PRNG = eBRNG.GetNewRandom();
            }
            // Make a list of all sister mods that are present so can delay console logging until all have reported in
            if (this.Helper.ModRegistry.IsLoaded("MsBontle.ClimateControl"))
                sisterMods.Add(IWAPI.FollowTheWhiteRabbit.ClimateControl, false);
        }
        // ----------------
        // FORECAST WEATHER
        // ----------------
        // Forecast the weather once the day has started and all sister mods have reported in
        private void StartDay_WeatherForecaster(object sender, DayStartedEventArgs e)
        {
            // Grab information about the game's current weather state
            WeatherUtils.WeatherState weatherForecast = WeatherUtils.PopulateWeather.Populate();

            // Print appropriate weather update to SMAPI terminal
            string weatherString = WeatherMan.Predict(weatherForecast);
            BroadCast(weatherString);
        }

        // ---------
        // BROADCAST
        // ---------
        // Broadcast updates to SMAPI terminal
        private void BroadCast(string terminalUpdate)
        {
            this.Monitor.Log($"{terminalUpdate}", LogLevel.Info);
        }

        // ------------------
        // INTERPRET MESSAGES
        // ------------------
        // Interpret messages from sister mods
        private void TrinityIsCalling(object sender, EventArgs e)
        {
            this.Monitor.Log("Acknowledge call from mod", LogLevel.Info);
        }
    }
}