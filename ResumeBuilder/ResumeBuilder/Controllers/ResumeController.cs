using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ResumeBuilder.Models;
using ResumeBuilder.Models.ViewModel;
using System.Collections;
using AutoMapper;

namespace ResumeBuilder.Controllers
{
    public class ResumeController : Controller
    {
        ResumeBuilderDBContext db = new ResumeBuilderDBContext();

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Dashboard");
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var getUserId = db.Users.Where(x => x.Username == user.Username);
                var userData = db.Users.SingleOrDefault(x => x.Username == user.Username);
                if (getUserId.Where(x => x.Password == user.Password).Any())
                {
                    FormsAuthentication.SetAuthCookie(userData.UserID.ToString(), false);
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName or Password");
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }

        [Authorize]
        public ActionResult Edit()
        {
            var userId = Int32.Parse(User.Identity.Name);
            if (User.Identity.Name != null)
            {
                var user = db.Users.Where(x => x.UserID == userId).FirstOrDefault();
                UserResumeVM vm = new UserResumeVM();
                {
                    vm.FirstName = user.FirstName;
                    vm.LastName = user.LastName;
                    vm.Email = user.Email;
                    vm.PhoneNumber = user.PhoneNumber;
                    vm.AlternatePhoneNumber = user.AlternatePhoneNumber;
                    vm.ResumeName = user.ResumeName;
                    vm.Summary = user.Summary;
                }
                return PartialView("~/Views/Resume/Edit.cshtml", vm);

            }
            else
            {
                return RedirectToAction("Dashboard");
            }
        }

        [HttpPost]
        public ActionResult AddBasicInfo (User userBasicInfo) {
            userBasicInfo.UserID = Int32.Parse (User.Identity.Name);
            if (ModelState.IsValid) {
                var usertFromDB = db.Users.FirstOrDefault (x => x.UserID == userBasicInfo.UserID);
                db.Entry (usertFromDB).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges ();

                return Content ("Success");
            } else {
                return Content ("Failed");
            }
        }



        [Authorize]
        public ActionResult Template()
        {
            //var user = db.Users.Where(x => x.UserID == 1).FirstOrDefault();
            return PartialView();
        }

        [Authorize]
        public ActionResult PublicProfile()
        {
            var userId = Int32.Parse(User.Identity.Name);
            var user = db.Users.Where(x => x.UserID == userId).FirstOrDefault();
            return View(user);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }

        //-------------------------Code by bhabani---------------------------------

        [HttpGet]
        public ActionResult GetTemplateDetails()
        {
            var userId = Int32.Parse(User.Identity.Name);
            var user = db.Users.FirstOrDefault(x => x.UserID == userId);
            foreach (var t in user.Skills)
            {
                t.Users = null;
            }
            foreach (var t in user.Projects)
            {
                t.User = null;
            }

            UserResumeVM vm = new UserResumeVM();
         
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserResumeVM>());
            vm = Mapper.Map<User, UserResumeVM>(user);
            vm.Project = user.Projects;
            vm.Skill = user.Skills;
            vm.Education = user.Education;
            vm.WorkExperience = user.WorkExperiences;
            vm.Language = user.Languages;
            
            return Json(vm, JsonRequestBehavior.AllowGet);

        }



    }
}
