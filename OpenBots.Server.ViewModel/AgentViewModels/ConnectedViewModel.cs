using OpenBots.Server.Model;
using OpenBots.Server.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.ViewModel.AgentViewModels
{
    public class ConnectedViewModel : IViewModel<AgentModel, ConnectedViewModel>
    {
        public string AgentId { get; set; }

        public string AgentName { get; set; }

        public ConnectedViewModel Map(AgentModel entity)
        {
            ConnectedViewModel connected = new ConnectedViewModel
            {
                AgentId = entity.Id.ToString(),
                AgentName = entity.Name
            };

            return connected;
        }
    }
}
