using Microsoft.AspNetCore.Http;
using OpenBots.Server.Model;
using OpenBots.Server.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OpenBots.Server.Business
{
    public interface IProcessManager : IManager
    {
        Task<FileObject> Export(string binaryObjectId);

        string Upload(IFormFile file, string organizationId = "", string apiComponent = "");

        bool DeleteProcess(Guid processId);

        Process AddProcess(ProcessViewModel request, Guid binaryObjId, Guid versionId);

        Process UpdateProcess(Process requestObj, ProcessViewModel request, Guid versionId);

        Task<string> Update(Guid binaryObjectId, IFormFile file, string organizationId = "", string apiComponent = "");

        string GetOrganizationId();
    }
}
