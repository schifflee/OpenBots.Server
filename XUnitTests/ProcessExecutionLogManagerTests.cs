using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using OpenBots.Server.Business;
using OpenBots.Server.Core;
using OpenBots.Server.DataAccess;
using OpenBots.Server.DataAccess.Repositories;
using OpenBots.Server.Model;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTests
{
    public class ProcessExecutionLogTests
    {
        [Fact]
        public async Task GetAgent()
        {
           
        }


        private void Seed(StorageContext context, AgentModel model)
        {
            var items = new[]
            {
                model
            };

            context.Agents.AddRange(items);
            context.SaveChanges();
        }
    }
}
