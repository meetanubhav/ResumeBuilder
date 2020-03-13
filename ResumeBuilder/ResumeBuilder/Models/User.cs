using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models {
    public class User {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabets in First Name")]
        public string FirstName { get; set; }

        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabet in Last Name")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string AlternatePhoneNumber { get; set; }

        public string ResumeName { get; set; }

        [StringLength(100)]
        public string Summary { get; set; }

        public virtual List<WorkExperience> WorkExperiences { get; set; }
        public virtual List<Education> Education { get; set; }
        public virtual List<Project> Projects { get; set; }

        public virtual List<Skill> Skills { get; set; }
        public virtual List<Language> Languages { get; set; }

        public int? SettingsID { get; set; }
        public virtual Settings Settings { get; set; }

    }
}