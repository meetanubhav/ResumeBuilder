using ResumeBuilder.Models;
using ResumeBuilder.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeBuilder.Controllers
{
    public class TemplateController : Controller
    {
       
        ResumeBuilderDBContext db = new ResumeBuilderDBContext();
        
        [NonAction]
        public UserResumeVM GetDetails()
        {
            var userId = Int32.Parse(User.Identity.Name);
            UserResumeVM vm = new UserResumeVM();
            if (User.Identity.Name != null)
            {
                var user = db.Users.Include("Education").Include("Projects").Include("Languages").Include("WorkExperiences").Include("Skills").Where(x => x.UserID == userId).FirstOrDefault();

                vm = new UserResumeVM();
                {
                    vm.FirstName = user.FirstName;
                    vm.LastName = user.LastName;
                    vm.Email = user.Email;
                    vm.PhoneNumber = user.PhoneNumber;
                    vm.AlternatePhoneNumber = user.AlternatePhoneNumber;
                    vm.ResumeName = user.ResumeName;
                    vm.Summary = user.Summary;
                    vm.Education = user.Education;
                    vm.Project = user.Projects;
                    vm.WorkExperience = user.WorkExperiences;
                    vm.Skill = user.Skills;
                    vm.Language = user.Languages;
                }
            }
            return vm;
        }
        public ActionResult Template1()
        {
            var userId = Int32.Parse(User.Identity.Name);
            if (User.Identity.Name != null)
            {
                return PartialView("~/Views/Template/Template1.cshtml", GetDetails());
            }
            else
            {
                return RedirectToAction("Dashboard");
            }

        }

        public ActionResult Template2()
        {
            var userId = Int32.Parse(User.Identity.Name);
            if (User.Identity.Name != null)
            {
              
                return PartialView("~/Views/Template/Template2.cshtml", GetDetails());
            }
            else
            {
                return RedirectToAction("Dashboard");
            }
        }
    }
}