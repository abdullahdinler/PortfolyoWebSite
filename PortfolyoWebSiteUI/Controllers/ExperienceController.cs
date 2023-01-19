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
    public class ExperienceController : Controller
    {
        private ExperienceManager em = new ExperienceManager(new EfExperienceDal());

        private ExperienceValidator ev = new ExperienceValidator();
        // GET: Education
        public ActionResult Index()
        {
            ViewBag.add = TempData["add"] as string;
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
        public ActionResult Edit(Experience entity)
        {
            ValidationResult vr = ev.Validate(entity);
            if (vr.IsValid)
            {
                TempData["edit"] = "true";
                em.Update(entity);
                return RedirectToAction("Index","Experience");
            }
            else
            {
                foreach (var error in vr.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
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
        public ActionResult Add(Experience entity)
        {
            ValidationResult vr = ev.Validate(entity);
            if (vr.IsValid)
            {
                TempData["add"] = "true";
                em.Add(entity);
                return RedirectToAction("Index", "Experience");
            }
            else
            {
                foreach (var error in vr.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }

    }
}