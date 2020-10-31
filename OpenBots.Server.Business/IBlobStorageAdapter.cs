using Ionic.Zip;
using Microsoft.AspNetCore.Http;
using OpenBots.Server.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace OpenBots.Server.Business
{
    public interface IBlobStorageAdapter
    {
        void SaveEntity(IFormFile file, string filePath, string binaryObjectId, string organizationId, string apiComponent, string storageProvider, string folder);

        //Task<string> FetchEntity(string binaryObjectId);
        Task<FileObject> FetchFile(string binaryObjectId);
        Task<string> UpdateEntity(IFormFile file, string filePath, string binaryObjectId, string apiComponent, string folder);

    }
}
