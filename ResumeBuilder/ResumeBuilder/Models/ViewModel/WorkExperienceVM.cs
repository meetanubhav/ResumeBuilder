using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models.ViewModel
{
    public class WorkExperienceVM
    {
        [Required]
        public string Organization { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}")]
        public DateTime From { get; set; }


        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}")]
        public Nullable<DateTime> To { get; set; }
        
    }
}