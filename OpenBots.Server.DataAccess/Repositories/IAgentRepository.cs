using Microsoft.AspNetCore.Mvc;
using OpenBots.Server.Model;
using OpenBots.Server.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OpenBots.Server.DataAccess.Repositories
{
    public interface IAgentRepository : IEntityRepository<AgentModel>
    {
        AgentModel FindAgent(string machineName ,string macAddress, string ipAddress);

        AgentViewModel GetAgentDetailById(string id);
    }
}
