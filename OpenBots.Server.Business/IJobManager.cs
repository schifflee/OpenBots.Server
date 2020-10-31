using OpenBots.Server.Model;
using OpenBots.Server.Model.Core;
using OpenBots.Server.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.Business
{
    public interface IJobManager : IManager
    {
        JobViewModel GetJobView(Job job);
        JobsLookupViewModel GetJobAgentsLookup();
        PaginatedList<JobViewModel> GetJobAgentsandProcesses(Predicate<JobViewModel> predicate = null, string sortColumn = "", OrderByDirectionType direction = OrderByDirectionType.Ascending, int skip = 0, int take = 100);
        NextJobViewModel GetNextJob(Guid agentId);
    }
}
