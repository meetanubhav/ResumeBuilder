using ResumeBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Repository
{
     public interface IResumeBuilderRepository
    {
        bool AddBasicInformation(UserInfo userInfo);
        string AddOrUpdateEducation(Education education, int idUser);
        int GetIdPerson(string email);
        string AddOrUpdateExperience(WorkExperience workExperience, int idUser);
        bool AddSkill(UserSkill skill, int idUser);
        bool AddProject(Project project, int idUser);
        bool AddLanguage(Language language, int idUser);
        UserInfo GetBasicInfo(int idUser);
        IQueryable<Education> GetEducationById(int idUser);
        IQueryable<WorkExperience> GetWorkExperienceById(int idUser);
        IQueryable<UserSkill> GetSkillsById(int idUser);
        IQueryable<Project> GetProjectById(int idUser);
        IQueryable<Language> GetLanguageById(int idUser);
    }
}
