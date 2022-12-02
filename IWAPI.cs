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
    // Mod API - all exposed methods, fields and properties
    public class IWAPI
    {
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
            Sunny = 0,
            Raining = 1,
            Windy = 2,
            Storming = 3,
            Festival = 4,
            Snowing = 5,
            Wedding = 6,
            Unknown = 7
        }

        // Create Tuple with weather information
        public Tuple<string, string> GetWeatherInfo()
        {
            WeatherState weatherInfo = new();
            weatherInfo = PopulateWeather.Populate(weatherInfo);
            return new Tuple<string, string>(weatherInfo.WeatherToday.ToString(), weatherInfo.WeatherTomorrow.ToString());
        }

        // Translate weather information between strings and integers
        public string TranslateTomorrowStates(int integerState)
        {
            return TranslateWeatherStates.TranslateTomorrow(integerState);
        }
        public int TranslateTomorrowStates(string stringState)
        {
            return TranslateWeatherStates.TranslateTomorrow(stringState);
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

    public class TranslateWeatherStates
    {
        public static string TranslateTomorrow(int integerState)
        {
            string stringState = "";
            foreach (int i in Enum.GetValues(typeof(IWAPI.WeatherType)))
            {
                if (integerState == i)
                {
                    stringState = Enum.GetName(typeof(IWAPI.WeatherType), i);
                    break;
                }
            }
            return stringState;
        }

        public static int TranslateTomorrow(string stringState)
        {
            int integerState = 7;
            foreach (string name in Enum.GetNames(typeof(IWAPI.WeatherType)))
            {
                if (stringState == name)
                {
                    integerState = (int) Enum.Parse(typeof(IWAPI.WeatherType), name);
                    break;
                }
            }
            return integerState;
        }
    }
}
