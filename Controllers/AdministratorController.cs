using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPlastic.App_Data;

namespace WebPlastic.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult MyProfile()
        {
            ConnectionDataBase data = new ConnectionDataBase();
            DataTable dt = data.GetUser("");
            ViewBag.User = dt.Rows;
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


        public ActionResult editUser( int id)
        {
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dt = data.GetUser(id);
            ViewBag.Userr= dt.Rows;

            return View();
        }


       
        public ActionResult UpdateProfile(Models.User model, int id)
        {
            model.idUser = id;
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dt = data.UpdateUser(model);
            return RedirectToAction("index");
        }

        
      
    }
}