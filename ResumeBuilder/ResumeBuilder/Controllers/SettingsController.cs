
using ResumeBuilder.Models;
using ResumeBuilder.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeBuilder.Controllers
{
    public class SettingsController : Controller
    {
        ResumeBuilderDBContext db = new ResumeBuilderDBContext();
        
        public ActionResult Settings()
        {
            var userId = Int32.Parse(User.Identity.Name);
            var settings = db.Users.Include("Settings").Where(x => x.UserID == userId).Select(x => x.Settings).FirstOrDefault();

           // Mapper.Initialize(cfg => cfg.CreateMap<Settings, SettingsVM>());
           // SettingsVM settingsVM = Mapper.Map<Settings,SettingsVM>(settings);

            return PartialView("~/Views/Resume/Settings.cshtml");
        }

        public void AddOrUpdateSettings(SettingsVM settings)
        {
            //var setting = db.Users.Include("Settings").Where(x => x.UserID == Int32.Parse(User.Identity.Name)).Select(x => x.Settings).FirstOrDefault();

            //Mapper.Initialize(cfg => cfg.CreateMap<SettingsVM, Settings>());
           // Settings userSettings = Mapper.Map<SettingsVM, Settings>(settings);

            var personEntity = db.Users.Find(Int32.Parse(User.Identity.Name));

            //if (personEntity != null)
            //{
            //    if (!(personEntity.SettingsID > 0))
            //    {
            //        personEntity.Settings = new Settings();
            //    }

            //    personEntity.Settings.Education = userSettings.Education;
            //    personEntity.Settings.Project = userSettings.Project;
            //    personEntity.Settings.Skill = userSettings.Skill;
            //    personEntity.Settings.WorkExperience = userSettings.WorkExperience;
            //    personEntity.Settings.Language = userSettings.Language;

            //    db.SaveChanges();
            //}
        }
    }
}