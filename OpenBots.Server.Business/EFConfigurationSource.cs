using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.Business
{
    public class EFConfigurationSource : IConfigurationSource
    {
        private readonly Action<DbContextOptionsBuilder> optionsAction;

        public EFConfigurationSource(Action<DbContextOptionsBuilder> options)
        {
            optionsAction = options;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new EFConfigurationProvider(optionsAction);
        }
    }
}
