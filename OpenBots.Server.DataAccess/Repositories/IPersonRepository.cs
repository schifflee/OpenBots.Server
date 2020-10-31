using OpenBots.Server.Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.DataAccess.Repositories
{
    public interface IPersonRepository : IEntityRepository<Person>, ITenantEntityRepository<Person>
    {
    }
}
