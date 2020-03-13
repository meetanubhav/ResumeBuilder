using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models.ViewModel
{
    public class SkillsVM
    {
        [Required]
        [Display(Name="Skill")]
        public string SkillName { get; set; }

        [Required]
        public float SkillValue { get; set; }
    }
}