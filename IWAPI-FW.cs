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
            sunny = 0,
            raining = 1,
            windy = 2,
            storming = 3,
            festival = 4,
            snowing = 5,
            wedding = 6,
            unknown = 7
        }

        // List of all possible seasons
        public enum SeasonType
        {
            spring = 0,
            summer = 1,
            fall = 2,
            winter = 3
        }

        // List of weather-models
        public enum WeatherModel
        {
            none = 0,
            custom = 1,
            standard = 2
        }

        // List of supported sister mods
        public enum SisterMods
        {
            ClimateControl = 0
        }

        // Broadcast types
        public enum MessageTypes
        {
            saveLoaded = 0,
            titleReturned = 1,
            dayStarted = 2
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

        // How framework should respond to request
        public void ProcessMessage(MessageContainer Message)
        {
            IWFramework.eventManager.GrabReply(Message);
        }
    }

    // Class carrier for in-out messages
    public class MessageContainer
    {
        public Message Message { get; set; }
        public Response Response { get; set; }
        public MessageContainer()
        {
            Message = new Message();
            Response = new Response();
        }
    }
}
