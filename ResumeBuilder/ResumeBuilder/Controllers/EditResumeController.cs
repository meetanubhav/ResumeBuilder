using ResumeBuilder.Models;
using ResumeBuilder.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeBuilder.Controllers
{
    public class EditResumeController : Controller
    {
        ResumeBuilderDBContext db = new ResumeBuilder.Models.ResumeBuilderDBContext();

        public ActionResult GetUserInfo()
        {
            var userID = Int32.Parse(User.Identity.Name);
            var userFromDB = db.UserInfos.FirstOrDefault(x => x.UserID == userID);
            return Json(userFromDB, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddBasicInfo(BasicDetailsVM userBasicInfo)
        {
            var userID = Int32.Parse(User.Identity.Name);
            if (ModelState.IsValid)
            {
                var userFromDB = db.UserInfos.FirstOrDefault(x => x.UserID == userID);
                userFromDB.FirstName = userBasicInfo.FirstName;
                userFromDB.LastName = userBasicInfo.LastName;
                userFromDB.Email = userBasicInfo.Email;
                userFromDB.PhoneNumber = userBasicInfo.PhoneNumber;
                userFromDB.AlternatePhoneNumber = userBasicInfo.AlternatePhoneNumber;
                //db.Entry(userFromDB).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Content("Success");
            }
            else
            {
                return Content("Failed");
            }
        }
    }
}