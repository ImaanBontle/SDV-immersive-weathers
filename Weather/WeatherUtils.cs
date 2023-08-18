using StardewValley;
using System;
using System.Collections.Generic;
using static ImmersiveWeathers.IIWAPI;

namespace ImmersiveWeathers
{
    /// <summary>
    /// Set of utility functions related to weather information.
    /// </summary>
    internal class WeatherUtils
    {
        /// <summary>
        /// Generic container for today's and tomorrow' weather.
        /// </summary>
        internal class WeatherState
        {
            /// <summary>
            /// The weather today.
            /// </summary>
            public WeatherType WeatherToday { get; set; }
            /// <summary>
            /// The weather tomorrow.
            /// </summary>
            public WeatherType WeatherTomorrow { get; set; }
        }

        /// <summary>
        /// Populates a <see cref="WeatherState"/> object with the latest weather information.
        /// </summary>
        internal class PopulateWeather
        {
            /// <summary>
            /// Generates the populated <see cref="WeatherState"/> object.
            /// </summary>
            /// <returns>
            /// A <see cref="WeatherState"/> object.
            /// </returns>
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

            /// <summary>
            /// Checks today's weather in-game.
            /// </summary>
            /// <returns>
            /// &lt;<see langword="string"/>, <see langword="bool"/>&gt;: &lt;type of weather checked, is it active?&gt;
            /// </returns>
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

            /// <summary>
            /// Make sense of today's weather states.
            /// </summary>
            /// <param name="weatherStatesToday">Possible weather states today.</param>
            /// <returns>
            /// A <see cref="WeatherType"/> object.
            /// </returns>
            private static WeatherType ParseWeather(Dictionary<string, bool> weatherStatesToday)
            {
                WeatherType weatherNow;
                if (weatherStatesToday["stormCheck"])
                    weatherNow = WeatherType.storming;
                else if (weatherStatesToday["rainCheck"])
                    weatherNow = WeatherType.raining;
                else if (weatherStatesToday["snowCheck"])
                    weatherNow = WeatherType.snowing;
                else weatherNow = weatherStatesToday["windCheck"] ? WeatherType.windy : WeatherType.sunny;
                return weatherNow;
            }

            /// <summary>
            /// Make sense of tomorrow's weather.
            /// </summary>
            /// <param name="tomorrowState">Integer representation of tomorrow's weather.</param>
            /// <returns>
            /// A <see cref="WeatherType"/> object.
            /// </returns>
            private static WeatherType ParseWeather(int tomorrowState)
            {
                var WeatherTomorrow = tomorrowState switch
                {
                    0 or 4 or 6 => ((Game1.Date.DayOfMonth + 1) % 13 == 0) && (Game1.Date.Season == "summer") ? WeatherType.storming : WeatherType.sunny,
                    1 => WeatherType.raining,
                    2 => WeatherType.windy,
                    3 => WeatherType.storming,
                    5 => WeatherType.snowing,
                    _ => WeatherType.unknown,
                };
                return WeatherTomorrow;
            }
        }

        /// <summary>
        /// Handles translation of weather states between strings and integers.
        /// </summary>
        internal class TranslateWeatherStates
        {
            /// <summary>
            /// Translate weather type from an integer to a string.
            /// </summary>
            /// <param name="integerState">The weather type in integer form.</param>
            /// <returns>
            /// <see langword="string"/>: Weather type in string format.
            /// </returns>
            public static string TranslateTomorrow(int integerState)
            {
                string stringState = "";
                foreach (int i in Enum.GetValues(typeof(WeatherType)))
                {
                    if (integerState == i)
                    {
                        stringState = Enum.GetName(typeof(WeatherType), i);
                        break;
                    }
                }
                return stringState;
            }

            /// <summary>
            /// Translate weather type from a string to an integer.
            /// </summary>
            /// <param name="stringState">The weather type as a string.</param>
            /// <returns>
            /// <see langword="int"/>: Weather type in integer form.
            /// </returns>
            public static int TranslateTomorrow(string stringState)
            {
                int integerState = 7;
                foreach (string name in Enum.GetNames(typeof(WeatherType)))
                {
                    if (stringState == name)
                    {
                        integerState = (int)Enum.Parse(typeof(WeatherType), name);
                        break;
                    }
                }
                return integerState;
            }
        }
    }
}
