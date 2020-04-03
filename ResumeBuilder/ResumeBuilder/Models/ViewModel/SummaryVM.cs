using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ResumeBuilder.Models.ViewModel
{
    public class SummaryVM
    {
        public string ResumeName { get; set; }
        public string Summary { get; set; }
    }
}