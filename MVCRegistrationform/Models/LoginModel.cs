using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCRegistrationform.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please Entire UserName Or Mail Id")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Please Entire Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        //Registration

        [Required(ErrorMessage = "Please Entire UserName Or Mail Id")]
        public string UserNameREG { get; set; }

        [Required(ErrorMessage = "Please Entire FirstName")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Entire Password")]
        [RegularExpression(@"^([a-zA-Z0-9 \.\&\'\-]+)$", ErrorMessage = "Invalid Password")]
        public string PasswordREG { get; set; }

    }
}