using ResumeBuilder.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeBuilder.Repository
{
    public class ResumeBuilderRepository : IResumeBuilderRepository
    {
        ResumeBuilderDBContext db = new ResumeBuilderDBContext();

        public bool AddBasicInformation(User userInfo)
        {
            try
            {
                int records = 0;

                if (userInfo != null)
                {
                    db.Users.Add(userInfo);
                    //userInfo.Summary = string.Empty;
                    //userInfo.ResumeName = string.Empty;
                    //db.Users.Add(userInfo);
                    db.Entry(userInfo).State = EntityState.Modified;
                    records = db.SaveChanges();
                }

                return records > 0 ? true : false;
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        public bool AddSummary(User summary, int idUser)
        {
            int records = 0;

            if (summary != null)
            {
                var user = db.Users.FirstOrDefault(x => x.UserID == idUser);
                user.Summary = summary.Summary;
                user.ResumeName = summary.ResumeName;
                records = db.SaveChanges();
            }

            return records > 0 ? true : false;
        }

        public int AddOrUpdateEducation(Education education, int idUser)
        {

            var personEntity = db.Users.Include("Education").FirstOrDefault(x => x.UserID == idUser);

            if (personEntity != null)
            {
                if (education.EduID > 0)
                {
                    //we will update education entity
                    education.UserID = idUser;
                    db.Entry(education).State = EntityState.Modified;
                    db.SaveChanges();

                }
                else
                {
                    // we will add new education entity
                    personEntity.Education.Add(education);
                    db.SaveChanges();

                }
            }

            return education.EduID;
        }

        public int GetIdPerson(string email)
        {
            int idSelected = db.Users.Where(p => p.Email.Equals(email))
                                              .Select(p => p.UserID).FirstOrDefault();

            return idSelected;
        }

        public string AddorUpdateSkill(Skill skill, int idUser)
        {
            string msg = string.Empty;
            int countRecords = 0;
            var personEntity = db.Users.Include("Skills").FirstOrDefault(x => x.UserID == idUser);

            if (personEntity != null && skill != null)
            {
                if (skill.SkillID > 0)
                {

                    db.Entry(skill).State = EntityState.Modified;
                    db.SaveChanges();
                    msg = "Skill has been updated successfully";

                }
                else
                {
                    db.Skills.Add(skill);
                    personEntity.Skills.Add(skill);
                    countRecords = db.SaveChanges();
                    msg = "Skill has been Added successfully";
                }
            }
            return countRecords > 0 ? msg : "Falied to Add";

        }

        public string AddorUpdateProject(Project project, int idUser)
        {
            string msg = string.Empty;
            int countRecords = 0;
            var personEntity = db.Users.Include("Projects").FirstOrDefault(x => x.UserID == idUser);
            project.UserID = idUser;
            if (personEntity != null && project != null)
            {
                if (project.ProjectID > 0)
                {
                    project.UserID = idUser;
                    db.Entry(project).State = EntityState.Modified;
                    db.SaveChanges();
                    msg = "Project has been updated successfully";
                }

                else
                {
                    personEntity.Projects.Add(project);
                    countRecords = db.SaveChanges();
                    msg = "Project has been Added successfully";
                }
            }
            return countRecords > 0 ? msg : "Failed to Add";
        }

        public string AddOrUpdateExperience(WorkExperience work, int idUser)
        {
            string msg = string.Empty;
            int countRecords = 0;
            var personEntity = db.Users.Include("WorkExperiences").FirstOrDefault(x => x.UserID == idUser);
            if (personEntity != null && work != null)
            {
                if (work.ExpId > 0)
                {
                    work.UserID = idUser;
                    db.Entry(work).State = EntityState.Modified;
                    db.SaveChanges();
                    msg = "Work Experience has been updated successfully";
                }

                else
                {
                    personEntity.WorkExperiences.Add(work);
                    countRecords = db.SaveChanges();
                    msg = "Work Experience has been Added successfully";
                }
            }
            return countRecords > 0 ? msg : "Failed to Add";
        }

        public string AddorUpdateLanguage(Language language, int idUser)
        {
            string msg = string.Empty;
            int countRecords = 0;
            var personEntity = db.Users.Include("Languages").FirstOrDefault(x => x.UserID == idUser);

            if (language.LanguageID > 0)
            {
                db.Entry(language).State = EntityState.Modified;
                db.SaveChanges();
                msg = "Languages has been updated successfully";
            }

            else
            {
                personEntity.Languages.Add(language);
                countRecords = db.SaveChanges();
                msg = "Languages has been Added successfully";
            }

            return countRecords > 0 ? msg : "Failed to add";
        }

        public User GetBasicInfo(int idUser)
        {
            var user = db.Users.FirstOrDefault(x => x.UserID == idUser);

            return user;
        }

        public IQueryable<Education> GetEducationById(int idUser)
        {
            var education = db.Educations.Where(x => x.UserID == idUser);

            return education;

        }

        public IQueryable<WorkExperience> GetWorkExperienceById(int idUser)
        {
            var workExperience = db.WorkExperiences.Where(x => x.UserID == idUser);

            return workExperience;
        }

        public IQueryable<Skill> GetSkillsById(int idUser)
        {
            var userSkill = db.Skills.Where(x => x.Users.Any(y => y.UserID == idUser));

            return userSkill;
        }

        public IQueryable<Project> GetProjectById(int idUser)
        {
            var project = db.Projects.Where(x => x.User.UserID == idUser);

            return project;
        }

        public IQueryable<Language> GetLanguageById(int idUser)
        {
            var language = db.Languages.Where(x => x.Users.Any(y => y.UserID == idUser));

            return language;
        }
    }
}