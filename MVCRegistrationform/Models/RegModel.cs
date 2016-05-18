using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCRegistrationform.Models
{
    public class RegModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Entire Name")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Please Entire Email")]
        [EmailAddress(ErrorMessage = "Please Entire valid mail id")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Entire Phone number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please Entire Address")]
        public string Address { get; set; }

       
    }
}