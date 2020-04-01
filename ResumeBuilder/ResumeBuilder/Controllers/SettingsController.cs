using AutoMapper;
using ResumeBuilder.Models;
using ResumeBuilder.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeBuilder.Controllers
{
    public class SettingsController : Controller 
    {
        ResumeBuilderDBContext db = new ResumeBuilderDBContext();

        [HttpGet]
        public ActionResult Settings()
        {
            var userId = Int32.Parse(User.Identity.Name);
            var personEntity = db.Users.Include("Settings").Where(x => x.UserID == userId).FirstOrDefault();

            if (personEntity.Settings == null)
            {
                personEntity.Settings = new Settings();
                db.SaveChanges();
            }

            var settings = personEntity.Settings;

            var settingsVM = Mapper.Map<Settings, SettingsVM>(settings);

            return PartialView("~/Views/Resume/Settings.cshtml", settingsVM);
        }

        [HttpPost]
        public ActionResult AddOrUpdateSettings(SettingsVM settings)
        {
            Settings userSettings = Mapper.Map<Settings>(settings);
            
            var userId = Int32.Parse(User.Identity.Name);
            var personEntity = db.Users.Include("Settings").FirstOrDefault(x => x.UserID == userId);

            if (personEntity != null)
            {
                personEntity.Settings.Education = userSettings.Education;
                personEntity.Settings.Project = userSettings.Project;
                personEntity.Settings.Skill = userSettings.Skill;
                personEntity.Settings.WorkExperience = userSettings.WorkExperience;
                personEntity.Settings.Language = userSettings.Language;

                try
                {
                    db.SaveChanges();
                    Console.WriteLine("Settings Updated");

                    return Content("success");
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw e;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw e;
                }
            }

            return Content("failure");
        }
    }
}