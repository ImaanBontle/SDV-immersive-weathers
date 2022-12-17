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
    /// <summary>
    /// Handles all weather prediction functions.
    /// </summary>
    internal class WeatherMan
    {
        /// <summary>
        /// Prepare weather statements for broadcasting.
        /// </summary>
        /// <param name="weatherForecast">The forecasted weather for today and tomorrow.</param>
        /// <returns>
        /// <see langword="string"/>: Statement about weather today and tomorrow.
        /// </returns>
        public static string Predict(WeatherUtils.WeatherState weatherForecast)
        {
            // Today's weather
            string weatherStringToday = TodayWeather(weatherForecast);

            // Tomorrow's weather
            string weatherStringTomorrow = TomorrowWeather(weatherForecast);

            string weatherString = $"{weatherStringToday} {weatherStringTomorrow}";
            return weatherString;
        }

        /// <summary>
        /// Translates today's weather into a string.
        /// </summary>
        /// <param name="weatherForecast">The forecasted weather for today and tomorrow.</param>
        /// <returns>
        /// <see langword="string"/>: Statement about today's weather.
        /// </returns>
        private static string TodayWeather(WeatherUtils.WeatherState weatherForecast)
        {
            string weatherStringToday = "";
            switch (weatherForecast.WeatherToday)
            {
                case IIWAPI.WeatherType.sunny:
                    weatherStringToday = "It is sunny today.";
                    break;
                case IIWAPI.WeatherType.windy:
                    weatherStringToday = "It is windy today.";
                    break;
                case IIWAPI.WeatherType.raining:
                    weatherStringToday = "It is raining today.";
                    break;
                case IIWAPI.WeatherType.storming:
                    weatherStringToday = "It is stormy today.";
                    break;
                case IIWAPI.WeatherType.snowing:
                    weatherStringToday = "It is snowing today.";
                    break;
            }
            return weatherStringToday;
        }

        /// <summary>
        /// Translates tomorrow's weather into a string.
        /// </summary>
        /// <param name="weatherForecast">The forecasted weather for today and tomorrow.</param>
        /// <returns>
        /// <see langword="string"/>: Statement about tomorrows's weather.
        /// </returns>
        private static string TomorrowWeather(WeatherUtils.WeatherState weatherForecast)
        {
            string weatherStringTomorrow = "";
            switch (weatherForecast.WeatherTomorrow)
            {
                case IIWAPI.WeatherType.sunny:
                    weatherStringTomorrow = "Tomorrow, it will be sunny.";
                    break;
                case IIWAPI.WeatherType.windy:
                    weatherStringTomorrow = "Tomorrow, it will be windy.";
                    break;
                case IIWAPI.WeatherType.raining:
                    weatherStringTomorrow = "Tomorrow, it will be rainy.";
                    break;
                case IIWAPI.WeatherType.storming:
                    weatherStringTomorrow = "Tomorrow, it will be storming.";
                    break;
                case IIWAPI.WeatherType.snowing:
                    weatherStringTomorrow = "Tomorrow, it will be snowing.";
                    break;
                case IIWAPI.WeatherType.unknown:
                    weatherStringTomorrow = "Huh, that's weird. I can't make sense of tomorrow's weather!";
                    break;
            }
            return weatherStringTomorrow;
        }
    }
}
