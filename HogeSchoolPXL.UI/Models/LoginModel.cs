using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeSchoolPXL.UI.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class RegisterModel : LoginModel
    {
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
