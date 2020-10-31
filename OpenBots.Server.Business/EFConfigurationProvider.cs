using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OpenBots.Server.DataAccess;
using OpenBots.Server.Model;
using OpenBots.Server.Model.SystemConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenBots.Server.Business
{
    public class EFConfigurationProvider : ConfigurationProvider
    {
        public EFConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }

        Action<DbContextOptionsBuilder> OptionsAction;

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<StorageContext>();

            OptionsAction(builder);

            using (var dbContext = new StorageContext(builder.Options))
            {
                dbContext.Database.EnsureCreated();

                Data = !dbContext.ConfigurationValues.Any()
                    ? CreateAndSaveDefaultValues(dbContext)
                    : dbContext.ConfigurationValues.ToDictionary(c => c.Name, c => c.Value);

                //if (dbContext.ConfigurationValues != null)
                //{
                //    foreach (var entity in dbContext.ConfigurationValues)
                //    {
                //        if (configValues.ContainsValue(entity.Value) && configValues.ContainsValue(entity.Value))
                //        {
                //            continue;
                //        }
                //        else
                //        {
                //            dbContext.Remove(entity);
                //        }
                //    }
                //}

                //CreateAndSaveDefaultValues(dbContext);
                //Data = dbContext.ConfigurationValues.ToDictionary(k => k.Name, v => v.Value);
            }
        }

        private static IDictionary<string, string> CreateAndSaveDefaultValues(StorageContext dbContext)
        {
            var configValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "BinaryObjects:Adapter", "FileSystemAdapter" },
                { "BinaryObjects:Path", "BinaryObjects"},
                { "Queue.Global:DefaultMaxRetryCount", "3" }
            };

            //foreach (var value in configValues)
            //{
            //    if (context.ConfigurationValues.Count(a => a.Value == value.Value) == 0)
            //    {
            //        context.ConfigurationValues.Add(new ConfigurationValue
            //        {
            //            Name = value.Key,
            //            Value = value.Value
            //        });

            //        context.SaveChanges();
            //    }

            dbContext.ConfigurationValues.AddRange(configValues
                .Select(kvp => new ConfigurationValue
                {
                    Name = kvp.Key,
                    Value = kvp.Value
                })
                .ToArray());

            dbContext.SaveChanges();

            return configValues;
        }
    }
}