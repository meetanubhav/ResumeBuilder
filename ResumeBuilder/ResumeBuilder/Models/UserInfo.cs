using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models
{
    public class UserInfo
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabets in First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabet in Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Primary Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Alternative Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string AlternatePhoneNumber { get; set; }

        [Required]
        public string ResumeName { get; set; }

        [Required]
        [StringLength(100)]
        public string Summary { get; set; }

        public List<WorkExperience> WorkExperience { get; set; }
        public List<Education> Education { get; set; }
        public List<UserSkill> UserSkill { get; set; }
        public List<Project> Project { get; set; }
        public List<Language> Language { get; set; }

    }
}