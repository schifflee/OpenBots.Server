using OpenBots.Server.Model.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.DataAccess.Repositories
{
    public interface IOrganizationRepository : IEntityRepository<Organization>, ITenantEntityRepository<Organization>
    {
        string GenerateBusinessProcessKey(Guid organizationId);
    }
}
