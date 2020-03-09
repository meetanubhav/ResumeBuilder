using System;
using ResumeBuilder.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeBuilder.Controllers
{
    public class ResumeController : Controller
    {
        private ResumeBuilderDBContext db = new ResumeBuilderDBContext();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var getUserId = db.Users.Where(x => x.Username == user.Username);
                if (getUserId.Where(x => x.Password == user.Password).Any())
                {
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    return RedirectToAction("Login");

                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        
        public ActionResult Dashboard()
        {
            return View();
        }

        
        public ActionResult Edit(int? userId)
        {
            if (userId != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Dashboard");
            }
        }

        public ActionResult Templete()
        {
            return View();
        }
        public ActionResult SignOut()
        {
            return View();
        }
    }
}