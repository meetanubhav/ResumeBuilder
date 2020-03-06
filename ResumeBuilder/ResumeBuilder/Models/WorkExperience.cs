using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models
{
    public class WorkExperience
    {
        [Key]
        public int ExpId { get; set; }
        public string Organization { get; set; }
        public string Designation { get; set; }
        public Nullable<DateTime> FromYear { get; set; }
        public Nullable<DateTime> ToYear { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}