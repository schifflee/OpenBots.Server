using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenBots.Server.Model.Core
{
    public class BusinessEvent : ITenanted
    {
        [Display(Name = "EventOn")]
        public DateTime? EventOn { get; set; }

        public Guid? OrganizationId { get ; set ; }
    }
}
