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

        // How to allow sister mods to connect to the Framework
        public static DialTheMatrix dialTheMatrix = new();

        // Define field for storing list of sister mods
        public static Dictionary<IWAPI.FollowTheWhiteRabbit, bool> sisterMods = new();

        // Main method
        public override void Entry(IModHelper helper)
        {
            // When game is loaded, initialise variables
            this.Helper.Events.GameLoop.GameLaunched += GameLoop_InitializeVariables;
            // Listen for sister mods when they call
            dialTheMatrix.PickUpNeo += MyNameIsTrinity;

            // When day begins, generate a weather forecast
            //this.Helper.Events.GameLoop.DayStarted += StartDay_WeatherForecaster; // Commented out during CC testing. Likely will repurpose for preventing TV chances
        }

        // Initialize variables
        private void GameLoop_InitializeVariables(object sender, GameLaunchedEventArgs e)
        {
            // Grab PRNG from EvenBetterRNG Mod API, if present
            IEvenBetterRNGAPI eBRNG = this.Helper.ModRegistry.GetApi<IEvenBetterRNGAPI>("pepoluan.EvenBetterRNG");
            if (eBRNG != null)
            {
                PRNG = eBRNG.GetNewRandom();
            }
            // Make a list of sister mods that are present so the Framework can track who has made contact before each terminal broadcast goes out
            // Ensures the Framework is always the last to act during any sequence
            if (this.Helper.ModRegistry.IsLoaded("MsBontle.ClimateControl"))
                sisterMods.Add(IWAPI.FollowTheWhiteRabbit.ClimateControl, false);
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

        // Broadcast incoming messages to SMAPI terminal
        public void MyNameIsTrinity(object sender, EnterTheMatrx enterTheMatrix)
        {
            this.Monitor.Log($"{enterTheMatrix.TheMatrixHasYou}: {enterTheMatrix.MessageForNeo}", LogLevel.Info);
        }
    }


    // SPECIAL NOTES:
    //
    // Event handler and definitions for broadcasting to the framework's SMAPI log
    //
    // Some utilities for sister mods to broadcast centrally through the framework.
    // Basically I'm generating my own internal event calls, similar to how SMAPI works.
    // Tried to make this understandable by using Matrix references but it's still advanced.
    //
    // These bits not to be included in general-release API, only for sister mods.
    // (The calls won't work anyway if you're not in that list).
    public class DialTheMatrix
    {
        public EventHandler<EnterTheMatrx> PickUpNeo;
        public void HeIsTheOne(string messageForNeo, int thisIsMyName)
        {
            EnterTheMatrx enterTheMatrix = new()
            {
                MessageForNeo = messageForNeo,
                TheMatrixHasYou = (IWAPI.FollowTheWhiteRabbit) thisIsMyName
            };
            PickUpNeo.Invoke(this, enterTheMatrix);
        }
    }

    // Properties to broadcast
    public class EnterTheMatrx : EventArgs
    {
        public string MessageForNeo { get; set; }
        public FollowTheWhiteRabbit TheMatrixHasYou { get; set; }
    }
}