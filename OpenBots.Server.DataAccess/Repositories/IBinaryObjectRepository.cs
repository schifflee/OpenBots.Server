using Microsoft.AspNetCore.Http;
using OpenBots.Server.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenBots.Server.DataAccess.Repositories
{
    /// <summary>
    /// Binary Object Repository Interface
    /// </summary>
    public interface IBinaryObjectRepository : IEntityRepository<BinaryObject>
    {
        /// <summary>
        /// Add an Entity to the Binary Object data table
        /// </summary>
        /// <param name="name"></param>
        /// <param name="apiComponent"></param>
        /// <param name="file"></param>
        /// <param name="filePath"></param>
        /// <param name="binaryObjectId"></param>
        /// <param name="organizationId"></param>
        /// <param name="storageProvider"></param>
        /// <returns></returns>
        public Task AddEntity(IFormFile file, string filePath, string binaryObjectId, string organizationId, string apiComponent, string folder, string storageProvider);
    
        public Task UpdateEntity(IFormFile file, string filePath, string binaryObjectId, string apiComponent, string folder);

    }
}
