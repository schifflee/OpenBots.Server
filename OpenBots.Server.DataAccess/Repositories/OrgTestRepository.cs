using System;
using System.Collections.Generic;
using System.Text;
using OpenBots.Server.Core;
using OpenBots.Server.Infrastructure;
using OpenBots.Server.Model.Core;
using OpenBots.Server.Model.Identity;
using OpenBots.Server.Model.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace OpenBots.Server.DataAccess.Repositories
{
    public class OrgTestRepository : EntityRepository<Organization>
    {
        public OrgTestRepository(StorageContext context, ILogger<Organization> logger, IEntityOperationEventSink entityEventSink, IHttpContextAccessor httpContextAccessor) : base(context,  logger, entityEventSink, httpContextAccessor)
        { }
        protected override bool AuthorizeOperation(Organization entity, EntityOperationType operation)
        {
            return true;
        }

        protected override Func<Organization, bool> AuthorizeRead()
        {
            return(o => true);
        }

        protected override DbSet<Organization> DbTable()
        {
            return base.DbContext.Organizations;

        }
    }
}
