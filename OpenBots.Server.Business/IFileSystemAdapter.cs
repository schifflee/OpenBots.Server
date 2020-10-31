using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.Business
{
    public interface IFileSystemAdapter
    {
        string SaveFile(IFormFile file, string path, string organizationId, string apiComponent);

        void ConvertToBinaryObject(string filePath);

        void UpdateFile(IFormFile file, string path, string organizationId, string apiComponent, Guid binaryObjectId);

    }
}
