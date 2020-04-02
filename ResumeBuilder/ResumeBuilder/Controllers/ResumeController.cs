using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ResumeBuilder.Models;
using ResumeBuilder.Models.ViewModel;
using AutoMapper;
using ResumeBuilder.Repository;

namespace ResumeBuilder.Controllers
{
    public class ResumeController : Controller
    {
        ResumeBuilderDBContext db = new ResumeBuilderDBContext();
        private readonly IResumeBuilderRepository _resumeRepository = new ResumeBuilderRepository();

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
                if (!db.Users.Any(x => x.Username == newUser.RegisterModel.RegisterUsername))
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
                return View("Login");

            }
            else
            {
                return RedirectToAction("Login");
            }
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

        [Authorize]
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

        public ActionResult PublicProfile(int userId)
        {
            User user = _resumeRepository.GetUserInfo(userId);

            if (user != null)
            {
                UserResumeVM vm = new UserResumeVM();

                vm = Mapper.Map<UserResumeVM>(user);

                vm.Project = user.Settings.Project ? user.Projects : new List<Project>();
                vm.Skill = user.Settings.Skill ? user.Skills : new List<Skill>();
                vm.Education = user.Settings.Education ? user.Education : new List<Education>();
                vm.WorkExperience = user.Settings.WorkExperience ? user.WorkExperiences : new List<WorkExperience>();
                vm.Language = user.Settings.Language ? user.Languages : new List<Language>();

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
            User user = _resumeRepository.GetUserInfo(userId);

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