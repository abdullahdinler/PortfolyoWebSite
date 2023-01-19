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
    public class AboutController : Controller
    {
        private readonly AboutManager _abm = new AboutManager(new EfAboutDal());

        private readonly AboutValidator _av = new AboutValidator();
        // GET: About
        public ActionResult Index()
        {
            ViewBag.mssg = TempData["mssg"] as string;
            var result = _abm.GetList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = _abm.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(About entity)
        {
            ValidationResult result = _av.Validate(entity);
            if (result.IsValid)
            {
                entity.Birthday = DateTime.Parse( "2000-06-19");
                entity.City = "İzmir";

                string fileName = Path.GetFileName(Request.Files[0]?.FileName);
                string extension = Path.GetExtension(Request.Files[0]?.FileName);
                string path = "/Image/" + fileName + extension;
                Request.Files[0]?.SaveAs(Server.MapPath(path));
                entity.Img = "/Image/" + fileName + extension;
                TempData["mssg"] = "true";
                _abm.Update(entity);
                return RedirectToAction("Index" , "About");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }
    }
}