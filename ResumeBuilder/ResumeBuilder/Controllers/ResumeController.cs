using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ResumeBuilder.Models;
using ResumeBuilder.Models.ViewModel;
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
        public ActionResult Login(IndexVM user)
        {
            if (ModelState.IsValid)
            {
                var getUserId = db.Users.Where(x => x.Username == user.LoginModel.Username);
                var userData = db.Users.SingleOrDefault(x => x.Username == user.LoginModel.Username);
                if (getUserId.Where(x => x.Password == user.LoginModel.Password).Any())
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
                if(!db.Users.Any(x=>x.Username == newUser.RegisterModel.RegisterUsername))
                {
                    db.Users.Add(new Models.User
                    {
                        Username = newUser.RegisterModel.RegisterUsername,
                        Password = newUser.RegisterModel.RegisterPassword
                    });
                    db.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("", "Registered UserName, Please try with other username.");
                }
                return RedirectToAction("Login");
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
                var user = db.Users.Include("Education").Where(x => x.UserID == userId).FirstOrDefault();

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
                }
                return PartialView("~/Views/Resume/Edit.cshtml", vm);
            }
            else
            {
                return RedirectToAction("Dashboard");
            }
        }
        public ActionResult PublicProfile(int? id)
        {
            var user = db.Users.Include("Education").Include("Projects").Include("Languages").Include("WorkExperiences").Include("Skills").Where(x => x.UserID == id).FirstOrDefault();
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
                    vm.Project = user.Projects;
                    vm.WorkExperience = user.WorkExperiences;
                    vm.Skill = user.Skills;
                    vm.Language = user.Languages;
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

            Mapper.Initialize(cfg => cfg.CreateMap<User, UserResumeVM>());
            vm = Mapper.Map<User, UserResumeVM>(user);
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
            return PartialView();
        }

        /* public ActionResult PublicProfile()
         {
             var userId = Int32.Parse(User.Identity.Name);
             var user = db.Users.Where(x => x.UserID == userId).FirstOrDefault();

             AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<User, UserResumeVM>());
             var userVM = AutoMapper.Mapper.Map<User, UserResumeVM>(user);

             return View(userVM);
         }*/

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }

    }
}