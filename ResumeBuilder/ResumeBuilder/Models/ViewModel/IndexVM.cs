using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResumeBuilder.Models.ViewModel;

namespace ResumeBuilder.Models.ViewModel
{
    public class IndexVM
    {
        public LoginVM LoginModel { get; set; }
        public RegisterVM RegisterModel { get; set; }
    }
}