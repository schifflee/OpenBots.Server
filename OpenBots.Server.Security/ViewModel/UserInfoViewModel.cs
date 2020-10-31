using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.Security.ViewModel
{
    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }
}
