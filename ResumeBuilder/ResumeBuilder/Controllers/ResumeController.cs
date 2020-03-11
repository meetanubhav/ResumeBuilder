﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< Updated upstream
using System.Security.Claims;
using System.Security.Authentication;
=======
using System.Web.Security;
using System.Data.Entity;
>>>>>>> Stashed changes

using System.Data.Entity;
namespace ResumeBuilder.Controllers
{
    public class ResumeController : Controller
    {
        // GET: Resume
        public ActionResult Login()
        {
            return View();
        }
<<<<<<< Updated upstream
        public ActionResult ValidateLogin(){
=======
        [HttpPost]
        public ActionResult Login(User user)
        {
            
            if (ModelState.IsValid)
            {

              
                var getUserId = db.Users.Where(x => x.Username == user.Username);
                if (getUserId.Where(x => x.Password == user.Password).Any())
                { }
                UsersEntities usersEntities = new UsersEntities();
                int? userId = usersEntities.ValidateUser(user.Username, user.Password).FirstOrDefault();

                string message = string.Empty;
                switch (userId.Value)
                {
<<<<<<< Updated upstream
                    case -1:
                        message = "Username and/or password is incorrect.";
                        break;
                    case -2:
                        message = "Account has not been activated.";
                        break;
                    default:
                        FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                        return RedirectToAction("Profile");
=======
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    var authTicket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddMinutes(10), false, "Users");
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("Dashboard");
>>>>>>> Stashed changes
                }

                ViewBag.Message = message;
                return View(user);
            }
        }

<<<<<<< Updated upstream
        [Authorize]
=======
        [Authorize(Roles = "Users")]
>>>>>>> Stashed changes
        public ActionResult Dashboard()
        {
>>>>>>> Stashed changes
            return View();
        }
<<<<<<< Updated upstream
        public ActionResult Dashboard()
=======

        [Authorize(Roles = "Users")]
        public ActionResult Edit()
>>>>>>> Stashed changes
        {
            return View();
        }
    }
}