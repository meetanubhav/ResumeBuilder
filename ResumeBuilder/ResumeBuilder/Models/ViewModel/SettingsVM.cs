using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models.ViewModel
{
    public class SettingsVM
    {
        public bool Education { get; set; }
        public bool Language { get; set; }
        public bool Project { get; set; }
        public bool Skill { get; set; }
        public bool WorkExperience { get; set; }
    }
}