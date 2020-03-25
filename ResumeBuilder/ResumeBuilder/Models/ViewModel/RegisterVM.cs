using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models.ViewModel
{
    public class RegisterVM
    {
        [Required]
        [Display(Name = "Username")]
        public string RegisterUsername { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string RegisterPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("RegisterPassword")]
        [Display(Name = "Confirm Password")]
        public string RegisterConfirmPassword { get; set; }
    }
}