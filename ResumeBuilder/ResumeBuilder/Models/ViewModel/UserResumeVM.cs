using ResumeBuilder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models.ViewModel
{
    public class UserResumeVM
    {
        public int UserID { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(12)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [MaxLength(12)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string AlternatePhoneNumber { get; set; }

        [Required]
        public string ResumeName { get; set; }

        [Required]
        public string Summary { get; set; }

        public List<WorkExperience> WorkExperience { get; set; }
        public List<Education> Education { get; set; }

        public List<Skill> Skill { get; set; }
        public List<Project> Project { get; set; }
        public List<Language> Language { get; set; }
    }
}