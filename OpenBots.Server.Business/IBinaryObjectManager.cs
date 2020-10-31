using Ionic.Zip;
using Microsoft.AspNetCore.Http;
using OpenBots.Server.DataAccess.Repositories;
using OpenBots.Server.Model;
using OpenBots.Server.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace OpenBots.Server.Business
{
    public interface IBinaryObjectManager: IManager
    {
        string Upload(IFormFile file, string organizationId, string apiComponent);

        void SaveEntity(IFormFile file, string filePath, string binaryObjectId, string organizationId, string apiComponent, string folder);

        Task<FileObject> Download(string binaryObjectId);

        void Update(IFormFile file, string organizationId, string apiComponent, Guid binaryObjectId);

        Task<string> UpdateEntity(IFormFile file, string filePath, string binaryObjectId, string apiComponent, string folder);

        string GetOrganizationId();
    }
}
