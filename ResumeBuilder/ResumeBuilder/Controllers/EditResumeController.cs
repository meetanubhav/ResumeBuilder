using AutoMapper;
using ResumeBuilder.Models;
using ResumeBuilder.Models.ViewModel;
using ResumeBuilder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            try
            {
                var education = db.Educations.AsNoTracking().FirstOrDefault(x => x.EduID == educationId);

                EducationVM educationVM = Mapper.Map<EducationVM>(education);

                return Json(educationVM, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public JsonResult GetProject(int projectId)
        {
            try
            {
                var project = db.Projects.AsNoTracking().FirstOrDefault(x => x.ProjectID == projectId);

                ProjectVM projectVM = Mapper.Map<ProjectVM>(project);

                return Json(projectVM, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public JsonResult GetWorkExperience(int workExperienceId)
        {
            try
            {
                var workExperience = db.WorkExperiences.AsNoTracking().FirstOrDefault(x => x.ExpId == workExperienceId);

                WorkExperienceVM workExperienceVM = Mapper.Map<WorkExperienceVM>(workExperience);

                return Json(workExperienceVM, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                throw e;
            }
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

                try
                {
                    db.SaveChanges();
                }
                catch(Exception e)
                {
                    throw e;
                }

                return Json(userFromDB, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Content("Failed");
            }
        }

        [HttpPost]
        public ActionResult AddSummaryInfo(SummaryVM summaryInfo)
        {
            var userID = Int32.Parse(User.Identity.Name);
            if (ModelState.IsValid)
            {
                var userFromDB = db.Users.FirstOrDefault(x => x.UserID == userID);
                userFromDB.ResumeName = summaryInfo.ResumeName;
                userFromDB.Summary = summaryInfo.Summary;

                try
                {
                    db.SaveChanges();
                }
                catch(Exception e)
                {
                    throw e;
                }

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
                Education edu = Mapper.Map<Education>(education);
                int id = _resumeRepository.AddOrUpdateEducation(edu, userId);

                if (id == 0)
                {
                    return Content("Unauthorized access");
                }
                
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
                try
                {
                    Skill sk = Mapper.Map<Skill>(skill);
                    string msg = _resumeRepository.AddorUpdateSkill(sk, userId);

                    if (msg == "Failed to add")
                        return Content("Failed");
                    else if (msg == "Skill already present")
                        return Content(msg);

                    skill.SkillID = sk.SkillID;
                    return Json(skill, JsonRequestBehavior.AllowGet);
                }
                catch(Exception e)
                {
                    throw e;
                }
            }

            return Content("Failed");
        }

        [HttpPost]
        public ActionResult AddProject(ProjectVM project)
        {
            int userId = Int32.Parse(User.Identity.Name);
            if (ModelState.IsValid)
            {
                try
                {
                    Project pr = Mapper.Map<Project>(project);
                    string msg = _resumeRepository.AddorUpdateProject(pr, userId);

                    project.ProjectID = pr.ProjectID;
                    return Json(project, JsonRequestBehavior.AllowGet);
                }
                catch(Exception e)
                {
                    throw e;
                }
            }

            return Content("Failed");
        }

        [HttpPost]
        public ActionResult AddWorkExp(WorkExperienceVM work)
        {
            int userId = Int32.Parse(User.Identity.Name);
            if (ModelState.IsValid)
            {
                try
                {
                    WorkExperience workExperience = Mapper.Map<WorkExperience>(work);
                    string msg = _resumeRepository.AddOrUpdateExperience(workExperience, userId);

                    work.ExpId = workExperience.ExpId;
                    return Json(work, JsonRequestBehavior.AllowGet);
                }
                catch(Exception e)
                {
                    throw e;
                }
            }

            return Content("Failed");
        }

        [HttpPost]
        public ActionResult AddLanguage(LanguageVM lang)
        {
            int userId = Int32.Parse(User.Identity.Name);
            if (ModelState.IsValid)
            {
                try
                {
                    Language language = Mapper.Map<Language>(lang);
                    string msg = _resumeRepository.AddorUpdateLanguage(language, userId);

                    if (msg == "Failed to add")
                        return Content("Failed");
                    else if (msg == "Language already present")
                        return Content(msg);
                    lang.LanguageID = language.LanguageID;
                    return Json(lang, JsonRequestBehavior.AllowGet);
                }
                catch(Exception e)
                {
                    throw e;
                }
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
                try
                {
                    db.Projects.Remove(projectDetails);
                    db.SaveChanges();
                    return Content("Success");
                }
                catch(Exception e)
                {
                    throw e;
                }
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
                try
                {
                    db.Languages.Remove(languageDetails);
                    db.SaveChanges();
                    return Content("Success");
                }
                catch(Exception e)
                {
                    throw e;
                }
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
                try
                {
                    db.Skills.Remove(skillDetails);
                    db.SaveChanges();
                    return Content("Success");
                }
                catch(Exception e)
                {
                    throw e;
                }
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
                try
                {
                    db.WorkExperiences.Remove(workExperience);
                    db.SaveChanges();
                    return Content("Success");
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
            else
            {
                return HttpNotFound();
            }
        }
        
    }
}