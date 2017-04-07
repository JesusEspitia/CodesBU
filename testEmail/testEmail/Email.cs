using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace testEmail
{
    class Email
    {
        public void sendEmail(string to)
        {
            MailMessage correo = new MailMessage();
            try
            {
                //MailMessage mail = new MailMessage("leopoldo.espitia@gmail.com", to);
                //SmtpClient client = new SmtpClient();
                //client.Host = "smtp.google.com";
                //client.Port = 587;
                //client.EnableSsl = false;
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.UseDefaultCredentials = false;
                //client.Credentials = new System.Net.NetworkCredential("leopoldo.espitia@gmail.com", "foster9324");

                //mail.Subject = "Prueba";
                //mail.Body = "Mensaje de prueba";
                //client.Send(mail);

                string micoreo = "leopoldo_espitia@baxter.com";

                correo.From = new MailAddress(micoreo);
                correo.To.Add(to);
                correo.Subject = "Prueba";
                correo.Body = "Mensaje de prueba";
                correo.IsBodyHtml = false;
                correo.Priority = MailPriority.Normal;
                ////enviar correo
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential(micoreo, "Baxter6.");
                smtp.Host = "BN1PRD9201.prod.outlook.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;

                smtp.Send(correo);
                Console.WriteLine("Correo enviado");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);          
            }
        }
        public void SendCDO(string to)
        {
            try
            {
                CDO.Message msg = new CDO.Message();
                CDO.IConfiguration iConfig;
                iConfig = msg.Configuration;
                ADODB.Fields oFields;
                oFields = iConfig.Fields;
                ADODB.Field oField = oFields["http://schemas.microsoft.com/cdo/configuration/sendusing"];
                //oField.Value = 2;
                //oField = oFields["http://schemas.microsoft.com/cdo/configuration/smtpserver"];
                //oField.Value = "smtp.gmail.com";
                //oField = oFields["http://schemas.microsoft.com/cdo/configuration/stmpserverport"];
                //oField.Value = 25;
                oFields.Update();
                msg.Subject = "Prueba";
                msg.From = "plasticos_notificaciones@baxter.com";
                msg.To = to;
                msg.TextBody = "Mensaje de pueba";
                msg.Send();
                Console.WriteLine("Mensaje enviado");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
