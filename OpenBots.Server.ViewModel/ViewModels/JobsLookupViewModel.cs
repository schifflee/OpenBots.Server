using OpenBots.Server.Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenBots.Server.ViewModel
{
    public class JobsLookupViewModel
    {
        public List<JobAgentsLookup> AgentsLookup { get; set; }
        public List<JobProcessLookup> ProcessLookup { get; set; }

        public JobsLookupViewModel()
        {
            this.AgentsLookup = new List<JobAgentsLookup>();
            this.ProcessLookup = new List<JobProcessLookup>();
        }
    }

    public class JobAgentsLookup
    {
        public Guid AgentId { get; set; }
        public string AgentName { get; set; }
    }

    public class JobProcessLookup
    {   public Guid ProcessId { get; set; }
        public string ProcessName { get; set; }
        public string ProcessNameWithVersion { get; set; }
    }
}
