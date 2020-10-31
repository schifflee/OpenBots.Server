using OpenBots.Server.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.Model.Security
{
    public class EmailFilter : NamedEntity, INameIDPair
    {
        public EmailFilterType FilterType { get; set; }
    }

    public enum EmailFilterType : int
    { 
        Blacklist = 0,
        Whitelist = 1
    }

}
