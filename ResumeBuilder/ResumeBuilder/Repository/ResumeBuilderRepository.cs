using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResumeBuilder.Models;

namespace ResumeBuilder.Repository {
    public class ResumeBuilderRepository : IResumeBuilderRepository {
        ResumeBuilderDBContext db = new ResumeBuilderDBContext ();

        public bool AddBasicInformation (User userInfo) {
            try {
                int records = 0;

                if (userInfo != null) {
                    db.Users.Add (userInfo);
                    db.Entry (userInfo).State = EntityState.Modified;
                    records = db.SaveChanges ();
                }

                return records > 0 ? true : false;
            } catch (DbEntityValidationException dbEx) {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors) {
                    foreach (var validationError in validationErrors.ValidationErrors) {
                        string message = string.Format ("{0}:{1}",
                            validationErrors.Entry.Entity.ToString (),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException (message, raise);
                    }
                }
                throw raise;
            }
        }

        public bool AddSummary (User summary, int idUser) {
            int records = 0;

            if (summary != null) {
                var user = db.Users.FirstOrDefault (x => x.UserID == idUser);
                user.Summary = summary.Summary;
                user.ResumeName = summary.ResumeName;
                records = db.SaveChanges ();
            }

            return records > 0 ? true : false;
        }

        public string AddOrUpdateEducation (Education education, int idUser) {

            var personEntity = db.Users.Include("Education").FirstOrDefault (x => x.UserID == idUser);
            bool repeatition = personEntity.Education.Any(x => x.EducationLevel == education.EducationLevel);

            if (personEntity != null && !repeatition) {
                if (education.EduID > 0) {
                    //we will update education entity
                    education.UserID = idUser;
                    db.Entry (education).State = EntityState.Modified;

                } else {
                    // we will add new education entity
                    personEntity.Education.Add (education);

                }

                try {
                    db.SaveChanges ();
                    return "Education Added";
                } catch (Exception e) {
                    throw e;
                }
            } else {
                if (personEntity == null)
                    return "Invalid User";
                else
                    return "Repeatition of data";
            }

        }

        public string AddorUpdateSkill (Skill skill, int idUser) {
            string msg = string.Empty;
            int countRecords = 0;
            var personEntity = db.Users.Include("Skills").FirstOrDefault (x => x.UserID == idUser);
            var ifSkillInDb = db.Skills.FirstOrDefault (x => x.SkillName == skill.SkillName);

            if (personEntity != null && skill != null) {
                var userSkills = personEntity.Skills;

                if (userSkills.Any (x => x.SkillName == skill.SkillName))
                    return "Skill already present";
                else {
                    if (ifSkillInDb != null) {
                        personEntity.Skills.Add (ifSkillInDb);
                    } else {
                        db.Skills.Add (skill);
                        personEntity.Skills.Add (skill);
                    }
                    countRecords = db.SaveChanges ();
                }
                msg = "Skill has been Added successfully";

            }
            return countRecords > 0 ? msg : "Falied to Add";

        }

        public string AddorUpdateProject (Project project, int idUser) {
            string msg = string.Empty;
            int countRecords = 0;
            var personEntity = db.Users.Include("Projects").FirstOrDefault (x => x.UserID == idUser);

            if (personEntity != null && project != null) {
                if (project.ProjectID > 0) {
                    project.UserID = idUser;
                    db.Entry (project).State = EntityState.Modified;
                    db.SaveChanges ();
                    msg = "Project has been updated successfully";
                } else {
                    personEntity.Projects.Add (project);
                    countRecords = db.SaveChanges ();
                    msg = "Project has been Added successfully";
                }
            }
            return countRecords > 0 ? msg : "Failed to Add";
        }

        public string AddOrUpdateExperience (WorkExperience work, int idUser) {
            string msg = string.Empty;
            int countRecords = 0;
            var personEntity = db.Users.Include("WorkExperiences").FirstOrDefault (x => x.UserID == idUser);

            if (personEntity != null && work != null) {
                if (work.ExpId > 0) {
                    work.UserID = idUser;
                    db.Entry (work).State = EntityState.Modified;
                    db.SaveChanges ();
                    msg = "Work Experience has been updated successfully";
                } else {
                    personEntity.WorkExperiences.Add (work);
                    countRecords = db.SaveChanges ();
                    msg = "Work Experience has been Added successfully";
                }
            }
            return countRecords > 0 ? msg : "Failed to Add";
        }

        public string AddorUpdateLanguage (Language language, int idUser) {
            string msg = string.Empty;
            int countRecords = 0;
            var personEntity = db.Users.Include("Languages").FirstOrDefault (x => x.UserID == idUser);
            var ifLanguageInDb = db.Languages.FirstOrDefault (x => x.LanguageName == language.LanguageName);

            if (personEntity != null && language != null) {
                var userLanguages = personEntity.Languages;

                if (userLanguages.Any (x => x.LanguageName == language.LanguageName))
                    return "Language already present";
                else {
                    if (ifLanguageInDb != null) {
                        personEntity.Languages.Add (ifLanguageInDb);
                    } else {
                        db.Languages.Add (language);
                        personEntity.Languages.Add (language);
                    }
                    countRecords = db.SaveChanges ();
                }
                msg = "Language has been Added successfully";

            }

            return countRecords > 0 ? msg : "Failed to add";
        }

        public User GetBasicInfo (int idUser) {
            var user = db.Users.AsNoTracking ().FirstOrDefault (x => x.UserID == idUser);

            return user;
        }

        public IQueryable<Education> GetEducationById (int idUser) {
            var education = db.Educations.AsNoTracking ().Where (x => x.UserID == idUser);

            return education;

        }

        public IQueryable<WorkExperience> GetWorkExperienceById (int idUser) {
            var workExperience = db.WorkExperiences.AsNoTracking ().Where (x => x.UserID == idUser);

            return workExperience;
        }

        public IQueryable<Skill> GetSkillsById (int idUser) {
            var userSkill = db.Skills.AsNoTracking ().Where (x => x.Users.Any (y => y.UserID == idUser));

            return userSkill;
        }

        public IQueryable<Project> GetProjectById (int idUser) {
            var project = db.Projects.AsNoTracking ().Where (x => x.User.UserID == idUser);

            return project;
        }

        public IQueryable<Language> GetLanguageById (int idUser) {
            var language = db.Languages.AsNoTracking ().Where (x => x.Users.Any (y => y.UserID == idUser));

            return language;
        }
    }
}