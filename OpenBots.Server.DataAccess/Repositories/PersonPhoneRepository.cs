using OpenBots.Server.Core;
using OpenBots.Server.Infrastructure;
using OpenBots.Server.Model.Core;
using OpenBots.Server.Model.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace OpenBots.Server.DataAccess.Repositories
{
    public class PersonPhoneRepository : EntityRepository<PersonPhone>, IPersonPhoneRepository
    {
        public PersonPhoneRepository(StorageContext context, ILogger<PersonPhone> logger, IEntityOperationEventSink entityEventSink, IHttpContextAccessor httpContextAccessor) : base(context, logger, entityEventSink, httpContextAccessor)
        {
        }

        protected override DbSet<PersonPhone> DbTable()
        {
            return DbContext.PersonPhones;
        }

        protected override Func<PersonPhone, bool> ParentFilter(Guid parentId)
        {
            return (o => o.PersonId == parentId);
        }
    }
}
