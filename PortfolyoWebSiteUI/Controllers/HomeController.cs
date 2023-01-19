using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace PortfolyoWebSiteUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private AboutManager about = new AboutManager(new EfAboutDal());
        private SocialMediaManager smm = new SocialMediaManager(new EfSocialMediaDal());
        private SkillManager slm = new SkillManager(new EfSkillDal());
        private EducationManager edm = new EducationManager(new EfEducationDal());
        private ExperienceManager epm = new ExperienceManager(new EfExperienceDal());
        private PortfolioManager pm = new PortfolioManager(new EfPortfolioDal());
        private ServiceManager sm = new ServiceManager(new EfServiceDal());
        private ContactManager cm = new ContactManager(new EfContactDal());
        private ContactValidator _validator = new ContactValidator();
        private ValidationResult vr;
        public ActionResult Index()
        {
            ViewBag.mssg = TempData["mssg"] as string;
            return View();
        }
        [HttpGet]
        public PartialViewResult About()
        {
            var result = about.GetList();
            return PartialView(result);
        }
        public PartialViewResult SocialMedia()
        {
            var result = smm.GetList();
            return PartialView(result);
        }
        public PartialViewResult Skill()
        {
            var result = slm.GetList();
            return PartialView(result);
        }
        public PartialViewResult Education()
        {
            var result = edm.GetList();
            return PartialView(result);
        }

        public PartialViewResult Experience()
        {
            var result = epm.GetList();
            return PartialView(result);
        }

        public PartialViewResult Portfolio()
        {
            var result = pm.GetList();
            return PartialView(result);
        }

        public PartialViewResult Service()
        {
            var result = sm.GetList();
            return PartialView(result);
        }

        [HttpGet]
        public PartialViewResult Contact()
        {
            
            return PartialView();
        }

      
        public ActionResult Contact2(Contact entity)
        {
            vr = _validator.Validate(entity);
            if (vr.IsValid)
            {
                entity.MessageDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
                entity.Status = true;
                TempData["mssg"] = "true";
                cm.Add(entity);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in vr.Errors)
                {
                    ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                }
            }
            return View();
        }
    }
}