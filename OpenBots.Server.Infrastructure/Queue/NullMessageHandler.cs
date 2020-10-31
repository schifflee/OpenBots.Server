using OpenBots.Server.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.Infrastructure
{
    public class NullMessageHandler : IMessageHandler
    {
        public void OnMessage(MessageEnvelope envelope)
        {
            // Do Nothing
        }
    }
}
