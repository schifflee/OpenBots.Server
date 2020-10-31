using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenBots.Server.Model.SystemConfiguration
{
    public class ConfigurationValue
    {
        public const string Values = "Values";

        [Key]
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
