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
            weatherForecast = PopulateWeather.Populate(weatherForecast);

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

    // Handle weather predictions
    internal class WeatherMan
    {
        // Prepare weather statements for SMAPI terminal
        public static string Predict(IWAPI.WeatherState weatherForecast)
        {
            // Today's weather
            string weatherStringToday = TodayWeather(weatherForecast);

            // Tomorrow's weather
            string weatherStringTomorrow = TomorrowWeather(weatherForecast);

            string weatherString = $"{weatherStringToday} {weatherStringTomorrow}";
            return weatherString;
        }

        // Translate today's weather state into a string.
        private static string TodayWeather(IWAPI.WeatherState weatherForecast)
        {
            string weatherStringToday = "";
            switch (weatherForecast.WeatherToday)
            {
                case IWAPI.WeatherType.Sunny:
                    weatherStringToday = "It is sunny today.";
                    break;
                case IWAPI.WeatherType.Windy:
                    weatherStringToday = "It is windy today.";
                    break;
                case IWAPI.WeatherType.Raining:
                    weatherStringToday = "It is raining today.";
                    break;
                case IWAPI.WeatherType.Storming:
                    weatherStringToday = "It is stormy today.";
                    break;
                case IWAPI.WeatherType.Snowing:
                    weatherStringToday = "It is snowing today.";
                    break;
            }
            return weatherStringToday;
        }

        // Translate tomorrow's weather state into a string.
        private static string TomorrowWeather(IWAPI.WeatherState weatherForecast)
        {
            string weatherStringTomorrow = "";
            switch (weatherForecast.WeatherTomorrow)
            {
                case IWAPI.WeatherType.Sunny:
                    weatherStringTomorrow = "Tomorrow, it will be sunny.";
                    break;
                case IWAPI.WeatherType.Windy:
                    weatherStringTomorrow = "Tomorrow, it will be windy.";
                    break;
                case IWAPI.WeatherType.Raining:
                    weatherStringTomorrow = "Tomorrow, it will be rainy.";
                    break;
                case IWAPI.WeatherType.Storming:
                    weatherStringTomorrow = "Tomorrow, it will be storming.";
                    break;
                case IWAPI.WeatherType.Snowing:
                    weatherStringTomorrow = "Tomorrow, it will be snowing.";
                    break;
                case IWAPI.WeatherType.Unknown:
                    weatherStringTomorrow = "Huh, that's weird. I can't make sense of tomorrow's weather!";
                    break;
            }
            return weatherStringTomorrow;
        }
    }
}