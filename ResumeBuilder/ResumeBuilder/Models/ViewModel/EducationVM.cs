using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models.ViewModel
{
    public class EducationVM
    {
        public int? EduID { get; set; }

        public string EducationLevel { get; set; }

        public int? YearOfPassing { get; set; }

        public string CGPAorPercentage { get; set; }

        public double Score { get; set; }

        public string Stream { get; set; }

        public string Institution { get; set; }

        public string Board { get; set; }
    }
}