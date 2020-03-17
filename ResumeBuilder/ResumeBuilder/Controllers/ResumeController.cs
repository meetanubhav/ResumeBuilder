using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ResumeBuilder.Models;
using ResumeBuilder.ViewModel;
using ResumeBuilder.Models.ViewModel;
using System.Collections;

namespace ResumeBuilder.Controllers {
    public class ResumeController : Controller {
        ResumeBuilderDBContext db = new ResumeBuilderDBContext ();
        public ActionResult Login () {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction ("Dashboard");
            return View ();
        }

        [HttpPost]
        public ActionResult Login (User user) {
            if (ModelState.IsValid) {
                var getUserId = db.Users.Where (x => x.Username == user.Username);
                var userData = db.Users.SingleOrDefault (x => x.Username == user.Username);
                if (getUserId.Where (x => x.Password == user.Password).Any ()) {
                    FormsAuthentication.SetAuthCookie (userData.UserID.ToString (), false);
                    return RedirectToAction ("Dashboard");
                } else {
                    ModelState.AddModelError ("", "Invalid UserName or Password");
                }
                return View (user);
            } else {
                return RedirectToAction ("Login");
            }
        }

        [Authorize]
        public ActionResult Dashboard () {
            return View ();
        }

        [HttpPost]
        public ActionResult AddBasicInfo (UserInfo userBasicInfo) {
            userBasicInfo.UserID = Int32.Parse (User.Identity.Name);
            if (ModelState.IsValid) {
                var usertFromDB = db.UserInfos.FirstOrDefault (x => x.UserID == userBasicInfo.UserID);
                db.Entry (usertFromDB).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges ();

                return Content ("Success");
            } else {
                return Content ("Failed");
            }
        }

        [Authorize]
        public ActionResult Edit () {
            if (User.Identity.Name != null) {
                return PartialView ("~/Views/Resume/Edit.cshtml");
            } else {
                return RedirectToAction ("Dashboard");
            }
        }

        [Authorize]
        public ActionResult Template () {
            var user = db.UserInfos.Where (x => x.UserID == 1).FirstOrDefault ();
            return View (user);
        }

        [Authorize]
        public ActionResult PublicProfile()
        {
            var user = db.UserInfos.Where(x => x.UserID == 1).FirstOrDefault();
            return View(user);
        }

        public ActionResult Settings () {
            var vm = new SettingsVM ();
            return PartialView ("~/Views/Resume/Settings.cshtml", vm);
        }
        public ActionResult SignOut () {
            FormsAuthentication.SignOut ();
            Session.Abandon ();
            return RedirectToAction ("Login");
        }

        //-------------------------Code by bhabani---------------------------------

        [HttpGet]
        public JsonResult GetTemplateDetails()
        {
            int userId = Int32.Parse(User.Identity.Name);
            //db.UserInfos.Include("WorkExperiences").FirstOrDefault(m => m.UserID == userId);
            List<UserInfo> userInfo = db.UserInfos.Where(m => m.UserID == userId).ToList();
            List<WorkExperience> work = db.WorkExperiences.Where(m => m.UserID == userId).ToList();
            List<Project> projects = db.Projects.Where(m => m.UserID == userId).ToList();
            List<UserSkill> skills = db.UserSkills.Where(m => m.UserID == userId).ToList();
            List<Education> educations = db.Educations.Where(m => m.UserID == userId).ToList();
            List<Language> languages = db.Languages.Where(m => m.UserID == userId).ToList();
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
