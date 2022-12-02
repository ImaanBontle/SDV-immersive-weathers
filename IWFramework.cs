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
    // Mod API
    public class IWAPI
    {
        // Create object with weather information
        //public string GetWeatherInfo(bool grabTomorrow)
        //{
        //    WeatherState weatherInfo = new();
        //    weatherInfo = PopulateWeather.Populate(weatherInfo);
        //    int listIndex;
        //    if (grabTomorrow)
        //        listIndex = 1;
        //    else
        //        listIndex = 0;
        //    string[] list = {
        //        weatherInfo.WeatherToday.ToString(),
        //        weatherInfo.WeatherTomorrow.ToString(),
        //    };
        //    return list[listIndex];
        //}

        public Tuple<string,string> GetWeatherInfo()
        {
            WeatherState weatherInfo = new();
            weatherInfo = PopulateWeather.Populate(weatherInfo);
            return new Tuple<string, string>(weatherInfo.WeatherToday.ToString(), weatherInfo.WeatherTomorrow.ToString());
        }

        // Generate container for weather information
        public class WeatherState
        {
            // Define relevant properties
            public WeatherType WeatherToday { get; set; }
            public WeatherType WeatherTomorrow { get; set; }

        }

        // List of all possible weather states
        public enum WeatherType
        {
            Sunny,
            Windy,
            Raining,
            Storming,
            Snowing,
            Unknown
        }
    }

    internal sealed class IWFramework : Mod
    {
        // Share APIs
        public override object GetApi()
        {
            return new IWAPI();
        }

        // Main method
        public override void Entry(IModHelper helper)
        {
            // When day begins, generate a weather forecast
            this.Helper.Events.GameLoop.DayStarted += StartDay_WeatherMachine; // temporarily disable while testing CC
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

    // Populate a weatherState object with current weather information
    public class PopulateWeather
    {
        // Generate properties
        public static IWAPI.WeatherState Populate(IWAPI.WeatherState weatherState)
        {
            // Check today's weather
            Dictionary<string, bool> weatherStatesToday = CheckWeather();
            weatherState.WeatherToday = ParseWeather(weatherStatesToday);

            // Check tomorrow's weather
            int tomorrowState = Game1.weatherForTomorrow;
            weatherState.WeatherTomorrow = ParseWeather(tomorrowState);

            return weatherState;
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
        private static IWAPI.WeatherType ParseWeather(Dictionary<string, bool> weatherStatesToday)
        {
            IWAPI.WeatherType weatherNow;
            if (weatherStatesToday["stormCheck"] == true)
                weatherNow = IWAPI.WeatherType.Storming;
            else if (weatherStatesToday["rainCheck"] == true)
                weatherNow = IWAPI.WeatherType.Raining;
            else if (weatherStatesToday["snowCheck"] == true)
                weatherNow = IWAPI.WeatherType.Snowing;
            else if (weatherStatesToday["windCheck"] == true)
                weatherNow = IWAPI.WeatherType.Windy;
            else
                weatherNow = IWAPI.WeatherType.Sunny;
            return weatherNow;
        }

        // Parse tomorrow's weather
        private static IWAPI.WeatherType ParseWeather(int tomorrowState)
        {
            IWAPI.WeatherType WeatherTomorrow;
            if ((tomorrowState == 0) || (tomorrowState == 4) || (tomorrowState == 6))
                WeatherTomorrow = IWAPI.WeatherType.Sunny;
            else if (tomorrowState == 1)
                WeatherTomorrow = IWAPI.WeatherType.Raining;
            else if (tomorrowState == 2)
                WeatherTomorrow = IWAPI.WeatherType.Windy;
            else if (tomorrowState == 3)
                WeatherTomorrow = IWAPI.WeatherType.Storming;
            else if (tomorrowState == 5)
                WeatherTomorrow = IWAPI.WeatherType.Snowing;
            else
                WeatherTomorrow = IWAPI.WeatherType.Unknown;
            return WeatherTomorrow;
        }
    }
}