using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks.Dataflow;
using EvenBetterRNG;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Monsters;
using static ImmersiveWeathers.IWAPI;

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
    // Some utilities for sister mods to broadcast centrally through the framework.
    // Tried to make this understandable by using Matrix references but it's still advanced.
    // Basically I'm generating my own internal event calls, similar to how SMAPI works.
    //
    // These bits not to be included in general-release API, only for sister mods.
    // (The calls won't work anyway if you're not in that list).
    //
    // Event handler and definitions for broadcasting to the framework's SMAPI log
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