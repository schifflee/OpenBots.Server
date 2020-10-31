using OpenBots.Server.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.Infrastructure
{
    public interface IMessageHandler
    {
        void OnMessage(MessageEnvelope envelope);
    }
}
