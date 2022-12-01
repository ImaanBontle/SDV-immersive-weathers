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
        public override void Entry(IModHelper helper)
        {
            this.Helper.Events.GameLoop.DayStarted += StartDay_WeatherMachine;
        }

        private void StartDay_WeatherMachine(object sender, DayStartedEventArgs e)
        {
            // Grab information about the weather
            WeatherState weatherForecast = new WeatherState();

            // Print weather update to SMAPI terminal
            WeatherMan(weatherForecast);
        }

        /*
        // Checks tomorrow's forecast
        private static string WeatherForecast()
        {
            int tomorrowState = Game1.weatherForTomorrow;
            string weatherTomorrow;
            if (tomorrowState == 0)
            {
                weatherTomorrow = "sunny";
            }
            else if (tomorrowState == 1)
            {
                weatherTomorrow = "rain";
            }
            else
        }
        */

        // Prepares weather statements for TV.
        private void WeatherMan(WeatherState weatherForecast)
        {
            // Today's weather
            string weatherStringToday = TodayWeather(weatherForecast);

            /*
            // Tomorrow's weather
            string weatherStringTomorrow = TomorrowWeather(weatherTomorrow);
            */

            string weatherString = weatherStringToday;
            BroadCast(weatherString);
        }

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

        private void BroadCast(string weatherString)
        {
            this.Monitor.Log($"{weatherString}", LogLevel.Info);
        }
    }

    internal class WeatherState
    {
        // Relevant properties
        public WeatherType WeatherToday { get; set; }
        public WeatherType WeatherTomorrow { get; set; }

        // Generate properties
        public WeatherState()
        {
            // Check today's weather
            Dictionary<string, bool> weatherStatesToday = CheckWeather();
            WeatherToday = ParseWeather(weatherStatesToday);
        }

        // Checks current weather states
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

        // Parses today's weather
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
    }

    internal enum WeatherType
    {
        Sunny,
        Windy,
        Raining,
        Storming,
        Snowing
    }
}