using ResumeBuilder.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Repository
{
    public class ResumeBuilderRepository : IResumeBuilderRepository
    {
        ResumeBuilderDBContext db = new ResumeBuilderDBContext();
        
        bool AddBasicInformation(UserInfo userInfo)
        {
            try
            {
                int records = 0;
                
                if (userInfo != null)
                {
                    userInfo.Summary = string.Empty;
                    userInfo.ResumeName = string.Empty;
                    db.UserInfos.Add(userInfo);
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
        string AddOrUpdateEducation(Education education, int idUser);
        int GetIdPerson(string email);
        string AddOrUpdateExperience(WorkExperience workExperience, int idUser);
        bool AddSkill(Skill skill, int idUser);
        bool AddProject(Project project, int idUser);
        bool AddLanguage(Language language, int idUser);
        User GetBasicInfo(int idUser);
        IQueryable<Education> GetEducationById(int idUser);
        IQueryable<WorkExperience> GetWorkExperienceById(int idUser);
        IQueryable<Skill> GetSkillsById(int idUser);
        IQueryable<Project> GetProjectById(int idUser);
        IQueryable<Language> GetLanguageById(int idUser);
    }
}