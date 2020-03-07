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
                var userdata = db.Users.SingleOrDefault(x => x.Username == user.Username);
                if (getUserId.Where(x => x.Password == user.Password).Any())
                {
                    Session["userid"] = userdata.UserID;
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ModelState.AddModelError("","Invalid UserName or Password");
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

        public ActionResult SignOut()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        //[Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }

        //[Authorize]
        public ActionResult Edit()
        {
            return View();
        }

        public void SendData()
        {
            
        }
    }
}