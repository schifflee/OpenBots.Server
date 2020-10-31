using OpenBots.Server.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.ViewModel
{
    public class NextJobViewModel
    {
        public bool IsJobAvailable { get; set; }
        public Job AssignedJob { get; set; }
    }
}
