using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models
{
    public class Settings
    {
        public int UserID { get; set; }
        public bool Education { get; set; }
        public bool Language { get; set; }
        public bool Project { get; set; }
        public bool Skill { get; set; }
        public bool WorkExperience { get; set; }
    }
}