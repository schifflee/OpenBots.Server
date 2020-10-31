using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenBots.Server.Security.ViewModel
{
    public class RegisterBindingModel
    {
        [Display(Name = "Name")]
        public string FirstName { get; set; }

        //[Display(Name = "LastName")]
        //public string LastName { get; set; }

        //[Display(Name = "JobTitle")]
        //public string JobTitle { get; set; }

        [Display(Name = "Company")]
        public string Company { get; set; }

        [Display(Name = "Department")]
        public string Department { get; set; }

        //[Display(Name = "CompanyAddress")]
        //public string CompanyAddress { get; set; }

        //[Display(Name = "CompanyPhone")]
        //public string CompanyPhone { get; set; }

        //[Display(Name = "CompanyWebsite")]
        //public string CompanyWebsite { get; set; }

        [RegularExpression("^[A-Za-z0-9_\\+-]+(\\.[A-Za-z0-9_\\+-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*\\.([A-Za-z]{2,4})$", ErrorMessage = "Enter valid Email address.")]
        [StringLength(256, ErrorMessage = "Enter valid Email address.")]
        [Required(ErrorMessage = "Please enter your e-mail address.")]
        [EmailAddress(ErrorMessage = "Enter valid Email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        //public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }
    }
}
