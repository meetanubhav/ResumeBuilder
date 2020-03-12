using System;
using ResumeBuilder.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< Updated upstream
using ResumeBuilder.ViewModel;
=======
using ResumeBuilder.Models.ViewModel;
using System.Web.Security;
>>>>>>> Stashed changes

namespace ResumeBuilder.Controllers
{
    public class ResumeController : Controller
    {
        private ResumeBuilderDBContext db = new ResumeBuilderDBContext();
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
                    //Session["userId"] = userData.UserID;
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName or Password");
                }
                //else
                //{
                //    return RedirectToAction("Login");

                //}
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

        [HttpPost]
        public ActionResult AddBasicInfo(UserInfo userBasicInfo)
        {
            var userId = User.Identity.Name;
            return Content("..");
        }

        [Authorize]
        public ActionResult Edit()
        {
            return PartialView("~/Views/Resume/Edit.cshtml");
        }

        [Authorize]
        public ActionResult Template()
        {
            return View();
        }

<<<<<<< Updated upstream
        public ActionResult Settings()
        {
            //if(User.Identity.IsAuthenticated)
            //{
                var vm = new SettingsVM();
                return PartialView("~/Views/Resume/Settings.cshtml", vm);
            //}
            //else
            //{
            //    return RedirectToAction("Login");
            //}
            
        }
=======
>>>>>>> Stashed changes
        public ActionResult SignOut()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

    }
}