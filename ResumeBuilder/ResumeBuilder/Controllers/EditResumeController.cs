using ResumeBuilder.Models;
using ResumeBuilder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeBuilder.Controllers
{
    public class EditResumeController : Controller
    {
        private readonly IResumeBuilderRepository _resumeRepository;
        public EditResumeController()
        {
            _resumeRepository = new ResumeBuilderRepository();
        }

        // GET: Resume
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BasicInformation(int idUser)
        {
            var userBasicInfo = _resumeRepository.GetBasicInfo(idUser);

            return Json(userBasicInfo,JsonRequestBehavior.AllowGet);
        }

        
        [HttpPost]
        public ActionResult AddBasicInformation(UserInfo user)
        {
            user.UserID = Int32.Parse(User.Identity.Name);
            if (ModelState.IsValid)
            {
                Int32.Parse(User.Identity.Name);
                bool result = _resumeRepository.AddBasicInformation(user);

                if (result)
                {
                    
                    return Json(result);
                }
                else
                {
                    ViewBag.Message = "Something Wrong !";
                    return Json(ViewBag.Message);
                }
            }
            ViewBag.MessageForm = "Please Check your form before submit !";
            return Json(ViewBag.MessageForm);

        }

        [HttpPost]
        [ActionName("Summary")]
        public ActionResult AddOrUpdateSummary(UserInfo summary)
        {
            string msg = string.Empty;

            if (summary.Summary != null)
            {
                ResumeBuilderRepository rbr = new ResumeBuilderRepository();
                rbr.AddSummary(summary, 1);//Int32.Parse(User.Identity.Name));

            }
            else
            {
                Content("Please re try the operation");
            }

            return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public ActionResult Education(EducationVM education)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddOrUpdateEducation(EducationVM education)
        //{
        //    string msg = string.Empty;

        //    if (education != null)
        //    {
        //        //Creating Mapping
        //        Mapper.Initialize(cfg => cfg.CreateMap<EducationVM, Education>());
        //        Education educationEntity = Mapper.Map<Education>(education);

        //        int idPer = (int)Session["IdSelected"];

        //        msg = _resumeRepository.AddOrUpdateEducation(educationEntity, idPer);

        //    }
        //    else
        //    {
        //        msg = "Please re try the operation";
        //    }

        //    return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        //public PartialViewResult EducationPartial(EducationVM education)
        //{

        //    education.ListOfCountry = GetCountries();

        //    return PartialView("~/Views/Shared/_MyEducation.cshtml", education);
        //}

        //[HttpGet]
        //public ActionResult WorkExperience()
        //{
        //    return View();
        //}

        //public PartialViewResult WorkExperiencePartial(WorkExperienceVM workExperience)
        //{
        //    workExperience.ListeOfCountries = GetCountries();

        //    return PartialView("~/Views/Shared/_MyWorkExperience.cshtml", workExperience);
        //}

        //public ActionResult AddOrUpdateExperience(WorkExperienceVM workExperience)
        //{

        //    string msg = string.Empty;

        //    if (workExperience != null)
        //    {
        //        //Creating Mapping
        //        Mapper.Initialize(cfg => cfg.CreateMap<WorkExperienceVM, WorkExperience>());
        //        WorkExperience workExperienceEntity = Mapper.Map<WorkExperience>(workExperience);

        //        int idPer = (int)Session["IdSelected"];


        //        msg = _resumeRepository.AddOrUpdateExperience(workExperienceEntity, idPer);

        //    }
        //    else
        //    {
        //        msg = "Please re try the operation";
        //    }

        //    return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        //public ActionResult SkiCerfLang()
        //{
        //    return View();
        //}

        //public PartialViewResult SkillsPartial()
        //{
        //    return PartialView("~/Views/Shared/_MySkills.cshtml");
        //}

        //public ActionResult AddSkill(SkillsVM skill)
        //{
        //    int idPer = (int)Session["IdSelected"];
        //    string msg = string.Empty;

        //    //Creating Mapping
        //    Mapper.Initialize(cfg => cfg.CreateMap<SkillsVM, Skill>());
        //    Skill skillEntity = Mapper.Map<Skill>(skill);

        //    if (_resumeRepository.AddSkill(skillEntity, idPer))
        //    {
        //        msg = "skill added successfully";
        //    }
        //    else
        //    {
        //        msg = "something Wrong";
        //    }

        //    return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
        //}

        //public PartialViewResult CertificationsPartial(CertificationVM certification)
        //{
        //    List<SelectListItem> certificationLevel = new List<SelectListItem>()
        //{
        //    new SelectListItem { Text = "Beginner", Value = "Beginner", Selected = true},
        //    new SelectListItem { Text = "Intermediate", Value = "Intermediate"},
        //    new SelectListItem { Text = "Advanced", Value = "Advanced"}
        //};

        //    certification.ListOfLevel = certificationLevel;

        //    return PartialView("~/Views/Shared/_MyCertifications.cshtml", certification);
        //}

        //public ActionResult AddCertification(CertificationVM certification)
        //{
        //    int idPer = (int)Session["IdSelected"];
        //    string msg = string.Empty;

        //    //Creating Mapping
        //    Mapper.Initialize(cfg => cfg.CreateMap<CertificationVM, Certification>());
        //    Certification certificationEntity = Mapper.Map<Certification>(certification);

        //    if (_resumeRepository.AddCertification(certificationEntity, idPer))
        //    {
        //        msg = "Certification added successfully";
        //    }
        //    else
        //    {
        //        msg = "something Wrong";
        //    }

        //    return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
        //}

        //public PartialViewResult LanguagePartial(LanguageVM language)
        //{
        //    List<SelectListItem> languageLevel = new List<SelectListItem>()
        //{
        //    new SelectListItem { Text = "Elementary Proficiency", Value = "Elementary Proficiency", Selected = true},
        //    new SelectListItem { Text = "LimitedWorking Proficiency", Value = "LimitedWorking Proficiency"},
        //    new SelectListItem { Text = "Professional working Proficiency", Value = "Professional working Proficiency"},
        //    new SelectListItem { Text = "Full Professional Proficiency", Value = "Full Professional Proficiency"},
        //    new SelectListItem { Text = "Native Or Bilingual Proficiency", Value = "Native Or Bilingual Proficiency"}
        //};

        //    language.ListOfProficiency = languageLevel;

        //    return PartialView("~/Views/Shared/_MyLanguage.cshtml", language);
        //}

        //public ActionResult AddLanguage(LanguageVM language)
        //{
        //    int idPer = (int)Session["IdSelected"];
        //    string msg = string.Empty;

        //    //Creating Mapping
        //    Mapper.Initialize(cfg => cfg.CreateMap<LanguageVM, Language>());
        //    Language languageEntity = Mapper.Map<Language>(language);

        //    if (_resumeRepository.AddLanguage(languageEntity, idPer))
        //    {
        //        msg = "Language added successfully";
        //    }
        //    else
        //    {
        //        msg = "something Wrong";
        //    }

        //    return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult CV()
        //{
        //    return View();
        //}

        //public PartialViewResult GetPersonnalInfoPartial()
        //{
        //    int idPer = (int)Session["IdSelected"];
        //    Person person = _resumeRepository.GetPersonnalInfo(idPer);

        //    //Creating Mapping
        //    Mapper.Initialize(cfg => cfg.CreateMap<Person, PersonVM>());
        //    PersonVM personVM = Mapper.Map<PersonVM>(person);

        //    return PartialView("~/Views/Shared/_MyPersonnalInfo.cshtml", personVM);
        //}

        //public PartialViewResult GetEducationCVPartial()
        //{
        //    int idPer = (int)Session["IdSelected"];

        //    //Creating Mapping
        //    Mapper.Initialize(cfg => cfg.CreateMap<Education, EducationVM>());
        //    IQueryable<EducationVM> educationList = _resumeRepository.GetEducationById(idPer).ProjectTo<EducationVM>().AsQueryable();

        //    return PartialView("~/Views/Shared/_MyEducationCV.cshtml", educationList);
        //}

        //public PartialViewResult WorkExperienceCVPartial()
        //{
        //    int idPer = (int)Session["IdSelected"];

        //    //Creating Mapping
        //    Mapper.Initialize(cfg => cfg.CreateMap<WorkExperience, WorkExperienceVM>());
        //    IQueryable<WorkExperienceVM> workExperienceList = _resumeRepository.GetWorkExperienceById(idPer).ProjectTo<WorkExperienceVM>().AsQueryable();


        //    return PartialView("~/Views/Shared/_WorkExperienceCV.cshtml", workExperienceList);
        //}

        //public PartialViewResult SkillsCVPartial()
        //{
        //    int idPer = (int)Session["IdSelected"];

        //    //Creating Mapping
        //    Mapper.Initialize(cfg => cfg.CreateMap<Skill, SkillsVM>());
        //    IQueryable<SkillsVM> skillsList = _resumeRepository.GetSkillsById(idPer).ProjectTo<SkillsVM>().AsQueryable();


        //    return PartialView("~/Views/Shared/_MySkillsCV.cshtml", skillsList);
        //}

        //public PartialViewResult CertificationsCVPartial()
        //{
        //    int idPer = (int)Session["IdSelected"];

        //    //Creating Mapping
        //    Mapper.Initialize(cfg => cfg.CreateMap<Certification, CertificationVM>());
        //    IQueryable<CertificationVM> certificationList = _resumeRepository.GetCertificationsById(idPer).ProjectTo<CertificationVM>().AsQueryable();


        //    return PartialView("~/Views/Shared/_MyCertificationCV.cshtml", certificationList);
        //}

        //public PartialViewResult LanguageCVPartial()
        //{
        //    int idPer = (int)Session["IdSelected"];

        //    //Creating Mapping
        //    Mapper.Initialize(cfg => cfg.CreateMap<Language, LanguageVM>());
        //    IQueryable<LanguageVM> languageList = _resumeRepository.GetLanguageById(idPer).ProjectTo<LanguageVM>().AsQueryable();


        //    return PartialView("~/Views/Shared/_MyLanguageCV.cshtml", languageList);
        //}

        //public ActionResult GetProfilImage(int id)
        //{
        //    byte[] image = _resumeRepository.GetPersonnalInfo(id).Profil;
        //    if (image != null)
        //    {
        //        return File(image, "image/png");
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}

        //public ActionResult GetCities(string country)
        //{
        //    List<SelectListItem> listOfCities = new List<SelectListItem>();


        //    switch (country)
        //    {
        //        case "Morocco":
        //            listOfCities.Add(new SelectListItem() { Text = "Rabat", Value = "Rabat", Selected = true });
        //            listOfCities.Add(new SelectListItem() { Text = "Marrakech", Value = "Marrakech" });
        //            listOfCities.Add(new SelectListItem() { Text = "Tetouan", Value = "Tetouan" });
        //            break;

        //        case "India":
        //            listOfCities.Add(new SelectListItem() { Text = "Bombay", Value = "Bombay", Selected = true });
        //            listOfCities.Add(new SelectListItem() { Text = "Bangalore", Value = "Bangalore" });
        //            listOfCities.Add(new SelectListItem() { Text = "Chennai", Value = "Chennai" });
        //            listOfCities.Add(new SelectListItem() { Text = "Hyderabad", Value = "Hyderabad" });
        //            break;

        //        case "Spain":
        //            listOfCities.Add(new SelectListItem() { Text = "Barcelone", Value = "Barcelone", Selected = true });
        //            listOfCities.Add(new SelectListItem() { Text = "Madrid", Value = "Madrid" });
        //            listOfCities.Add(new SelectListItem() { Text = "Valence", Value = "Valence" });
        //            listOfCities.Add(new SelectListItem() { Text = "Malaga", Value = "Malaga" });
        //            break;

        //        case "USA":
        //            listOfCities.Add(new SelectListItem() { Text = "New York", Value = "New York", Selected = true });
        //            listOfCities.Add(new SelectListItem() { Text = "Los Angeles", Value = "Los Angeles" });
        //            listOfCities.Add(new SelectListItem() { Text = "San Francisco", Value = "San Francisco" });
        //            listOfCities.Add(new SelectListItem() { Text = "Chicago", Value = "Chicago" });
        //            break;
        //    }

        //    return Json(new { data = listOfCities }, JsonRequestBehavior.AllowGet);
        //}

        //public List<SelectListItem> GetCountries()
        //{
        //    List<SelectListItem> listOfCountry = new List<SelectListItem>()
        //{
        //    new SelectListItem() { Text = "Morocco", Value = "Morocco", Selected = true},
        //    new SelectListItem() { Text = "India", Value = "India"},
        //    new SelectListItem() { Text = "Spain", Value = "Spain"},
        //    new SelectListItem() { Text = "USA", Value = "USA"}
        //};

        //    return listOfCountry;
        //}
    }
}