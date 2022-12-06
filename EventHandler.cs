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
    public class DialTheMatrix
    {
        public EventHandler<EnterTheMatrx> PickUpNeo;
        public void HeIsTheOne(RedPillOrBluePill incomingMessage)
        {
            EnterTheMatrx enterTheMatrix = new()
            {
                MessageFromTrinity = incomingMessage.MessageFromTrinity
            };
            PickUpNeo.Invoke(this, enterTheMatrix);
            incomingMessage.MessageFromNeo = enterTheMatrix.MessageFromNeo;
        }
    }

    // ----------------
    // EVENT PROPERTIES
    // ----------------
    // How to attach in-out information to the event handler
    public class EnterTheMatrx : EventArgs
    {
        public MessageFromTrinity MessageFromTrinity { get; set; }
        public MessageFromNeo MessageFromNeo { get; set; }
        public EnterTheMatrx()
        {
            MessageFromTrinity = new MessageFromTrinity();
            MessageFromNeo = new MessageFromNeo();
        }
    }

    // -----------------
    // INCOMING MESSAGES
    // -----------------
    // All possible incoming messages
    public class MessageFromTrinity
    {
        public IWAPI.FollowTheWhiteRabbit SisterMod { get; set; }
        public IWAPI.TypeOfMessage MessageType { get; set; }
        public IWAPI.WeatherModel ModelType { get; set; }
    }

    // -----------------
    // OUTGOING MESSAGES
    // -----------------
    // All possible messages to sister mods
    public class MessageFromNeo
    {
        public bool GoAheadToLoad { get; set; }
    }
}
