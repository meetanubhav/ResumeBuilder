using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models.ViewModel
{
    public class ProjectVM
    {
        public int? ProjectID { get; set; }

        public byte DurationInMonth { get; set; }

        public string ProjectName { get; set; }

        public string ProjectDetails { get; set; }

        public string YourRole { get; set; }

        public int UserID { get; set; }
    }
}