using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models {
    public class User {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength (100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType (DataType.Password)]
        public string Password { get; set; }
    }
}