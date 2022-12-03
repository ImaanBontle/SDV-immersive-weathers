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
            WeatherUtils.WeatherState weatherInfo = WeatherUtils.PopulateWeather.Populate();
            return new Tuple<string, string>(weatherInfo.WeatherToday.ToString(), weatherInfo.WeatherTomorrow.ToString());
        }

        // Translate weather information between strings and integers
        public string TranslateTomorrowStates(int integerState)
        {
            return WeatherUtils.TranslateWeatherStates.TranslateTomorrow(integerState);
        }
        public int TranslateTomorrowStates(string stringState)
        {
            return WeatherUtils.TranslateWeatherStates.TranslateTomorrow(stringState);
        }

        // Grab a random number from the PRNG
        public double RollTheDice()
        {
            return IWFramework.PRNG.NextDouble();
        }
        public int RollTheDiceInt()
        {
            return IWFramework.PRNG.Next();
        }
    }
}
