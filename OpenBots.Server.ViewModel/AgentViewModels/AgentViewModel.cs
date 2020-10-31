using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenBots.Server.ViewModel
{
    public class AgentViewModel
    {
        [Display(Name = "Id")]
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        [Required]
        public string MachineName { get; set; }
        public string MacAddresses { get; set; }
        public string IPAddresses { get; set; }
        [Required]
        public bool IsEnabled { get; set; }

        public DateTime? LastReportedOn { get; set; }

        public string? LastReportedStatus { get; set; }

        public string? LastReportedWork { get; set; }

        public string? LastReportedMessage { get; set; }

        public bool? IsHealthy { get; set; }
        [Required]
        public bool isConnected { get; set; }
        public Guid? CredentialId { get; set; }

        public string CredentialName { get; set; }
    }
}
