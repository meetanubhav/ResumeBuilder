using AutoMapper;
using ResumeBuilder.Models;
using ResumeBuilder.Models.ViewModel;
using ResumeBuilder.Repository;
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
        private readonly IResumeBuilderRepository _resumeRepository= new ResumeBuilderRepository();

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
        public ActionResult AddEducationInfo(EducationVM education)
        {
            int userId = Int32.Parse(User.Identity.Name);
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<EducationVM, Education>());
                Education edu = Mapper.Map<EducationVM, Education>(education);
                string msg = _resumeRepository.AddOrUpdateEducation(edu, userId);

                return Content(msg);
            }

            return Content("Failed");
        }

        [HttpPost]
        public ActionResult AddSkill(SkillVM skill)
        {
            int userId = Int32.Parse(User.Identity.Name);
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<SkillVM, Skill>());
                Skill sk = Mapper.Map<SkillVM, Skill>(skill);
                string msg = _resumeRepository.AddorUpdateSkill(sk, userId);

                return Content(msg);
            }

            return Content("Failed");
        }

        [HttpPost]
        public ActionResult AddProject(ProjectVM project)
        {
            int userId = Int32.Parse(User.Identity.Name);
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<ProjectVM, Project>());
                Project pr = Mapper.Map<ProjectVM, Project>(project);
                string msg = _resumeRepository.AddorUpdateProject(pr, userId);

                return Content(msg);
            }

            return Content("Failed");
        }

        [HttpPost]
        public ActionResult AddWorkExp(WorkExperienceVM work)
        {
            int userId = Int32.Parse(User.Identity.Name);
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<WorkExperienceVM, WorkExperience>());
                WorkExperience pr = Mapper.Map<WorkExperienceVM, WorkExperience>(work);
                string msg = _resumeRepository.AddOrUpdateExperience(pr, userId);

                return Content(msg);
            }

            return Content("Failed");
        }

        [HttpPost]
        public ActionResult AddLanguage(LanguageVM lang)
        {
            int userId = Int32.Parse(User.Identity.Name);
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<LanguageVM, Language>());
                Language l = Mapper.Map<LanguageVM, Language>(lang);
                string msg = _resumeRepository.AddorUpdateLanguage(l, userId);

                return Content(msg);
            }

            return Content("Failed");
        }

        [HttpPost]
        public ActionResult DeleteProject(int projectId)
        {
            var projectDetails = db.Projects.FirstOrDefault(x => x.ProjectID == projectId);
            if (projectDetails != null)
            {
                db.Projects.Remove(projectDetails);
                db.SaveChanges();
                return Json("Successfully Deleted", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        public ActionResult DeleteEducation(int? id)
        {
            if (id == null)
            {
                return HttpNotFound("404 not found. Better luck Next time");
            }
            try
            {
                db.Educations.Remove(db.Educations.Single(m => m.EduID == id));
                db.SaveChanges();
                return Content("Success");
            }
            catch
            {
                return Content("Failed");
            }
        }
        [HttpPost]
        public ActionResult AddWorkExperience(WorkExperience workExperienceInfo)
        {
            var userID = Int32.Parse(User.Identity.Name);
            if (ModelState.IsValid)
            {
                var userFromDB = new WorkExperience();
                userFromDB.UserID = userID;
                userFromDB.Organization = workExperienceInfo.Organization;
                userFromDB.Designation = workExperienceInfo.Designation;
                userFromDB.FromYear = workExperienceInfo.FromYear;
                userFromDB.ToYear = workExperienceInfo.ToYear;
                db.WorkExperiences.Add(userFromDB);
                db.SaveChanges();
                return Content("Success");
            }
            return Content("Failure");

        [HttpPost]
        public ActionResult DeleteLanguage(int languageId)
        {
            var languageDetails = db.Languages.FirstOrDefault(x => x.LanguageID == languageId);
            if (languageDetails != null)
            {
                db.Languages.Remove(languageDetails);
                db.SaveChanges();
                return Json("Successfully Deleted", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        public ActionResult DeleteSkill(int skillId)
        {
            var skillDetails = db.Skills.FirstOrDefault(x => x.SkillID == skillId);
            if (skillDetails != null)
            {
                db.Skills.Remove(skillDetails);
                db.SaveChanges();
                return Json("Successfully Deleted", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return HttpNotFound();
            }

        }
    }
}