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
        // Main method
        public override void Entry(IModHelper helper)
        {
            // When day begins, generate a weather forecast
            this.Helper.Events.GameLoop.DayStarted += StartDay_WeatherMachine;
        }

        // Handle weather forecasting steps
        private void StartDay_WeatherMachine(object sender, DayStartedEventArgs e)
        {
            // Grab information about the game's current weather states
            WeatherState weatherForecast = new WeatherState();

            // Print appropriate weather update to SMAPI terminal
            WeatherMan(weatherForecast);
        }

        // Prepare weather statements for SMAPI terminal
        private void WeatherMan(WeatherState weatherForecast)
        {
            // Today's weather
            string weatherStringToday = TodayWeather(weatherForecast);
                        
            // Tomorrow's weather
            string weatherStringTomorrow = TomorrowWeather(weatherForecast);
            
            string weatherString = $"{weatherStringToday} {weatherStringTomorrow}";
            BroadCast(weatherString);
        }

        // Translate today's weather state into a string.
        private static string TodayWeather(WeatherState weatherForecast)
        {
            string weatherStringToday = "";
            switch (weatherForecast.WeatherToday)
            {
                case WeatherType.Sunny:
                    weatherStringToday = "It is sunny today.";
                    break;
                case WeatherType.Windy:
                    weatherStringToday = "It is windy today.";
                    break;
                case WeatherType.Raining:
                    weatherStringToday = "It is raining today.";
                    break;
                case WeatherType.Storming:
                    weatherStringToday = "It is stormy today.";
                    break;
                case WeatherType.Snowing:
                    weatherStringToday = "It is snowing today.";
                    break;
            }
            return weatherStringToday;
        }

        // Translate tomorrow's weather state into a string.
        private static string TomorrowWeather(WeatherState weatherForecast)
        {
            string weatherStringTomorrow = "";
            switch (weatherForecast.WeatherTomorrow)
            {
                case WeatherType.Sunny:
                    weatherStringTomorrow = "Tomorrow, it will be sunny.";
                    break;
                case WeatherType.Windy:
                    weatherStringTomorrow = "Tomorrow, it will be windy.";
                    break;
                case WeatherType.Raining:
                    weatherStringTomorrow = "Tomorrow, it will be rainy.";
                    break;
                case WeatherType.Storming:
                    weatherStringTomorrow = "Tomorrow, it will be storming.";
                    break;
                case WeatherType.Snowing:
                    weatherStringTomorrow = "Tomorrow, it will be snowing.";
                    break;
                case WeatherType.Unknown:
                    weatherStringTomorrow = "Huh, that's weird. I can't make sense of tomorrow's weather!";
                    break;
            }
            return weatherStringTomorrow;
        }

        // Broadcast weather to SMAPI terminal
        private void BroadCast(string weatherString)
        {
            this.Monitor.Log($"{weatherString}", LogLevel.Info);
        }
    }

    // Generate object containing all weather information
    internal class WeatherState
    {
        // Define relevant properties
        public WeatherType WeatherToday { get; set; }
        public WeatherType WeatherTomorrow { get; set; }

        // Generate properties
        public WeatherState()
        {
            // Check today's weather
            Dictionary<string, bool> weatherStatesToday = CheckWeather();
            WeatherToday = ParseWeather(weatherStatesToday);

            // Check tomorrow's weather
            int tomorrowState = Game1.weatherForTomorrow;
            WeatherTomorrow = ParseWeather(tomorrowState);
        }

        // Check today's weather states
        private static Dictionary<string, bool> CheckWeather()
        {
            Dictionary<string, bool> weatherStatesToday = new(){
                { "rainCheck", Game1.isRaining },
                { "stormCheck", Game1.isLightning },
                { "windCheck", Game1.isDebrisWeather },
                { "snowCheck", Game1.isSnowing },
            };
            return weatherStatesToday;
        }

        // Parse today's weather states
        private static WeatherType ParseWeather(Dictionary<string, bool> weatherStatesToday)
        {
            WeatherType weatherNow;
            if (weatherStatesToday["stormCheck"] == true)
                weatherNow = WeatherType.Storming;
            else if (weatherStatesToday["rainCheck"] == true)
                weatherNow = WeatherType.Raining;
            else if (weatherStatesToday["snowCheck"] == true)
                weatherNow = WeatherType.Snowing;
            else if (weatherStatesToday["windCheck"] == true)
                weatherNow = WeatherType.Windy;
            else
                weatherNow = WeatherType.Sunny;
            return weatherNow;
        }

        // Parse tomorrow's weather
        private static WeatherType ParseWeather(int tomorrowState)
        {
            WeatherType WeatherTomorrow;
            if ((tomorrowState == 0) || (tomorrowState == 4) || (tomorrowState == 6))
                WeatherTomorrow = WeatherType.Sunny;
            else if (tomorrowState == 1)
                WeatherTomorrow = WeatherType.Raining;
            else if (tomorrowState == 2)
                WeatherTomorrow = WeatherType.Windy;
            else if (tomorrowState == 3)
                WeatherTomorrow = WeatherType.Storming;
            else if (tomorrowState == 5)
                WeatherTomorrow = WeatherType.Snowing;
            else
                WeatherTomorrow = WeatherType.Unknown;
            return WeatherTomorrow;
        }
    }

    // List of all possible weather states
    internal enum WeatherType
    {
        Sunny,
        Windy,
        Raining,
        Storming,
        Snowing,
        Unknown
    }
}