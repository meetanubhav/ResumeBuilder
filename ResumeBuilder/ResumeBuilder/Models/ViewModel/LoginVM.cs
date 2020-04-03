using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models.ViewModel
{
    public class LoginVM
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression("^.*(?=.{6,})(?=.*)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%&]).*$", ErrorMessage = "Password size must be ateast 6 digit and contain atleast one lower case, one upper case and special character (@,#,$,%,&)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}