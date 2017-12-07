using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distributor.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email or UserName")]
        [Required(ErrorMessage = "Please provide username or email")]
        public string UsernameOrEmail { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please provide password associated with your username")]
        public string PasswordRaw { get; set; }
    }
}