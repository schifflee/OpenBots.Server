using Microsoft.AspNetCore.Mvc;
using OpenBots.Server.Model;
using OpenBots.Server.Model.Core;
using OpenBots.Server.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.Business
{
    public interface IScheduleManager : IManager
    {
        public void StartNewRecurringJob(string scheduleSerializeObject);
        //public void StartRecurringJob(string name, string cronExpression);
        //public void StartRecurringJob(Schedule schedule);

        PaginatedList<ScheduleViewModel> GetScheduleAgentsandProcesses(Predicate<ScheduleViewModel> predicate = null, string sortColumn = "", OrderByDirectionType direction = OrderByDirectionType.Ascending, int skip = 0, int take = 100);

    }
}
