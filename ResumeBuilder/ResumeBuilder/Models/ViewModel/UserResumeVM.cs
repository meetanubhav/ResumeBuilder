using ResumeBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeBuilder.ViewModel
{
    public class UserResumeVM
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int AlternatePhoneNumber { get; set; }
        public string ResumeName { get; set; }
        public string Summary { get; set; }
        public List<WorkExperience> WorkExperience { get; set; }
        public List<Education> Education { get; set; }
        public List<UserSkill> UserSkill { get; set; }
        public List<Project> Project { get; set; }
        public List<Language> Language { get; set; }
    }
}