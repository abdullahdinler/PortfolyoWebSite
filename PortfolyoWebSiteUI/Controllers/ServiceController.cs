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
    public class ServiceController : Controller
    {
        private ServiceManager sm = new ServiceManager(new EfServiceDal());

        private ServiceValidator sv = new ServiceValidator();

        private ValidationResult vr;
        // GET: Service
        public ActionResult Index()
        {
            ViewBag.add = TempData["add"];
            ViewBag.edit = TempData["edit"];
            var result = sm.GetList();
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Service entity)
        {
            vr = sv.Validate(entity);
            if (vr.IsValid)
            {
                TempData["add"] = "true";
                string fileName = Path.GetFileName(Request.Files[0]?.FileName);
                string extension = Path.GetExtension(Request.Files[0]?.FileName);
                string path = "/Image/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                entity.Img = path;
                sm.Add(entity);
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = sm.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Service entity)
        {
            vr = sv.Validate(entity);
            if (vr.IsValid)
            {
                TempData["edit"] = "true";
                string fileName = Path.GetFileName(Request.Files[0]?.FileName);
                string extension = Path.GetExtension(Request.Files[0]?.FileName);
                string path = "/Image/" + fileName + extension;
                Request.Files[0]?.SaveAs(Server.MapPath(path));
                entity.Img = path;
                sm.Update(entity);
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

        public ActionResult Delete(int id)
        {
            var result = sm.GetById(id);
            sm.Delete(result);
            return RedirectToAction("Index");
        }
    }
}