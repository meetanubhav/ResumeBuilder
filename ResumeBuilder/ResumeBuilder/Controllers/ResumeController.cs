﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Optimization;
using ResumeBuilder.Models;
using ResumeBuilder.Models.ViewModel;
using AutoMapper;

namespace ResumeBuilder.Controllers
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css",
                "~/content/templatereveal.css",
                "~/content/templatestyle.css",
                "~/content/template2style.css",
                "~/Content/DataTables/css/jquery.dataTables.css",
                "~/Content/bootstrap-responsive.css"));

            bundles.Add(new ScriptBundle("~/Bundles").Include(
                "~/Scripts/modernizr-2.6.2.js",
                "~/Scripts/jquery-3.4.1.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js",
                "~/Scripts/bootbox.js",
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/EditSectionScript.js",
                "~/Scripts/ResumeSettings.js",
                "~/Scripts/CommonAjaxScripts.js",
                "~/Scripts/CommonScripts.js"));
        }
    }
    //public class MyHttpHandler : IHttpHandler
    //{
    //    public void ProcessRequest(HttpContext context)
    //    {
    //        context.Response.Redirect("AccessForbidden");
    //    }
    //    public bool IsReusable
    //    {
    //        get
    //        {
    //            return true;
    //        }
    //    }
    //}
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
        public ActionResult Login(IndexVM user)
        {
            if (ModelState.IsValid)
            {
                var userData = db.Users.SingleOrDefault(x => x.Username == user.LoginModel.Username);
                if (userData.Password == FormsAuthentication.HashPasswordForStoringInConfigFile(user.LoginModel.Password,"SHA1"))
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

        public ActionResult Register(IndexVM newUser)
        {
            if (ModelState.IsValid)
            {
                if (!db.Users.Any(x => x.Username == newUser.RegisterModel.RegisterUsername))
                {
                    string passwordInDatabase = FormsAuthentication.HashPasswordForStoringInConfigFile(newUser.RegisterModel.RegisterPassword, "SHA1");
                    db.Users.Add(new Models.User
                    {
                        Username = newUser.RegisterModel.RegisterUsername,
                        Password = passwordInDatabase
                    });
                    
                    db.SaveChanges();

                }
                else
                {
                    ModelState.AddModelError("", "Registered UserName, Please try with other username.");
                }
                return View("Login");

            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult AccessForbidden()
        {
            return View();
        }
        private void alert(string p)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }


        [ChildActionOnly]
        public ActionResult Edit()
        {
            var userId = Int32.Parse(User.Identity.Name);
            if (User.Identity.Name != null)
            {
                var user = db.Users.Include("Education").Include("Projects").Include("Languages").Include("WorkExperiences").Include("Skills").Where(x => x.UserID == userId).FirstOrDefault();

                UserResumeVM vm = new UserResumeVM();
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
                return PartialView("~/Views/Resume/Edit.cshtml", vm);
            }
            else
            {
                return RedirectToAction("Dashboard");
            }
        }

        public ActionResult PublicProfile(int? userId)
        {
            var user = db.Users.Include("Education").Include("Projects").Include("Languages").Include("WorkExperiences").Include("Skills").Where(x => x.UserID == userId).FirstOrDefault();
            if (user != null)
            {
                UserResumeVM vm = new UserResumeVM();
                {
                    vm.FirstName = user.FirstName;
                    vm.LastName = user.LastName;
                    vm.Email = user.Email;
                    vm.PhoneNumber = user.PhoneNumber;
                    vm.AlternatePhoneNumber = user.AlternatePhoneNumber;
                    vm.ResumeName = user.ResumeName;
                    vm.Summary = user.Summary;
                    vm.Education = user.Education;
                    vm.WorkExperience = user.WorkExperiences;
                    vm.Language = user.Languages;
                    vm.Skill = user.Skills;
                    vm.Project = user.Projects;
                }
                return View(vm);
            }
            else
            {
                return RedirectToAction("Dashboard");
            }
        }

        [HttpGet]
        public ActionResult GetTemplateDetails()
        {
            var userId = Int32.Parse(User.Identity.Name);
            var user = db.Users.Include("Projects")
            .Include("Skills")
            .Include("Education")
            .Include("WorkExperiences")
            .Include("Languages")
            .FirstOrDefault(x => x.UserID == userId);

            foreach (var i in user.Projects)
            {
                i.User = null;
            }
            foreach (var i in user.Skills)
            {
                i.Users = null;
            }
            foreach (var i in user.Education)
            {
                i.User = null;
            }
            foreach (var i in user.WorkExperiences)
            {
                i.User = null;
            }
            foreach (var i in user.Languages)
            {
                i.Users = null;
            }

            UserResumeVM vm = new UserResumeVM();

            vm = Mapper.Map<UserResumeVM>(user);
            vm.Project = user.Projects;
            vm.Skill = user.Skills;
            vm.Education = user.Education;
            vm.WorkExperience = user.WorkExperiences;
            vm.Language = user.Languages;

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        [Authorize]
        public ActionResult Template()
        {
            //var user = db.Users.Where(x => x.UserID == 1).FirstOrDefault();
            return PartialView("~/Views/Resume/Template.cshtml");
        }

        //This action method is triggered in search
        public ActionResult GetAllUsersData()
        {
            //var user = db.Users.Include("Education").Include("Projects").Include("Languages").Include("WorkExperiences").Include("Skills").OrderBy(x => x.FirstName).ToList();
            //var data = (from user in db.Users.Include("Skills")
            // select new SearchUserDataVM
            // {
            // FirstName = user.FirstName,
            // LastName = user.LastName,
            // }).Where(x => x.FirstName !=null && x.LastName !=null).OrderBy(x => x.FirstName).ToList();
            //var data = db.Users
            // .Where(x => x.FirstName !=null && x.LastName !=null)
            // .Select(user => new
            // {
            // Name = user.FirstName,
            // TeamNames = user.Skills
            // .Select(skill => skill.SkillName )
            // .ToList(),
            // });
            var data = (from e in db.Users.Include("Skills")
            .Where(x => x.Skills.Any()).ToList()
                        select new SearchUserDataVM
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Skills = e.Skills.Select(x => x.SkillName).ToArray()
                        });
            return Json(data, JsonRequestBehavior.AllowGet);

        }
        //public ActionResult PublicProfile(int? userId)
        //{
        // // var userId = Int32.Parse(User.Identity.Name);
        // var user = db.Users.Where(x => x.UserID == userId).FirstOrDefault();

        // Mapper.Initialize(cfg => cfg.CreateMap<User,UserResumeVM>());
        // var userVM = Mapper.Map<User, UserResumeVM>(user);

        // return View(userVM);
        //}

        [Authorize]
        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }

    }
}