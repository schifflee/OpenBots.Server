using OpenBots.Server.Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
#nullable enable

namespace OpenBots.Server.Model.Identity
{
    public class PersonPhone : Entity
    {
        [Required]
        [Display(Name = "PersonId")]
        public Guid? PersonId { get; set; }

        [MaxLength(99,ErrorMessage ="Phone number length is not valid.")]
        [Phone]
        [Display(Name = "PhoneNumber")]
        public string? PhoneNumber { get; set; }

        [ForeignKey("PersonId")]
        [Display(Name = "Person")]
        public Person? Person { get; set; }

    }
}
