using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models.ViewModel
{
    public class WorkExperienceVM
    {
        public int? ExpId { get; set; }
        public string Organization { get; set; }
        public string Designation { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}")]
        public Nullable<DateTime> FromYear { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}")]
        public Nullable<DateTime> ToYear { get; set; }

        public bool CurrentlyWorking { get; set; }
    }
}