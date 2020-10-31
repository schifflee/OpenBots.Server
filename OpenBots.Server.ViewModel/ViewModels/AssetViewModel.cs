using Microsoft.AspNetCore.Http;
using OpenBots.Server.Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenBots.Server.ViewModel
{
    public class AssetViewModel
    {
        public Guid? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public string? TextValue { get; set; }
        public double? NumberValue { get; set; }
        public string? JsonValue { get; set; }
        public Guid? BinaryObjectID { get; set; }
        public IFormFile? file { get; set; }
        public Guid? OrganizationId { get; set; }

    }
}
