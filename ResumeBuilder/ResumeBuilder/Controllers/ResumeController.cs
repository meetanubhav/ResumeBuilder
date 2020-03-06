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