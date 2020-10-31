using Microsoft.AspNetCore.Mvc;
using OpenBots.Server.Model;
using OpenBots.Server.Model.Core;
using OpenBots.Server.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.Business
{
    public interface IProcessExecutionLogManager : IManager
    {
        ProcessExecutionViewModel GetExecutionView(ProcessExecutionLog processExecutionLog);
        PaginatedList<ProcessExecutionViewModel> GetProcessAndAgentNames(Predicate<ProcessExecutionViewModel> predicate = null, string sortColumn = "", OrderByDirectionType direction = OrderByDirectionType.Ascending, int skip = 0, int take = 100);
    }
}
