using ResumeBuilder.Models;
using ResumeBuilder.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeBuilder.Repository;
using AutoMapper;

namespace ResumeBuilder.Controllers
{
    public class EditResumeController : Controller
    {
        ResumeBuilderDBContext db = new ResumeBuilder.Models.ResumeBuilderDBContext();
        private readonly IResumeBuilderRepository _resumeRepository = new ResumeBuilderRepository();

        public ActionResult GetUserInfo()
        {
            var userID = Int32.Parse(User.Identity.Name);
            var userFromDB = db.Users.FirstOrDefault(x => x.UserID == userID);
            return Json(userFromDB, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult AddBasicInfo(BasicDetailsVM userBasicInfo)
        {
           var userID = Int32.Parse(User.Identity.Name);
           if (ModelState.IsValid)
           {
               var userFromDB = db.Users.FirstOrDefault(x => x.UserID == userID);
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
        
        [HttpPost]
        public ActionResult AddSummaryInfo(BasicDetailsVM summaryInfo)
        {
            var userID = Int32.Parse(User.Identity.Name);
            if (ModelState.IsValid)
            {
                var userFromDB = db.Users.FirstOrDefault(x => x.UserID == userID);
                userFromDB.ResumeName = summaryInfo.ResumeName;
                userFromDB.Summary = summaryInfo.Summary;
                //db.Entry(userFromDB).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Content("Success");
            }
            else
            {
                return Content("Failed");
            }
        }

        [HttpPost]
        public ActionResult AddOrUpdateEducation(EducationVM education)
        {
            int userId = Int32.Parse(User.Identity.Name);
            if(ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<EducationVM, Education>());
                Education edu = Mapper.Map<EducationVM, Education>(education);

                string msg = _resumeRepository.AddOrUpdateEducation(edu, userId);

                return Content(msg);
            }

            return Content("Failed");
        }

        //-------------------------Code by bhabani------------------------------------------
        [HttpGet]
        public JsonResult GetData()
        {
            var userID = Int32.Parse(User.Identity.Name);
            var summary = db.Users.FirstOrDefault(x => x.UserID == userID);

            return Json(summary, JsonRequestBehavior.AllowGet);
        }
    }
}