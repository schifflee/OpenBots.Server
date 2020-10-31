using OpenBots.Server.Model.Core;
using System;

namespace OpenBots.Server.Infrastructure
{
    public interface IQueuePublisher : IDisposable
    {
        void Init();
        void PublishEvent<T>(T eventEntity);

    }
}