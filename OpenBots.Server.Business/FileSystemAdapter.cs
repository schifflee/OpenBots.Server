using Microsoft.AspNetCore.Http;
using OpenBots.Server.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace OpenBots.Server.Business
{
    public class FileSystemAdapter : IFileSystemAdapter
    {
        private readonly IDirectoryManager directoryManager;

        public FileSystemAdapter(IDirectoryManager directoryManager)
        {
            this.directoryManager = directoryManager;
        }

        public string SaveFile(IFormFile file, string path, string organizationId, string apiComponent)
        {
            //Save file to OpenBots.Server.Web/BinaryObjects/{organizationId}/{apiComponent}/{binaryObjectId}
            apiComponent = apiComponent ?? string.Empty;
            var target = Path.Combine(path, organizationId, apiComponent);

            if (!directoryManager.Exists(target))
            {
                directoryManager.CreateDirectory(target);
            }

            Guid binaryObjectId = Guid.NewGuid();
            var filePath = Path.Combine(target, binaryObjectId.ToString());

            if (file.Length <= 0 || file.Equals(null)) return "No file exists.";
            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                ConvertToBinaryObject(filePath);
            }
            return binaryObjectId.ToString();
        }

        public void ConvertToBinaryObject(string filePath)
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            File.WriteAllBytes(filePath, bytes);
        }

        public void UpdateFile(IFormFile file, string path, string organizationId, string apiComponent, Guid binaryObjectId)
        {
            //Update file to OpenBots.Server.Web/BinaryObjects/{organizationId}/{apiComponent}/{binaryObjectId}
            apiComponent = apiComponent ?? string.Empty;
            var target = Path.Combine(path, organizationId, apiComponent);

            if (!directoryManager.Exists(target))
            {
                directoryManager.CreateDirectory(target);
            }

            var filePath = Path.Combine(target, binaryObjectId.ToString());

            if (file.Length > 0)
            {
                File.Delete(filePath);
                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(stream);
                }

                ConvertToBinaryObject(filePath);
            }
        }

    }
}
