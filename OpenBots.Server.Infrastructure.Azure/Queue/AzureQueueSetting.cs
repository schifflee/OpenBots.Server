using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace OpenBots.Server.Infrastructure.Azure
{
    public class AzureQueueSetting
    {
        public AzureQueueSetting(IConfiguration configuration)
        {
            connectionString = configuration["Queue.Azure:ConnectionString"];
            queueName = configuration["Queue.Azure:QueueName"];
            enableMessaging = bool.Parse(configuration["Queue.Azure:EnableMessaging"]);
        }

        string connectionString = "";
        string queueName = "Default";
        bool enableMessaging = false;

        public string ConnectionString { get => connectionString; }
        public string QueueName { get => queueName;  }
        public bool EnableMessaging { get => enableMessaging;}
    }
}
