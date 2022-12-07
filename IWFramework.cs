using System;
using System.Collections.Generic;
using System.ComponentModel;
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

// TODO: When SDV 1.6 releases, check for compatibility with new weather flags: weatherForTomorrow etc are switching to strings instead of integers. See https://stardewvalleywiki.com/Modding:Migrate_to_Stardew_Valley_1.6 for more information.

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
        // Define config fields and variables
        private ModConfig Config;
        private bool terminalLogging;
        private bool hUDMessages;

        // Define PRNG field for use by sister mods
        public static Random PRNG = new();

        // How to track sister mods
        public TrackSisters trackSisters = new();

        // Define field for handling event calls
        public static EventManager eventManager = new();

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
            this.Helper.Events.GameLoop.GameLaunched += GameLoop_Initialize;
            // Also set up internal event handler
            eventManager.SendToFramework += ReceiveEvent;

            // When day begins, generate a weather forecast
            this.Helper.Events.GameLoop.DayStarted += StartDay_WeatherForecaster;
        }

        // --------------------
        // INITIALIZE VARIABLES
        // --------------------
        // Initialize variables on game launch
        private void GameLoop_Initialize(object sender, GameLaunchedEventArgs e)
        {
            // Tell SMAPI where to grab config options
            this.Config = this.Helper.ReadConfig<ModConfig>();
            terminalLogging = Config.PrintToTerminal;
            hUDMessages = Config.PrintHUDMessage;
            if (terminalLogging)
                this.Monitor.Log("Terminal logging enabled. Will print weather updates to terminal.", LogLevel.Info);
            if (hUDMessages)
                this.Monitor.Log("HUD messages enabled. Will print weather updates to player HUD.", LogLevel.Trace);

            // Grab PRNG from EvenBetterRNG Mod API, if present
            IEvenBetterRNGAPI eBRNG = this.Helper.ModRegistry.GetApi<IEvenBetterRNGAPI>("pepoluan.EvenBetterRNG");
            if (eBRNG != null)
            {
                this.Monitor.Log("EvenBetterRNG detected. Will utilise their better random number generator.", LogLevel.Trace);
                PRNG = eBRNG.GetNewRandom();
            }
            // Make a list of all sister mods that are present so can delay console logging until all have reported in
            if (this.Helper.ModRegistry.IsLoaded("MsBontle.ClimateControl"))
            {
                trackSisters.ClimateControlPresent = true;
                this.Monitor.Log("ClimateControl detected. Enabling integration...", LogLevel.Trace);
            }
        }
        // ----------------
        // FORECAST WEATHER
        // ----------------
        // Forecast the weather once the day has started and all sister mods have reported in
        private void StartDay_WeatherForecaster(object sender, DayStartedEventArgs e)
        {
            // Check if waiting for any sister mods first
            this.Monitor.Log("Day started. Waiting for sister mods before continuing...", LogLevel.Trace);
            bool continueForecast;
            continueForecast = CheckForSistersReady();
            if (continueForecast)
            {
                this.Monitor.Log("No sister mods were loaded. Will only provide player with weather predictions.", LogLevel.Trace);
                ForecastWeather();
            }
        }

        private bool CheckForSistersReady()
        {
            // Wait until all sister mods have reported in
            bool continueForecast = true;
            foreach (PropertyInfo property in typeof(MorningUpdate).GetProperties())
            {
                if ((bool)property.GetValue(trackSisters.MorningUpdate) == false)
                {
                    continueForecast = false;
                    break;
                }
            }
            return continueForecast;
        }

        private void ForecastWeather()
        {
            // Grab information about the game's current weather state
            WeatherUtils.WeatherState weatherForecast = WeatherUtils.PopulateWeather.Populate();

            // Print appropriate weather update to SMAPI terminal
            string weatherString = WeatherMan.Predict(weatherForecast);
            BroadCast(weatherString);
            
            // Set flags back to false
            foreach (PropertyInfo property in typeof(MorningUpdate).GetProperties())
            {
                property.SetValue(trackSisters.MorningUpdate, false);
            }
        }

        // ---------
        // BROADCAST
        // ---------
        // Broadcast updates to SMAPI terminal
        private void BroadCast(string terminalUpdate)
        {
            if (terminalLogging)
            {
                this.Monitor.Log($"Broadcasting the following message to player terminal: \"{terminalUpdate}\"", LogLevel.Trace);
                this.Monitor.Log($"{terminalUpdate}", LogLevel.Info);
            }
            if (hUDMessages)
            {
                this.Monitor.Log($"Broadcasting the following message to player HUD: \"{terminalUpdate}\"", LogLevel.Trace);
                Game1.addHUDMessage(new HUDMessage($"{terminalUpdate}", ""));
            }
        }

        // ------------------
        // INTERPRET MESSAGES
        // ------------------
        // Sort messages from sister mods into expected calls
        private void ReceiveEvent(object sender, EventContainer e)
        {
            switch (e.Message.MessageType)
            {
                case MessageTypes.saveLoaded:
                    SaveLoadedMessages(e);
                    break;
                case MessageTypes.titleReturned:
                    break;
                case MessageTypes.dayStarted:
                    DayLoadedMessage(e);
                    if (CheckForSistersReady() && (terminalLogging || hUDMessages))
                        this.Monitor.Log("All sister mods reported in. Preparing to broadcast weather predictions...", LogLevel.Trace);
                        ForecastWeather();
                    break;
                default:
                    break;
            }
        }

        // Sort calls into sister mods
        private void SaveLoadedMessages(EventContainer e)
        {
            switch (e.Message.SisterMod)
            {
                case SisterMods.ClimateControl:
                    if ((!trackSisters.ClimateControl.ModelLoaded) || (trackSisters.ClimateControl.ModelType != e.Message.ModelType))
                    {
                        this.Monitor.Log("Permission granted: model not yet cached or model is different from the current cache.", LogLevel.Trace);
                        trackSisters.ClimateControl.ModelLoaded = true;
                        trackSisters.ClimateControl.ModelType = e.Message.ModelType;
                        e.Response.GoAheadToLoad = true;
                    }
                    else
                        this.Monitor.Log("Request denied: model is already cached.", LogLevel.Trace);
                    break;
                default:
                    break;
            }
        }

        private void DayLoadedMessage(EventContainer e)
        {
            switch (e.Message.SisterMod)
            {
                case SisterMods.ClimateControl:
                    if (e.Message.CouldChange)
                    {
                        this.Monitor.Log($"Acknowledged: weather successfully changed to {e.Message.WeatherType}.", LogLevel.Trace);
                        trackSisters.ClimateControl.ChangedWeather = true;
                        trackSisters.ClimateControl.ChangedToType = e.Message.WeatherType;
                    }
                    else
                    {
                        this.Monitor.Log($"Acknowledged: failed to change weather.", LogLevel.Trace);
                        trackSisters.ClimateControl.ChangedWeather = false;
                    }
                    trackSisters.MorningUpdate.ClimateControl = true;
                    e.Response.Acknowledged = true;
                    break;
                default:
                    break;
            }
        }
    }
}