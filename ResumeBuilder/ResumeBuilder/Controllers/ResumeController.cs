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
                var user = db.Users.FirstOrDefault(x => x.UserID == userId);

                Mapper.Initialize(cfg => cfg.CreateMap<User, UserResumeVM>());
                UserResumeVM vm = Mapper.Map<User, UserResumeVM>(user);
                
                //{
                //    vm.FirstName = user.FirstName;
                //    vm.LastName = user.LastName;
                //    vm.Email = user.Email;
                //    vm.PhoneNumber = user.PhoneNumber;
                //    vm.AlternatePhoneNumber = user.AlternatePhoneNumber;
                //    vm.ResumeName = user.ResumeName;
                //    vm.Summary = user.Summary;
                //}
                return PartialView("~/Views/Resume/Edit.cshtml", vm);
            }
            else
            {
                return RedirectToAction("Dashboard");
            }
        }

        [HttpPost]
        public ActionResult AddBasicInfo(User userBasicInfo)
        {
            userBasicInfo.UserID = Int32.Parse(User.Identity.Name);
            if (ModelState.IsValid)
            {
                var usertFromDB = db.Users.FirstOrDefault(x => x.UserID == userBasicInfo.UserID);
                db.Entry(usertFromDB).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Content("Success");
            }
            else
            {
                return Content("Failed");
            }
        }


        [Authorize]
        public ActionResult Template()
        {
            var user = db.Users.Where(x => x.UserID == 1).FirstOrDefault();
            return View(user);
        }

        [Authorize]
        public ActionResult PublicProfile()
        {
            var user = db.Users.Where(x => x.UserID == 1).FirstOrDefault();
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
        public JsonResult GetTemplateDetails()
        {
            int userId = Int32.Parse(User.Identity.Name);

            //User user = db.Users.Include("Project").FirstOrDefault(m => m.UserID == userId);
            //db.Users.Include("WorkExperiences").FirstOrDefault(m => m.UserID == userId);
            List<User> userInfo = db.Users.Where(m => m.UserID == userId).ToList();
            List<WorkExperience> work = db.WorkExperiences.Where(m => m.UserID == userId).ToList();
            List<Project> projects = db.Projects.Where(m => m.UserID == userId).ToList();
            List<Skill> skills = db.Skills.Where(m => m.SkillID == userId).ToList();
            List<Education> educations = db.Educations.Where(m => m.UserID == userId).ToList();
            List<Language> languages = db.Languages.Where(m => m.LanguageID == userId).ToList();
            //var multipleTable = (from u in userInfo 
            //                      join p in projects on u.UserID equals p.UserID
            //                      join w in work on p.UserID equals w.UserID where w.UserID == userId select new {
            //                         u.FirstName, u.LastName,
            //                         u.Email, u.PhoneNumber,
            //                         u.Summary, u.ResumeName,
            //                         w.Organization,
            //                         w.Designation,
            //                         w.FromYear.Value,
            //                         w.ToYear,
            //                         p.ProjectName,
            //                         p.ProjectDetails,
            //                         p.YourRole

            //                    }).ToList();

            List<object> test = projects.Cast<object>().Concat(work).Concat(userInfo)
                                .Concat(skills).Concat(educations).Concat(languages).ToList();
            return Json(test, JsonRequestBehavior.AllowGet);
        }



    }
}
