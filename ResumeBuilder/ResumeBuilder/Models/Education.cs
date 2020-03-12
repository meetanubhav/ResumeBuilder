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
        public Nullable<DateTime> YearOfPassing { get; set; }
        public bool CGPAorPercentage { get; set; }
        public double Score { get; set; }
        
        public Stream Stream { get; set; }
        public University University { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}