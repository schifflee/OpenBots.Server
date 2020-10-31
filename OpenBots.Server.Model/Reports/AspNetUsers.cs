#nullable enable
using OpenBots.Server.Model.Core;
using OpenBots.Server.Model.Membership;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpenBots.Server.Model.Report
{
    /// <summary>
    /// Asp Net Users
    /// </summary>
    public class AspNetUsers : Entity, ITenanted
    {
        [Display(Name = "Id")]
        public new string? Id { get; set; }

        [Display(Name = "UserName")]
        public string? UserName { get; set; }

        [Display(Name = "NormalizedUserName")]
        public string? NormalizedUserName { get; set; }
        
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "NormalizedEmail")]
        public string? NormalizedEmail { get; set; }

        [Display(Name = "EmailConfirmed")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "PhoneNumber")]
        public string? PhoneNumber { get; set; }
        
        [Display(Name = "PhoneNumberConfirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [Display(Name = "TwoFactorEnabled")]
        public bool TwoFactorEnabled { get; set; }

        [Display(Name = "PersonId")]
        public Guid PersonId { get; set; }

        [Display(Name = "ForcedPasswordChange")]
        public bool ForcedPasswordChange { get; set; }

        [Display(Name = "LockoutEnabled")]
        public bool LockoutEnabled { get; set; }

        [Display(Name = "AccessFailedCount")]
        public int AccessFailedCount { get; set; }

        [Display(Name = "IsUserConsentRequired")]
        public bool? IsUserConsentRequired { get; set; }
        
        [Display(Name = "Utm_Source")]
        public string? Utm_Source { get; set; }
        
        [Display(Name = "Utm_Medium")]
        public string? Utm_Medium { get; set; }
        
        [Display(Name = "Utm_Campaign")]
        public string? Utm_Campaign { get; set; }
        
        [Display(Name = "Utm_Term")]
        public string? Utm_Term { get; set; }
        
        [Display(Name = "Utm_Content")]
        public string? Utm_Content { get; set; }
        
        [Display(Name = "Name")]
        public string? Name { get; set; }

        //------------------Not Mapped Fields-------------------------//
        [NotMapped]
        public Guid? OrganizationId { get; set; }
        
        [NotMapped]
        public new bool? IsDeleted { get; set; }

        [NotMapped]
        public new string? CreatedBy { get; set; }

        [NotMapped]
        public new DateTime? CreatedOn { get; set; }

        [NotMapped]
        public new string? DeletedBy { get; set; }

        [NotMapped]
        public new DateTime? DeleteOn { get; set; }

        [NotMapped]
        public new byte[]? Timestamp { get; set; }

        [NotMapped]
        public new DateTime? UpdatedOn { get; set; }
        
        [NotMapped]
        public new string? UpdatedBy { get; set; }
    }
}
