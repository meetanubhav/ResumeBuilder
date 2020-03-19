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
                
            if(summary != null)
            {
                var user = db.Users.FirstOrDefault(x => x.UserID == idUser);
                user.Summary = summary.Summary;
                user.ResumeName = summary.ResumeName;
                records = db.SaveChanges();  
            }

            return records > 0 ? true : false;
        }

        public string AddOrUpdateEducation(Education education, int idUser)
        {
            string msg = string.Empty;

            var personEntity = db.Users.Find(idUser);

            if (personEntity != null)
            {
                if (education.EduID > 0)
                {
                    //we will update education entity
                    education.UserID = idUser;
                    db.Entry(education).State = EntityState.Modified;
                    db.SaveChanges();

                    msg = "Education entity has been updated successfully";
                }
                else
                {
                    // we will add new education entity
                    personEntity.Education.Add(education);
                    db.SaveChanges();

                    msg = "Education entity has been Added successfully";
                }
            }

            return msg;
        }

        public int GetIdPerson(string email)
        {
            int idSelected = db.Users.Where(p => p.Email.Equals(email))
                                              .Select(p => p.UserID).FirstOrDefault();

            return idSelected;
        }

        public string AddOrUpdateExperience(WorkExperience workExperience, int idUser)
        {
            string msg = string.Empty;

            var personEntity = db.Users.Find(idUser);

            if (personEntity != null)
            {
                if (workExperience.ExpId > 0)
                {
                    //we will update education entity
                    db.Entry(workExperience).State = EntityState.Modified;
                    db.SaveChanges();

                    msg = "Work Experience entity has been updated successfully";
                }
                else
                {
                    // we will add new education entity
                    personEntity.WorkExperiences.Add(workExperience);
                    db.SaveChanges();

                    msg = "Education entity has been Added successfully";
                }
            }

            return msg;
        }

        public bool AddSkill(Skill skill, int idUser)
        {
            int countRecords = 0;
            var personEntity = db.Users.Find(idUser);

            if(personEntity != null && skill != null)
            {
                personEntity.Skills.Add(skill);
                countRecords = db.SaveChanges();
            }

            return countRecords > 0 ? true : false;
            
        }

        public bool AddProject(Project project, int idUser)
        {
            int countRecords = 0;
            var personEntity = db.Users.Find(idUser);

            if (personEntity != null && project != null)
            {
                personEntity.Projects.Add(project);
                countRecords = db.SaveChanges();
            }

            return countRecords > 0 ? true : false;
        }

        public bool AddLanguage(Language language, int idUser)
        {
            int countRecords = 0;
            var personEntity = db.Users.Find(idUser);

            if (personEntity != null && language != null)
            {
                personEntity.Languages.Add(language);
                countRecords = db.SaveChanges();
            }

            return countRecords > 0 ? true : false;
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
            var userSkill = db.Skills.Where(x => x.Users.Any(y=>y.UserID==idUser));

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