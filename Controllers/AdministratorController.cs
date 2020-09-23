using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPlastic.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult MyProfile()
        {
            return View();
        }

        public ActionResult MyCart()
        {
            return View();
        }

        public ActionResult CreateArticle()
        {
            return View();
        }
    }
}