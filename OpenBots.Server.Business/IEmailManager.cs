using OpenBots.Server.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenBots.Server.Business
{
    public interface IEmailManager
    {
        Task SendEmailAsync(EmailMessage emailMessage, string accountName = "");
    }
}