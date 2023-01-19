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
using PagedList;

namespace PortfolyoWebSiteUI.Controllers
{
    public class SkillController : Controller
    {
        private readonly SkillManager _sm = new SkillManager(new EfSkillDal());

        private readonly SkillValidator _sv = new SkillValidator();
        // GET: Skill
        public ActionResult Index(int? pageNo)
        {
            ViewBag.add = TempData["add"];
            ViewBag.edit = TempData["edit"];
            int _pageNo = pageNo ?? 1;
            var result = _sm.GetList().ToPagedList<Skill>(_pageNo,5);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
           var result = _sm.GetById(id);
           _sm.Delete(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Skill entity)
        {
            ValidationResult vr = _sv.Validate(entity);

            if (vr.IsValid)
            {
                TempData["add"] = "true";
              _sm.Add(entity);
              return RedirectToAction("Index");
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


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = _sm.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Skill entity)
        {
            ValidationResult vr = _sv.Validate(entity);

            if (vr.IsValid)
            {
                TempData["edit"] = "true";
                _sm.Update(entity);
                return RedirectToAction("Index");
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