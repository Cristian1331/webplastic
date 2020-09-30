using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    }
}