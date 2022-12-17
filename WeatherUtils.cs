using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks.Dataflow;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using static ImmersiveWeathers.IIWAPI;

namespace ImmersiveWeathers
{
    internal class WeatherUtils
    {
        // Generate container for weather information
        internal class WeatherState
        {
            // Define relevant properties
            public IIWAPI.WeatherType WeatherToday { get; set; }
            public IIWAPI.WeatherType WeatherTomorrow { get; set; }
        }

        // Populate a weatherState object with current weather information
        internal class PopulateWeather
        {
            // Generate properties
            public static WeatherState Populate()
            {
                // Create container instance
                WeatherState weatherState = new();

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
            private static IIWAPI.WeatherType ParseWeather(Dictionary<string, bool> weatherStatesToday)
            {
                IIWAPI.WeatherType weatherNow;
                if (weatherStatesToday["stormCheck"])
                    weatherNow = IIWAPI.WeatherType.storming;
                else if (weatherStatesToday["rainCheck"])
                    weatherNow = IIWAPI.WeatherType.raining;
                else if (weatherStatesToday["snowCheck"])
                    weatherNow = IIWAPI.WeatherType.snowing;
                else if (weatherStatesToday["windCheck"])
                    weatherNow = IIWAPI.WeatherType.windy;
                else
                    weatherNow = IIWAPI.WeatherType.sunny;
                return weatherNow;
            }

            // Parse tomorrow's weather
            private static IIWAPI.WeatherType ParseWeather(int tomorrowState)
            {
                IIWAPI.WeatherType WeatherTomorrow;
                switch (tomorrowState)
                {
                    case 0:
                    case 4:
                    case 6:
                        if (((Game1.Date.DayOfMonth + 1)%13 == 0) && (Game1.Date.Season == "summer"))
                            WeatherTomorrow = IIWAPI.WeatherType.storming;
                        else
                            WeatherTomorrow = IIWAPI.WeatherType.sunny;
                        break;
                    case 1:
                        WeatherTomorrow = IIWAPI.WeatherType.raining;
                        break;
                    case 2:
                        WeatherTomorrow = IIWAPI.WeatherType.windy;
                        break;
                    case 3:
                        WeatherTomorrow = IIWAPI.WeatherType.storming;
                        break;
                    case 5:
                        WeatherTomorrow = IIWAPI.WeatherType.snowing;
                        break;
                    default:
                        WeatherTomorrow = IIWAPI.WeatherType.unknown;
                        break;
                }
                return WeatherTomorrow;
            }
        }

        internal class TranslateWeatherStates
        {
            public static string TranslateTomorrow(int integerState)
            {
                string stringState = "";
                foreach (int i in Enum.GetValues(typeof(IIWAPI.WeatherType)))
                {
                    if (integerState == i)
                    {
                        stringState = Enum.GetName(typeof(IIWAPI.WeatherType), i);
                        break;
                    }
                }
                return stringState;
            }

            public static int TranslateTomorrow(string stringState)
            {
                int integerState = 7;
                foreach (string name in Enum.GetNames(typeof(IIWAPI.WeatherType)))
                {
                    if (stringState == name)
                    {
                        integerState = (int)Enum.Parse(typeof(IIWAPI.WeatherType), name);
                        break;
                    }
                }
                return integerState;
            }
        }
    }
}
