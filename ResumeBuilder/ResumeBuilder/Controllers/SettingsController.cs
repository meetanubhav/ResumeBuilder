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
        public ActionResult Settings()
        {
            var vm = new SettingsVM();
            return PartialView("~/Views/Resume/Settings.cshtml", vm);
        }
    }
}