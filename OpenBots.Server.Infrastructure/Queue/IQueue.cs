using System;
using System.Threading.Tasks;

namespace OpenBots.Server.Infrastructure
{
    public interface IQueue
    {
        Task Close();
        Task Dequeue(TimeSpan waitTime);
        Task Enqueue<T>(T eventEntity);
        void Init();
    }
}