using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.ViewModel
{
    public class FieldFilterCriteria
    {
        public Guid? OrganizationId { get; set; }
        public string? Field { get; set; }
        public List<string?> FilterValues { get; set; }
        public string? Search { get; set; }
    }
}
