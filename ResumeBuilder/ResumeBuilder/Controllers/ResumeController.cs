using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Security.Authentication;

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
                    case -1:
                        message = "Username and/or password is incorrect.";
                        break;
                    case -2:
                        message = "Account has not been activated.";
                        break;
                    default:
                        FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                        return RedirectToAction("Profile");
                }

                ViewBag.Message = message;
                return View(user);
            }
        }

        [Authorize]
        public ActionResult Dashboard()
        {
>>>>>>> Stashed changes
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}