using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.ViewModel
{
    public class PendingAccessRequest
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
