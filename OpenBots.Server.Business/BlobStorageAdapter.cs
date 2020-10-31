using Microsoft.AspNetCore.Http;
using OpenBots.Server.DataAccess.Repositories;
using OpenBots.Server.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
//using Ionic.Zip;
using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;
using OpenBots.Server.ViewModel;

namespace OpenBots.Server.Business
{
    public class BlobStorageAdapter : IBlobStorageAdapter
    {
        private readonly IBinaryObjectRepository repo;
        public BlobStorageAdapter(IBinaryObjectRepository repo)
        {
            this.repo = repo;
        }

        public async void SaveEntity(IFormFile file, string filePath, string binaryObjectId, string organizationId, string apiComponent, string storageProvider, string folder)
        {
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                //create binary object entity properties in data table
                await repo.AddEntity(file, filePath, binaryObjectId, organizationId, apiComponent, folder, storageProvider);
            }
        }

        public async Task<FileObject> FetchFile(string binaryObjectId)
        {
            FileObject file = new FileObject();

            var binaryObject = repo.GetOne(Guid.Parse(binaryObjectId));
            file.StoragePath = binaryObject.StoragePath;
            file.Name = binaryObject.Name;
            file.ContentType = binaryObject.ContentType;
            file.BlobStream = new FileStream(file?.StoragePath, FileMode.Open, FileAccess.Read);

            return file;
        }

        public async Task<string> UpdateEntity(IFormFile file, string filePath, string binaryObjectId, string apiComponent, string folder)
        {
            //using (var stream = new FileStream(filePath, FileMode.Open))
            //{
                //update binary object entity properties in data table
            await repo.UpdateEntity(file, filePath, binaryObjectId, apiComponent, folder);
            return "Success";
            //}
        }
    }
}
