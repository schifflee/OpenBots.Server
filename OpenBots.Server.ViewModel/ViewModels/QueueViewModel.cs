using OpenBots.Server.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.ViewModel
{
    public class QueueViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public int MaxRetryCount { get; set; }
    }
}
