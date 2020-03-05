using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string Username { get; set; }

    }
}