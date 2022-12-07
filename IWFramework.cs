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

// TODO: Update API <----- v0.5.0
// TODO: Implement broadcast in Framework and cache values <----- v0.5.0
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
            // Grab PRNG from EvenBetterRNG Mod API, if present
            IEvenBetterRNGAPI eBRNG = this.Helper.ModRegistry.GetApi<IEvenBetterRNGAPI>("pepoluan.EvenBetterRNG");
            if (eBRNG != null)
            {
                PRNG = eBRNG.GetNewRandom();
            }
            // Make a list of all sister mods that are present so can delay console logging until all have reported in
            if (this.Helper.ModRegistry.IsLoaded("MsBontle.ClimateControl"))
                trackSisters.ClimateControlPresent = true;
        }
        // ----------------
        // FORECAST WEATHER
        // ----------------
        // Forecast the weather once the day has started and all sister mods have reported in
        private void StartDay_WeatherForecaster(object sender, DayStartedEventArgs e)
        {
            // Check if waiting for any sister mods first
            bool continueForecast;
            continueForecast = CheckForSistersReady();
            if (continueForecast)
            {
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
            this.Monitor.Log($"{terminalUpdate}", LogLevel.Info);
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
                    if (CheckForSistersReady())
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
                        trackSisters.ClimateControl.ModelLoaded = true;
                        trackSisters.ClimateControl.ModelType = e.Message.ModelType;
                        e.Response.GoAheadToLoad = true;
                    }
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
                        trackSisters.ClimateControl.ChangedWeather = true;
                        trackSisters.ClimateControl.ChangedToType = e.Message.WeatherType;
                    }
                    else
                    {
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