using ResumeBuilder.Models;
using ResumeBuilder.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeBuilder.Repository;


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

        //[HttpPost]
        //public ActionResult AddEducation(EducationVM education)
        //{
        //    int userId = Int32.Parse(User.Identity.Name);
        //    if(ModelState.IsValid)
        //    {
        //        Mapper.Initialize(cfg => cfg.CreateMap<EducationVM, Education>());
        //        Education edu = Mapper.Map<EducationVM, Education>(education);
        //        string msg = _resumeRepository.AddOrUpdateEducation(edu, userId);

        //        return Content(msg);
        //    }

        //    return Content("Failed");
        //}

        //[HttpPost]
        //public ActionResult AddSkill(SkillVM skill)
        //{
        //    int userId = Int32.Parse(User.Identity.Name);
        //    if (ModelState.IsValid)
        //    {
        //        Mapper.Initialize(cfg => cfg.CreateMap<SkillVM, Skill>());
        //        Skill sk = Mapper.Map<SkillVM, Skill>(skill);
        //        string msg = _resumeRepository.AddorUpdateSkill(sk, userId);

        //        return Content(msg);
        //    }

        //    return Content("Failed");
        //}

        //[HttpPost]
        //public ActionResult AddProject(ProjectVM project)
        //{
        //    int userId = Int32.Parse(User.Identity.Name);
        //    if (ModelState.IsValid)
        //    {
        //        Mapper.Initialize(cfg => cfg.CreateMap<ProjectVM, Project>());
        //        Project pr = Mapper.Map<ProjectVM, Project>(project);
        //        string msg = _resumeRepository.AddorUpdateProject(pr, userId);

        //        return Content(msg);
        //    }

        //    return Content("Failed");
        //}

        //[HttpPost]
        //public ActionResult AddWorkExp(WorkExperienceVM work)
        //{
        //    int userId = Int32.Parse(User.Identity.Name);
        //    if (ModelState.IsValid)
        //    {
        //        Mapper.Initialize(cfg => cfg.CreateMap<WorkExperienceVM, WorkExperience>());
        //        WorkExperience pr = Mapper.Map<WorkExperienceVM, WorkExperience>(work);
        //        string msg = _resumeRepository.AddOrUpdateExperience(pr, userId);

        //        return Content(msg);
        //    }

        //    return Content("Failed");
        //}

        //[HttpPost]
        //public ActionResult AddLanguage(WorkExperienceVM work)
        //{
        //    int userId = Int32.Parse(User.Identity.Name);
        //    if (ModelState.IsValid)
        //    {
        //        Mapper.Initialize(cfg => cfg.CreateMap<WorkExperienceVM, WorkExperience>());
        //        WorkExperience pr = Mapper.Map<WorkExperienceVM, WorkExperience>(work);
        //        string msg = _resumeRepository.AddOrUpdateExperience(pr, userId);

        //        return Content(msg);
        //    }

        //    return Content("Failed");
        //}

        [HttpPost]
        public ActionResult DeleteEducation(int eduId)
        {
            var eduDetails = db.Educations.FirstOrDefault(x => x.EduID == eduId);
            if (eduDetails != null)
            {
                db.Educations.Remove(eduDetails);
                db.SaveChanges();
                return Json("Successfully Deleted", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return HttpNotFound();
            }

        }

        //-------------------------Code by bhabani------------------------------------------
        
        public ActionResult UpdateSummary(int id)
        {
            var userID = Int32.Parse(User.Identity.Name);
            var summary = db.Users.FirstOrDefault(x => x.UserID == userID);

            return Json(summary, JsonRequestBehavior.AllowGet);
        }
    }
}