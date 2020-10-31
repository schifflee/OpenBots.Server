using OpenBots.Server.Model;
using OpenBots.Server.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.Core
{
     public interface IEntityOperationEventSink
    {
         void RaiseOperationCompletedEvent(string change);
    }
}
