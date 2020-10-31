using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenBots.Server.Security.ViewModel
{
    public class RegisterExternalBindingModel
    {
        [RegularExpression("^[A-Za-z0-9_\\+-]+(\\.[A-Za-z0-9_\\+-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*\\.([A-Za-z]{2,4})$", ErrorMessage = "Enter valid Email address.")]
        [StringLength(256, ErrorMessage = "Enter valid Email address.")]
        [Required(ErrorMessage = "Please enter your e-mail address.")]
        [EmailAddress(ErrorMessage = "Enter valid Email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
