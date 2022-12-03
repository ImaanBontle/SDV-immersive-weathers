using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks.Dataflow;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using static ImmersiveWeathers.IWAPI;

namespace ImmersiveWeathers
{
    public class WeatherUtils
    {
        // Generate container for weather information
        public class WeatherState
        {
            // Define relevant properties
            public IWAPI.WeatherType WeatherToday { get; set; }
            public IWAPI.WeatherType WeatherTomorrow { get; set; }
        }

        // Populate a weatherState object with current weather information
        public class PopulateWeather
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
                        integerState = (int)Enum.Parse(typeof(IWAPI.WeatherType), name);
                        break;
                    }
                }
                return integerState;
            }
        }
    }
}
