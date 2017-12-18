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
        [Required(ErrorMessage = "Email could not be blank!")]
        public string UsernameOrEmail { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password could not be blank!")]
        public string PasswordRaw { get; set; }
    }
}