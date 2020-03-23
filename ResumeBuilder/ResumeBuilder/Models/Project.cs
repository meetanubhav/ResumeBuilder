using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }

        public byte DurationInMonth { get; set; }

        public string ProjectName { get; set; }
        
        //public string[] ProjectSkills { get; set; }

        public string ProjectDetails { get; set; }

        public string YourRole { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}