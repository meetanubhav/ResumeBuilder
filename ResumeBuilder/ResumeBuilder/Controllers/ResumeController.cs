
using System;using ResumeBuilder.Models;using System.Collections.Generic;using System.Linq;using System.Web;using System.Web.Mvc;using ResumeBuilder.ViewModel;using System.Web.Security;namespace ResumeBuilder.Controllers{    public class ResumeController : Controller    {        private ResumeBuilderDBContext db = new ResumeBuilderDBContext();
                public ActionResult Login()        {            if (User.Identity.IsAuthenticated)                return RedirectToAction("Dashboard");            return View();        }        [HttpPost]        public ActionResult Login(User user)        {            if (ModelState.IsValid)            {                var getUserId = db.Users.Where(x => x.Username == user.Username);                var userData = db.Users.SingleOrDefault(x => x.Username == user.Username);                if (getUserId.Where(x => x.Password == user.Password).Any())                {                    FormsAuthentication.SetAuthCookie(userData.UserID.ToString(), false);                    return RedirectToAction("Dashboard");                }                else                {                    ModelState.AddModelError("", "Invalid UserName or Password");                }                return View(user);            }            else            {                return RedirectToAction("Login");            }        }        [Authorize]        public ActionResult Dashboard()        {            return View();        }        [HttpPost]        public ActionResult AddBasicInfo(UserInfo userBasicInfo)        {            var userId = User.Identity.Name;            return Content("..");        }        [Authorize]        public ActionResult Edit(int? userId)        {            if (userId != null)            {                return PartialView("~/Views/Resume/Edit.cshtml");            }            else            {                return RedirectToAction("Dashboard");            }        }        public ActionResult Template()        {            return View();        }        public ActionResult Settings()        {            //var vm = new SettingsVM();            return PartialView("~/Views/Resume/Settings.cshtml");        }        public ActionResult SignOut()        {            FormsAuthentication.SignOut();            Session.Abandon();            return RedirectToAction("Login");        }

                   public ActionResult GetUserBasicInfo()
        {
            int userId = Int32.Parse(User.Identity.Name);
            var userInfo = db.UserInfos.SingleOrDefault(m => m.UserID == userId);
            var test = db.UserInfos;
            return Json(userInfo, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetEducationDetails()
        {
            var eduDetails = db.Educations.Where(m => m.UserID == Int32.Parse(User.Identity.Name));
            return Json(eduDetails, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetWorkExperienceDetails()
        {
            var workDetails = db.WorkExperiences.Where(m => m.UserID == Int32.Parse(User.Identity.Name));
            return Json(workDetails, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetProjectDetails()
        {
            var projectDetails = db.Projects.Where(m => m.UserID == Int32.Parse(User.Identity.Name));
            return Json(projectDetails, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetSkillDetails()
        {
            int userId = Int32.Parse(User.Identity.Name);
            var skilldetails = db.UserSkills.FirstOrDefault(m => m.UserID == userId);
            var test = new UserSkill
            {
                Skill = skilldetails.Skill,
                Rating = skilldetails.Rating
            };
            return Json(test, JsonRequestBehavior.AllowGet);
        }    }}