using System;

namespace ImmersiveWeathers
{
    // -------------
    // EVENT HANDLER
    // -------------
    /// <summary>
    /// Custom event manager to transmit external information internally to the framework.
    /// </summary>
    public class EventManager
    {
        /// <summary>
        /// <see cref="EventHandler"/> that transfers the information to the framework.
        /// </summary>
        public EventHandler<EventContainer> SendToFramework;
        /// <summary>
        /// Method for triggering the event.
        /// </summary>
        /// <param name="Message">The message to transmit and append a reply to.</param>
        public void GrabReply(MessageContainer Message)
        {
            EventContainer eventContainer = new()
            {
                Message = Message.Message
            };
            SendToFramework.Invoke(this, eventContainer);
            Message.Response = eventContainer.Response;
        }
    }

    // ----------------
    // EVENT PROPERTIES
    // ----------------
    // How to attach in-out information to the event handler
    /// <summary>
    /// Custom message properties for event.
    /// </summary>
    public class EventContainer : EventArgs
    {
        /// <summary>
        /// The message container sent to the framework.
        /// </summary>
        public Message Message { get; set; }
        /// <summary>
        /// The resonse container returned to the sender.
        /// </summary>
        public Response Response { get; set; }
        public EventContainer()
        {
            Message = new Message();
            Response = new Response();
        }
    }

    // -----------------
    // INCOMING MESSAGES
    // -----------------
    /// <summary>
    /// <see cref="Enum"/> of all possible incoming messages.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// The sister mod attempting to contact the framework.
        /// </summary>
        public IIWAPI.SisterMods SisterMod { get; set; }
        /// <summary>
        /// The type of message being broadcast.
        /// </summary>
        public IIWAPI.MessageTypes MessageType { get; set; }
        /// <summary>
        /// The weather model used for weather changes.
        /// </summary>
        public IIWAPI.WeatherModel ModelType { get; set; }
        /// <summary>
        /// The type of weather relevant to the message.
        /// </summary>
        public IIWAPI.WeatherType WeatherType { get; set; }
        /// <summary>
        /// If weather should be changed, was it?
        /// </summary>
        public bool CouldChange { get; set; }
    }

    // -----------------
    // OUTGOING MESSAGES
    // -----------------
    /// <summary>
    /// All possible messages to sister mods from framework.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Load the weather data model.
        /// </summary>
        public bool GoAheadToLoad { get; set; }
        /// <summary>
        /// Message acknowledged.
        /// </summary>
        public bool Acknowledged { get; set; }
    }
}
