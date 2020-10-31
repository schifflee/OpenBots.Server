using OpenBots.Server.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenBots.Server.Model.Identity
{
    /// <summary>
    /// Represents a Person
    /// </summary>
    /// <seealso cref="OpenBots.Server.Model.Core.NamedEntity" />
    public class SignUpViewModel
    {
        public SignUpViewModel()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        //[Required]
        //[Required(ErrorMessage = "Please enter your organization.")]
        public string Organization { get; set; }

        //[Required(ErrorMessage = "Please enter your department.")]
        public string? Department { get; set; }

        [RegularExpression("^[A-Za-z0-9_\\+-]+(\\.[A-Za-z0-9_\\+-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*\\.([A-Za-z]{2,4})$", ErrorMessage = "Enter valid Email address.")]
        [StringLength(256, ErrorMessage = "Enter valid Email address.")]
        [Required(ErrorMessage = "Please enter a valid Email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password.")] 
        public string Password { get; set; }

        public bool CreateNewOrganization { get; set; }

        [MaxLength(256)]
        public string? Utm_Source { get; set; }

        [MaxLength(256)]
        public string? Utm_Medium { get; set; }

        [MaxLength(256)]
        public string? Utm_Campaign { get; set; }

        [MaxLength(256)]
        public string? Utm_Term { get; set; }

        [MaxLength(256)]
        public string? Utm_Content { get; set; }

        [MaxLength(256)]
        public string? Plan { get; set; }


        public Guid? ApiKey {get; set;}
    }

    public class InviteUserViewModel// : SignUpViewModel
    {
        public InviteUserViewModel() { }

        public Guid? OrganizationId { get; set; }

        public Guid? ProcessId { get; set; }

        [RegularExpression("^[A-Za-z0-9_\\+-]+(\\.[A-Za-z0-9_\\+-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*\\.([A-Za-z]{2,4})$", ErrorMessage = "Enter valid Email address.")]
        [StringLength(256, ErrorMessage = "Enter valid Email address.")]
        [Required(ErrorMessage = "Please enter your e-mail address.")]
        [EmailAddress(ErrorMessage = "Enter valid Email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [MaxLength(100, ErrorMessage = "Enter maximum 100 characters as name")]
        public string Name { get; set; }

        public string Company { get; set; }

        public string Department { get; set; }

        public string ShareUrl { get; set; }
    }
}
