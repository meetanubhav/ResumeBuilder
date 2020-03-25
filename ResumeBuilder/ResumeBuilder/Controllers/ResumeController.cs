using System;
using ResumeBuilder.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeBuilder.Models.ViewModel;
using System.Web.Security;

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
                }
                return PartialView("~/Views/Resume/Edit.cshtml",vm);
            }
            else
            {
                return RedirectToAction("Dashboard");
            }
        }

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

    }
}