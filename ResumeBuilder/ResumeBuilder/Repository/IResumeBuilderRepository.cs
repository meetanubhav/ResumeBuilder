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
        bool AddBasicInformation(User userInfo);
        string AddOrUpdateEducation(Education education, int idUser);
        int GetIdPerson(string email);
        string AddOrUpdateExperience(WorkExperience workExperience, int idUser);
        string AddorUpdateSkill(Skill skill, int idUser);
        string AddorUpdateProject(Project project, int idUser);
        bool AddLanguage(Language language, int idUser);
        User GetBasicInfo(int idUser);
        IQueryable<Education> GetEducationById(int idUser);
        IQueryable<WorkExperience> GetWorkExperienceById(int idUser);
        IQueryable<Skill> GetSkillsById(int idUser);
        IQueryable<Project> GetProjectById(int idUser);
        IQueryable<Language> GetLanguageById(int idUser);
    }
}
