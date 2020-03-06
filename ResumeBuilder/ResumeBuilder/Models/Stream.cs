using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models
{
    public class Stream
    {
        [Key]
        public int StreamID { get; set; }
        public string StreamName { get; set; }
    }
}