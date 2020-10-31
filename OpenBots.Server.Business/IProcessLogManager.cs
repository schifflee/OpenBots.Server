using Microsoft.AspNetCore.Mvc;
using OpenBots.Server.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenBots.Server.Business
{
    public interface IProcessLogManager : IManager
    {
        string GetJobLogs(ProcessLog[] processLogs);
        MemoryStream ZipCsv(FileContentResult csvFile);
    }
}
