using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmersiveWeathers
{
    // -------------
    // EVENT HANDLER
    // -------------
    // Custom event handler to transmit external information internally to the framework
    internal class EventManager
    {
        public EventHandler<EventContainer> SendToFramework;
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
    internal class EventContainer : EventArgs
    {
        public Message Message { get; set; }
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
    // All possible incoming messages
    public class Message
    {
        public IWAPI.SisterMods SisterMod { get; set; }
        public IWAPI.MessageTypes MessageType { get; set; }
        public IWAPI.WeatherModel ModelType { get; set; }
        public IWAPI.WeatherType WeatherType { get; set; }
        public bool CouldChange { get; set; }
    }

    // -----------------
    // OUTGOING MESSAGES
    // -----------------
    // All possible messages to sister mods
    public class Response
    {
        public bool GoAheadToLoad { get; set; }
        public bool Acknowledged { get; set; }
    }
}
