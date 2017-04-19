using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Net.Mail;
using System.Windows.Forms;

namespace ShutdownMonitoring
{
    public class Email
    {
        private Connect con;
        string bodyHtml = "";

        public Email()
        {
            con = new Connect();
        }

        public void sendEmail(string to)
        {
            try
            {
                MailMessage mail = new MailMessage("leopoldo_espitia@baxter.com", to);
                SmtpClient client = new SmtpClient();


                client.Host = "BN1PRD9201.prod.outlook.com";
                //client.Host = "smtp.google.com";
                client.Port = 25;
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //client.Credentials = new System.Net.NetworkCredential("leopoldo_espitia@baxter.com", "Baxter6.");

                mail.From = new MailAddress("baxnotificaciones@baxter.com");
                mail.Subject = "Prueba";
                mail.Body = bodyHtml;
                mail.IsBodyHtml = true;
                client.Send(mail);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void writeBody(string query)
        {
            
            string body = con.getValues(query);
            using (StreamReader reader= new StreamReader(@"\\mxtswtjnts\Groups\GRP Tijuana Departments\Plastics\2015 Plastics DB\CAPA Tool\emailTemplete.html"))
            {
                bodyHtml = reader.ReadToEnd();
            }
            bodyHtml = bodyHtml.Replace("{table}", body);
        }
    }
}
