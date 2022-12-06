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
        public void HeIsTheOne()
        {
            EnterTheMatrx enterTheMatrix = new()
            {
            };
            PickUpNeo.Invoke(this, enterTheMatrix);
        }
    }

    // ----------------
    // EVENT PROPERTIES
    // ----------------
    // How to attach in-out information to the event handler
    public class EnterTheMatrx : EventArgs
    {
    }
}
