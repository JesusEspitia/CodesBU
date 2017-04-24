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

        public void sendEmail(string to,string title,string cc)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();


                client.Host = "BN1PRD9201.prod.outlook.com";
                //client.Host = "smtp.google.com";
                client.Port = 25;
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //client.Credentials = new System.Net.NetworkCredential("leopoldo_espitia@baxter.com", "Baxter6.");

                mail.From = new MailAddress("baxnotificaciones@baxter.com","Baxter Tj Notificaciones");
                mail.To.Add(to);
                if (cc != "")
                {
                    mail.CC.Add(cc);
                }
                mail.Subject = title;
                mail.Body = bodyHtml;
                mail.IsBodyHtml = true;
                client.Send(mail);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void writeBody(string query,string header)
        {
            bodyHtml = "";
            string body = con.getValues(query);
            using (StreamReader reader= new StreamReader(@"\\mxtswtjnts\Groups\GRP Tijuana Departments\Plastics\2015 Plastics DB\Shutdown Monitoring\emailTemplete.html"))
            {
                bodyHtml = reader.ReadToEnd();
            }
            bodyHtml = bodyHtml.Replace("{titulo} ", header);
            bodyHtml = bodyHtml.Replace("{table}", body);     
        }

        public void writeBodyNotify(string path)
        {
            bodyHtml = "";
            using (StreamReader reader = new StreamReader(path))
            {
                bodyHtml = reader.ReadToEnd();
            }
        }

    }
}
