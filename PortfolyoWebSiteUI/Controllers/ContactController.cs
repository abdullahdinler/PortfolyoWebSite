using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;

namespace PortfolyoWebSiteUI.Controllers
{
    public class ContactController : Controller
    {
        private ContactManager cm = new ContactManager(new EfContactDal());
        // GET: Contact
        public ActionResult Index(int? pageNo, string word)
        {
            int _pageNo = pageNo ?? 1;
            string _word = word ?? "";
            {
                var result = cm.Search(_word).OrderByDescending(x => x.Id).ToPagedList<Contact>(_pageNo, 10);
                return View(result);
            }
            var c2 = cm.GetList().OrderByDescending(x => x.Id).ToPagedList<Contact>(_pageNo, 10);
            return View(c2);
        }

        public PartialViewResult MessageCount()
        {
            var result = cm.GetList().Count(x=>x.Status == true);
            ViewBag.Count = result;
            return PartialView();
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            
                var result = cm.GetById(id);
                result.Status = false;
                cm.Update(result);
                return View(result);
        }

        public ActionResult Delete(int id)
        {
            var entity = cm.GetById(id);
            cm.Delete(entity);
            return RedirectToAction("Index", "Contact");
        }


    }
}