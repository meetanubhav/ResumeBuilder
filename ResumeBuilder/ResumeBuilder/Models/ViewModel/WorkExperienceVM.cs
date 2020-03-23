using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models.ViewModel
{
    public class WorkExperienceVM
    {
        public int? ExpId { get; set; }
        public string Organization { get; set; }
        public string Designation { get; set; }

        public Nullable<DateTime> FromYear { get; set; }

        public Nullable<DateTime> ToYear { get; set; }

        public int UserID { get; set; }

    }
}