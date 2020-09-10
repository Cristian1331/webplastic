using System;
using System.Globalization;
using System.Net.Mail;
using System.Data;
using System.Linq;

using System.Web.Mvc;

namespace WebPlastic.App_Data
{
    public class SentEmail : Controller
    {
        public void SendEmailForNewUser(string correoAlQueEnvio, string asuntoDelCorreo, string copiaCorreoEnvio, string textoDelCorreo, string correoDesdeElQueEnvio, string usuarioCorreEnvio, string contrasenaCorreoEnvio, string archivo)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add(correoAlQueEnvio);
            //Asunto
            mmsg.Subject = asuntoDelCorreo;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF32;
            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            mmsg.Bcc.Add(copiaCorreoEnvio);
            //Cuerpo del Mensaje
            mmsg.Body = textoDelCorreo;

            mmsg.BodyEncoding = System.Text.Encoding.UTF32;
            mmsg.IsBodyHtml = false;
            if (archivo.Length > 2) mmsg.Attachments.Add(new Attachment(archivo));
            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress(correoDesdeElQueEnvio);

            /*-------------------------CLIENTE DE CORREO----------------------*/
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            //Hay que crear las credenciales del correo emisor
            cliente.Credentials = new System.Net.NetworkCredential(usuarioCorreEnvio, contrasenaCorreoEnvio);
            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.office365.com";
            cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
            cliente.Timeout = 5000;
            mmsg.IsBodyHtml = true;
            try
            {
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException)
            {
            }
        }

        public string EmailForNewUser(string name, string last, string userName, string password)
        {
            string strBody = "<html>";
            strBody += "<head><style type=\"text/css\">.curpointer {cursor: pointer;}</style></head> ";
            strBody += "<body style='font-family: Leitura Sans Grot 1; font-size: 14px; color: #323E48'>";
            strBody += "<p>Estimado(a) " + name + " " + last + ",</p>";
            strBody += "<label>Su nombre de usuario y contrase&ntilde;a para webplastic se han creado de la siguiente manera:&nbsp;</label></br>";
            strBody += "<label>Usuario: " + userName + "</label></br>";
            strBody += "<label>Contrase&ntilde;a: " + password + "</label></br>";
            strBody += "<p>Si no realiz&oacute; esta solicitud, ignore este correo electr&oacute;nico.</p></br>";
            strBody += "<p>Atentamente,&nbsp;</p>";
            strBody += "<br>WEBPLASTIC<br>";
            strBody += "</body>";
            strBody += "</html>";
            strBody += "</body>";
            strBody += "</html>";
            return strBody;
        }
    }
}
