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
        // GET: Resume
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                ResumeBuilderDBContext db = new ResumeBuilderDBContext();
                var getUserId = db.Users.Where(x => (x.Username == user.Username && x.Password == user.Password)).Select(x=>x.UserID);
                return RedirectToAction("Dashboard");
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
        public ActionResult Edit()
        {
            return View();
        }
    }
}