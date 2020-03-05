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

        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression("[a-zA-Z]{3,14}$", ErrorMessage = "Invalid password format")]
        public string UserPassword { get; set; }
    }
}