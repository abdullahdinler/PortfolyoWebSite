using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace PortfolyoWebSiteUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private AdminManager admin = new AdminManager(new EfAdminDal());
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.error = TempData["error"];
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin entity)
        {
            var result = admin.GetAdmin(entity.userName, entity.password);
            if (result != null)
            {
               FormsAuthentication.SetAuthCookie(entity.userName,false);
               Session["userName"] = entity.userName;
               return RedirectToAction("Index", "About");
            }
            else
            {
                TempData["error"] = "false";
                return RedirectToAction("Index","Login");
            }
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}