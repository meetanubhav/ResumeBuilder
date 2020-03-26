using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ResumeBuilder.Models.ViewModel
{
    public class SummaryVM
    {
        [Required]
        public string ResumeName { get; set; }

        [Required]
        [StringLength(100)]
        public string Summary { get; set; }

    }
}