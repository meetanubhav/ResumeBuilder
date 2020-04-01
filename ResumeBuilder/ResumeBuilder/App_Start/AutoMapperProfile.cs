using AutoMapper;
using ResumeBuilder.Models;
using ResumeBuilder.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeBuilder.App_Start
{
    public class AutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Education, EducationVM>().ReverseMap();
            CreateMap<Language, LanguageVM>().ReverseMap();
            CreateMap<Project, ProjectVM>().ReverseMap();
            CreateMap<Settings, SettingsVM>().ReverseMap();
            CreateMap<Skill, SkillVM>().ReverseMap();
            CreateMap<WorkExperience, WorkExperienceVM>().ReverseMap();
            CreateMap<User, UserResumeVM>().ReverseMap();
        }
    }
}