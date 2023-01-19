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
    public class SocialMediaController : Controller
    {
        private SocialMediaManager smm = new SocialMediaManager(new EfSocialMediaDal());
        private SocialMediaValidator smv = new SocialMediaValidator();
        private ValidationResult vr;
        public ActionResult Index()
        {
            ViewBag.edit = TempData["edit"] as string;
           var result = smm.GetList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = smm.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(SocialMedia entity)
        {
            vr = smv.Validate(entity);
            if (vr.IsValid)
            {
                TempData["edit"] = "true";
                entity.Status = true;
                smm.Update(entity);
                return RedirectToAction("Index");
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


        public ActionResult Status(int id)
        {
            var result = smm.GetById(id);
            smm.Update(result);
            return RedirectToAction("Index");
        }


    }
}