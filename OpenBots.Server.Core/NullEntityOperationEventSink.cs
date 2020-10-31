using OpenBots.Server.Core;
using OpenBots.Server.Model;
using OpenBots.Server.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.Core
{
    public class NullEntityOperationEventSink : IEntityOperationEventSink
    {
        public void RaiseOperationCompletedEvent(string change)
        {
            // Do Nothing
        }
    }
}
