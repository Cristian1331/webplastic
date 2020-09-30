using System;
using System.Collections.Generic;
using System.Data;
<<<<<<< HEAD
using System.IO;
=======
>>>>>>> d0c07409010f7caea9788e5a1e631f2036de22a2
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
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable td = data.GetCart(Convert.ToInt32(Session["idUser"]));
            ViewBag.Articles = td.Rows;
            td = data.GetArticle();
            ViewBag.Article = td.Rows;
            return View();
        }
        //chages
        public ActionResult CreateArticle()
        {
            if (Session["idProfile"] != null)
            {
                ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
                DataTable td = data.GetCategory();
                ViewBag.Category = td.Rows;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult AddCart(int id)
        {
            if (Session["idProfile"] != null)
            {   
                ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
                DataTable td = data.AddCart(id, Convert.ToInt32(Session["idUser"]));
                ViewBag.Article = td.Rows;
                return RedirectToAction("MyCart", "Administrator");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult StorageArticle(Models.Article model)
        {
            if (Session["idProfile"] != null)
            {
                ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
                var nomaas = Request.Files;
                for (var i = 0; i < nomaas.Count; i++)
                {
                    if (nomaas[i].ContentLength > 0)
                    {
                        string FileName = Path.GetFileNameWithoutExtension(nomaas[i].FileName);
                        string FileExtension = Path.GetExtension(nomaas[i].FileName);
                        FileName = DateTime.Now.ToString("yyyyMMdd") + "_" + FileName.Trim() + FileExtension;
                        string UploadPath = System.Web.HttpContext.Current.Server.MapPath("/Content/images/");
                        string stringimg = "/Content/images/" + FileName;
                        nomaas[i].SaveAs(UploadPath + FileName);
                        model.Image = "/Content/images/" + FileName;
                    }
                }
                DataTable td = data.StorageArticle(model);
                return RedirectToAction("Catalogo", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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