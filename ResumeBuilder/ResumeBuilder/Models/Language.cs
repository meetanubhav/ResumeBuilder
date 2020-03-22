using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Models
{
    public class Language
    {
        [Key]
        public int LanguageID { get; set; }

        public string LanguageName { get; set; }

        public virtual List<User> Users { get; set; }

    }
}
