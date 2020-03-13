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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Primary Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public int PhoneNumber { get; set; }

        [Display(Name = "Alternative Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public int AlternatePhoneNumber { get; set; }
        public string ResumeName { get; set; }
        public string Summary { get; set; }
        public List<WorkExperience> WorkExperience { get; set; }
        public List<Education> Education { get; set; }
        public List<Skill> Skill { get; set; }
        public List<Project> Project { get; set; }
        public List<Language> Language { get; set; }
    }
}