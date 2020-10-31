using System;
using System.Collections.Generic;
using System.Text;
using OpenBots.Server.Model.Identity;
using OpenBots.Server.Model.Core;
using OpenBots.Server.Model.Membership;
#nullable enable

namespace OpenBots.Server.Model
{
    public class OrgTest : NamedEntity
    {
        public OrgTest()
        {
            Units = new List<OrganizationUnit>();
            AccessRequests = new List<AccessRequest>();
            Members = new List<OrganizationMember>();
            Settings = new List<OrganizationSetting>();

        }

        public string? Description { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsVisibleToEmailDomain { get; set; }
        public string? EMailDomain { get; set; }
        public string? PrivateKey { get; set; }
        public string? Salt { get; set; }
        public List<OrganizationUnit> Units { get; set; }
        public List<AccessRequest> AccessRequests { get; set; }
        public List<OrganizationMember> Members { get; set; }
        public List<OrganizationSetting> Settings { get; set; }

    }
}
