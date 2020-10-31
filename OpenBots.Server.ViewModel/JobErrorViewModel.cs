
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.ViewModel
{
    public class JobErrorViewModel
    {
        public string ErrorReason { get; set; }
        public string ErrorCode { get; set; }
        public string SerializedErrorString { get; set; }
    }
}
