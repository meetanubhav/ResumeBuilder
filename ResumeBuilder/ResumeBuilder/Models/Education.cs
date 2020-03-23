using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models
{
    public class Education
    {
        [Key]
        public int EduID { get; set; }

        public string EducationLevel { get; set; }

        public int? YearOfPassing { get; set; }

        public string CGPAorPercentage { get; set; }

        public double Score { get; set; }

        public string Stream { get; set; }

        public string Institution { get; set; }

        public string Board { get; set; }


        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}