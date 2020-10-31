using Microsoft.AspNetCore.Mvc;
using OpenBots.Server.Model;
using OpenBots.Server.Model.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenBots.Server.Business
{
    public interface IAuditLogManager : IManager
    {
        string GetAuditLogs(AuditLog[] auditLogs);
        MemoryStream ZipCsv(FileContentResult csvFile);
    }
}
