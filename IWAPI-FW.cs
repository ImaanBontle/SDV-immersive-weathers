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
    /// ImmersiveWeathers API.
    /// </summary>
    public class IIWAPI
    {
        /// <summary>
        /// <see cref="Enum"/> of all possible weather states.
        /// </summary>
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

        /// <summary>
        /// <see cref="Enum"/> of all possible seasons.
        /// </summary>
        public enum SeasonType
        {
            spring = 0,
            summer = 1,
            fall = 2,
            winter = 3
        }

        /// <summary>
        /// <see cref="Enum"/> of all possible weather models.
        /// </summary>
        public enum WeatherModel
        {
            none = 0,
            custom = 1,
            standard = 2
        }

        /// <summary>
        /// <see cref="Enum"/> of all supported sister mods.
        /// </summary>
        public enum SisterMods
        {
            ClimateControl = 0
        }

        /// <summary>
        /// <see cref="Enum"/> of all possible messages to the framework.
        /// </summary>
        public enum MessageTypes
        {
            saveLoaded = 0,
            titleReturned = 1,
            dayStarted = 2
        }

        /// <summary>
        /// Request information about today's and tomorrow's weather.
        /// </summary>
        /// <returns>
        /// <see cref="Tuple"/>&lt;<see langword="string"/>, <see langword="string"/>&gt;: Weather today, Weather tomorrow.
        /// </returns>
        public Tuple<string, string> GetWeatherInfo()
        {
            WeatherUtils.WeatherState weatherInfo = WeatherUtils.PopulateWeather.Populate();
            return new Tuple<string, string>(weatherInfo.WeatherToday.ToString(), weatherInfo.WeatherTomorrow.ToString());
        }

        /// <summary>
        /// Translate weather type from an integer to a string.
        /// </summary>
        /// <param name="integerState">The weather type in integer form.</param>
        /// <returns>
        /// <see langword="string"/>: Weather type in string format.
        /// </returns>
        public string TranslateTomorrowStates(int integerState)
        {
            return WeatherUtils.TranslateWeatherStates.TranslateTomorrow(integerState);
        }

        /// <summary>
        /// Translate weather type from a string to an integer.
        /// </summary>
        /// <param name="stringState">The weather type as a string.</param>
        /// <returns>
        /// <see langword="int"/>: Weather type in integer form.
        /// </returns>
        public int TranslateTomorrowStates(string stringState)
        {
            return WeatherUtils.TranslateWeatherStates.TranslateTomorrow(stringState);
        }

        /// <summary>
        /// Grab a random double between 0 and 1.
        /// </summary>
        /// <returns>
        /// <see langword="double"/>: Random double between 0 and 1.
        /// </returns>
        public double RollTheDice()
        {
            return IWFramework.s_pRNG.NextDouble();
        }

        /// <summary>
        /// Grab a random integer.
        /// </summary>
        /// <returns>
        /// <see langword="int"/>: Random integer.
        /// </returns>
        public int RollTheDiceInt()
        {
            return IWFramework.s_pRNG.Next();
        }

        /// <summary>
        /// Process a message for the framework.
        /// </summary>
        /// <remarks>Appends a reply to the message. See <see cref="Response"/>.</remarks>
        /// <param name="Message">The message for the framework.</param>
        public void ProcessMessage(MessageContainer Message)
        {
            IWFramework.s_eventManager.GrabReply(Message);
        }
    }

    /// <summary>
    /// Container for in-out messages between the framework and sister mods.
    /// </summary>
    public class MessageContainer
    {
        /// <summary>
        /// The message for the framework.
        /// </summary>
        public Message Message { get; set; }
        /// <summary>
        /// The response to the sender.
        /// </summary>
        public Response Response { get; set; }
        public MessageContainer()
        {
            Message = new Message();
            Response = new Response();
        }
    }
}
