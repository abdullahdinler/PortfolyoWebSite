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
    public class EducationController : Controller
    {
        private EducationManager em = new EducationManager(new EfEducationDal());

        private EducationValidator ev = new EducationValidator();
        // GET: Education
        public ActionResult Index()
        {
            ViewBag.mssg = TempData["mssg"] as string;
            ViewBag.edit = TempData["edit"] as string;
            var result = em.GetList();
            return View(result);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = em.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Education entity)
        {
            ValidationResult vr = ev.Validate(entity);
            if (vr.IsValid)
            {
                TempData["edit"] = "true";
                em.Update(entity);
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

        public ActionResult Delete(int id)
        {
            var entity = em.GetById(id);
            em.Delete(entity);
             return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Education entity)
        {
            ValidationResult vr = ev.Validate(entity);
            if (vr.IsValid)
            {
                TempData["mssg"] = "true";
                em.Add(entity);
                return RedirectToAction("Index","Education");
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