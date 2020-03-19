using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models.ViewModel
{
    public class EducationVM
    {
        public string EducationLevel { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        public Nullable<DateTime> YearOfPassing { get; set; }

        public bool CGPAorPercentage { get; set; }

        public double Score { get; set; }

        public string Stream { get; set; }

        public string Institution { get; set; }

        public string Board { get; set; }
    }
}