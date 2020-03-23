using AutoMapper;
using ResumeBuilder.Models;
using ResumeBuilder.Models.ViewModel;
using System;
using System.Collections.Generic;
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
            var settings = db.Users.Include("Settings").Where(x => x.UserID == 1).Select(x => x.Settings);

            Mapper.Initialize(cfg => cfg.CreateMap<Settings, SettingsVM>());
            //var settingsVM = Mapper.Map<Settings,SettingsVM>(settings);

            return PartialView("~/Views/Resume/Settings.cshtml");
        }
    }
}