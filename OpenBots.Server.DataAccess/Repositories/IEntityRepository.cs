using System;
using OpenBots.Server.Model.Core;
using OpenBots.Server.Model.Identity;

namespace OpenBots.Server.DataAccess.Repositories
{
    public interface IEntityRepository<T> : IReadOnlyEntityRepository<T>
        where T : class, IEntity, new()
    {
        // UserSecurityContext UserContext { get; }

        T Add(T entity);
        void Delete(Guid id);
        void SoftDelete(Guid id);
        T Update(T entity, byte[] originalTimestamp = null);
        ValidationResults Validate(T entity);
    }
}