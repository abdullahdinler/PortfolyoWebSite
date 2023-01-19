using System;
using System.Collections.Generic;
using System.IO;
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
    public class PortfolioController : Controller
    {
        private PortfolioManager pm = new PortfolioManager(new EfPortfolioDal());

        private PortfolioValidator pv = new PortfolioValidator();

        private ValidationResult vr;
        // GET: Portfolio
        public ActionResult Index()
        {

            ViewBag.add = TempData["add"];
            ViewBag.edit = TempData["edit"];
            var result = pm.GetList();
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            var entity = pm.GetById(id);
            pm.Delete(entity);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Portfolio entity)
        {
            vr = pv.Validate(entity);
            if (vr.IsValid)
            {
                TempData["add"] = "true";
                string fileName = Path.GetFileName(Request.Files[0]?.FileName);
                string extension = Path.GetExtension(Request.Files[0]?.FileName);
                string path = "/Image/" + fileName + extension;
                Request.Files[0]?.SaveAs(Server.MapPath(path));
                entity.Img = "/Image/" + fileName + extension;
                pm.Add(entity);
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
            var entity = pm.GetById(id);
            return View(entity);
        }

        [HttpPost]
        public ActionResult Edit(Portfolio entity)
        {
            vr = pv.Validate(entity);
            if (vr.IsValid)
            {
                TempData["edit"] = "true";
                string fileName = Path.GetFileName(Request.Files[0]?.FileName);
                string extension = Path.GetExtension(Request.Files[0]?.FileName);
                string path = "/Image/" + fileName + extension;
                Request.Files[0]?.SaveAs(Server.MapPath(path));
                entity.Img = "/Image/" + fileName + extension;
                pm.Update(entity);
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
    }
}