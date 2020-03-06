using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ResumeBuilder.Models
{
    public class University
    {
        [Key]
        public int UniversityID { get; set; }
        public string UniversityName { get; set; }
    }
}
