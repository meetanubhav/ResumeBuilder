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
        private readonly IResumeBuilderRepository _resumeRepository = new ResumeBuilderRepository();

        // Get Actions
        public ActionResult GetUserInfo()
        {
            var userID = Int32.Parse(User.Identity.Name);
            var userFromDB = db.Users.AsNoTracking().FirstOrDefault(x => x.UserID == userID);
            return Json(userFromDB, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetEducation(int educationId)
        {
            var education = db.Educations.AsNoTracking().FirstOrDefault(x => x.EduID == educationId);

            Mapper.Initialize(cfg => cfg.CreateMap<Education, EducationVM>());
            EducationVM educationVM = Mapper.Map<Education, EducationVM>(education);

            return Json(educationVM, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProject(int projectId)
        {
            var project = db.Projects.AsNoTracking().FirstOrDefault(x => x.ProjectID == projectId);

            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectVM>());
            ProjectVM projectVM = Mapper.Map<Project, ProjectVM>(project);

            return Json(projectVM, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetWorkExperience(int workExperienceId)
        {
            var workExperience = db.WorkExperiences.AsNoTracking().FirstOrDefault(x => x.ExpId == workExperienceId);

            Mapper.Initialize(cfg => cfg.CreateMap<WorkExperience, WorkExperienceVM>());
            WorkExperienceVM workExperienceVM = Mapper.Map<WorkExperience, WorkExperienceVM>(workExperience);

            return Json(workExperienceVM, JsonRequestBehavior.AllowGet);
        }

        // Add and Update Actions

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

                return Json(userFromDB, JsonRequestBehavior.AllowGet);
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

                return Json(userFromDB, JsonRequestBehavior.AllowGet);
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
                int id = _resumeRepository.AddOrUpdateEducation(edu, userId);
                education.EduID = id;

                return Json(education, JsonRequestBehavior.AllowGet);
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

                skill.SkillID = sk.SkillID;
                return Json(skill, JsonRequestBehavior.AllowGet);
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

                project.ProjectID = pr.ProjectID;
                return Json(project, JsonRequestBehavior.AllowGet);
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
                WorkExperience workExperience = Mapper.Map<WorkExperienceVM, WorkExperience>(work);
                string msg = _resumeRepository.AddOrUpdateExperience(workExperience, userId);

                work.ExpId = workExperience.ExpId;
                return Json(work, JsonRequestBehavior.AllowGet);
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
                Language language = Mapper.Map<LanguageVM, Language>(lang);
                string msg = _resumeRepository.AddorUpdateLanguage(language, userId);

                lang.LanguageID = language.LanguageID;
                return Json(lang, JsonRequestBehavior.AllowGet);
            }

            return Content("Failed");
        }

        // Delete Actions

        [HttpDelete]
        public ActionResult DeleteProject(int id)
        {
            var projectDetails = db.Projects.FirstOrDefault(x => x.ProjectID == id);
            if (projectDetails != null)
            {
                db.Projects.Remove(projectDetails);
                db.SaveChanges();
                return Content("Success");
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpDelete]
        public ActionResult DeleteEducation(int id)
        {
            try
            {
                db.Educations.Remove(db.Educations.FirstOrDefault(m => m.EduID == id));
                db.SaveChanges();
                return Content("Success");
            }
            catch
            {
                return Content("Failed");
            }
        }

        [HttpDelete]
        public ActionResult DeleteLanguage(int id)
        {
            var languageDetails = db.Languages.FirstOrDefault(x => x.LanguageID == id);
            if (languageDetails != null)
            {
                db.Languages.Remove(languageDetails);
                db.SaveChanges();
                return Content("Success");
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpDelete]
        public ActionResult DeleteSkill(int id)
        {
            var skillDetails = db.Skills.FirstOrDefault(x => x.SkillID == id);
            if (skillDetails != null)
            {
                db.Skills.Remove(skillDetails);
                db.SaveChanges();
                return Content("Success");
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpDelete]
        public ActionResult DeleteWorkExperience(int id)
        {
            var workExperience = db.WorkExperiences.FirstOrDefault(x => x.ExpId == id);
            if (workExperience != null)
            {
                db.WorkExperiences.Remove(workExperience);
                db.SaveChanges();
                return Content("Success");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}