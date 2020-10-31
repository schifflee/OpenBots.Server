using Microsoft.AspNetCore.Mvc;
using OpenBots.Server.Model;
using OpenBots.Server.Model.Core;
using OpenBots.Server.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.Business
{
    public interface IAgentManager : IManager
    {
        AgentViewModel GetAgentDetailById(string id);
        
        bool CheckReferentialIntegrity(string id);
    }
}
