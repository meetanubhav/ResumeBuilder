using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models
{
    public class SkillUser
    {
        [Key]
        public int Skill_SkillID { get; set; }

        public int User_UserID { get; set; }
    }
}