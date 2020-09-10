using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using WebPlastic.App_Data;
using System.Data;
using System.Security.Cryptography;

namespace WebPlastic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuienesSomos()
        {
            return View();
        }

        public ActionResult BlogSingle()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult Blog1()
        {
            return View();
        }

        public ActionResult Blog2()
        {
            return View();
        }

        public ActionResult Carrito()
        {
            return View();
        }

        public ActionResult Catalogo()
        {
            return View();
        }

        public ActionResult Contactanos()
        {
            return View();
        }

        public ActionResult Ingreso()
        {
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult CreateUser(WebPlastic.Models.User model)
        {
                    ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
                    CredencialesDeAcceso access = new CredencialesDeAcceso();
                    string password = access.CreatePassword();
                    RijndaelManaged myRijndael = new RijndaelManaged();
                    myRijndael.GenerateKey();
                    myRijndael.GenerateIV();
                    string user = access.CreateUserName(model.Name, model.Last).ToLower();
                    model.UserName = user;
                    Byte[] contrasenaEncriptada = access.EncryptStringToBytes(password, myRijndael.Key, myRijndael.IV);

                    DataTable dt = data.SaveUser(model, contrasenaEncriptada, myRijndael.Key, myRijndael.IV);
                    DataRow row = dt.Rows[0];
                    if (dt.Rows.Count > 0)
                    {
                        SentEmail correoCreacion = new SentEmail();
                        string bodyCorreo = correoCreacion.EmailForNewUser(model.Name, model.Last, model.UserName, password);
                        correoCreacion.SendEmailForNewUser(model.Email, "Creación de Usuario", "soporte@metnet.co", bodyCorreo, "soporte@metnet.co", "soporte@metnet.co", "13A132b17#", "");

                    }
                
                return RedirectToAction("Index");
        }

        public ActionResult Login(Models.Login model)
        {
            Session["idUser"] = null;
            Session["idProfile"] = null;
            Session["Name"] = null;

            if (model.UserName != null)
            {
                ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
                CredencialesDeAcceso acceso = new CredencialesDeAcceso();
                DataTable dt = data.ValidarIngresoUsuario(model.UserName, GetMACAddress().ToString());
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    if (Convert.ToInt32(row["idProfile"]) == 2)
                    {
                        Session["message"] = "Este usuario se encuentra inactivo, por favor comunicar al administrador.";
                    }
                    else
                    {
                        byte[] password = (byte[])row["Password"];
                        byte[] key = (byte[])row["pKEY"];
                        byte[] iv = (byte[])row["pIV"];
                        if (password.Length > 2)
                        {
                            string finalpassword = acceso.DecryptStringFromBytes(password, key, iv);
                            if (finalpassword == model.Password)
                            {
                                    dynamic dol = null;
                                    if (dt.Rows.Count == 1)
                                        dol = dt.Rows[0];
                                    else
                                        dol = dt.Rows[1];
                                    Session["idUser"] = row["idUser"].ToString();
                                    Session["idProfile"] = row["idProfile"].ToString();
                                    Session["Name"] = row["Name"].ToString();
                                    Session["Last"] = row["Last"].ToString();
                                    Session["Email"] = row["Email"].ToString();
                                    Session["Profile"] = row["Profile"].ToString();
                                    if (Convert.ToInt32(Session["idProfile"]) == 1)
                                    {
                                        return RedirectToAction("IndexUser", "administrator");
                                    }
                                    else
                                    {
                                        return RedirectToAction("IndexUser", "administrator");
                                    }
                            }
                            else
                            {
                                Session["message"] = "Las credenciales de usuario no coinciden, verifique.";
                            }
                        }
                    }
                }
                else
                {
                    Session["message"] = "No se encontro datos de usuario con esas credenciales, por favor cree uno.";
                }
                Session["title"] = "Error";
                Session["type"] = "error";
            }
            return RedirectToAction("Index");
        }

        public string GetMACAddress()
        {
            System.Net.NetworkInformation.NetworkInterface[] nics = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (System.Net.NetworkInformation.NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    System.Net.NetworkInformation.IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }
    }
}