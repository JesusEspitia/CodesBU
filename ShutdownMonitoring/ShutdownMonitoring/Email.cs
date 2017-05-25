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
    public class Email:Warehouse
    {
        private Connect con;
        string bodyHtml = "";
        private string fromEmail = "";
        private string fromName = "";

        public Email()
        {
            con = new Connect();
            conWare = new ConnectWarehouse();
        }

        public void sendEmail(string to,string title,string cc)
        {
            try
            {
                if (bodyHtml != "")
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

                    mail.From = new MailAddress("baxnotificaciones@baxter.com", "Baxter Tj Notificaciones");
                    mail.To.Add(to);
                    if (cc != "")
                    {
                        mail.CC.Add(cc);
                    }
                    mail.Subject = title;
                    mail.Body = bodyHtml;
                    mail.IsBodyHtml = true;
                    client.Send(mail);
                    bodyHtml = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void sendEmail(string to, string title, string cc,string from)
        {
            try
            {
                if (bodyHtml != "")
                {
                    getFrom(from);
                    MailMessage mail = new MailMessage();
                    SmtpClient client = new SmtpClient();


                    client.Host = "BN1PRD9201.prod.outlook.com";
                    //client.Host = "smtp.google.com";
                    client.Port = 25;
                    client.EnableSsl = false;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    //client.Credentials = new System.Net.NetworkCredential("leopoldo_espitia@baxter.com", "Baxter6.");

                    mail.From = new MailAddress(fromEmail);
                    mail.To.Add(formatString(to));
                    if (cc != "")
                    {
                        mail.CC.Add(formatString(cc));
                        mail.CC.Add(fromEmail);
                    }
                    mail.Subject = title;
                    mail.Body = bodyHtml;
                    mail.IsBodyHtml = true;
                    client.Send(mail);
                    bodyHtml = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void writeBody(string query,string header)
        {
            bodyHtml = "";
            machines.Clear();
            string body = con.getValues(query);
            con.fillList("select Equipment from Shutdown_Monitoring where Solved=false", machines);
            getParts(machines);
            getDays();
            if (body != "")
            {
                using (StreamReader reader = new StreamReader(@"\\mxtswtjnts\Groups\GRP Tijuana Departments\Plastics\2015 Plastics DB\Shutdown Monitoring\emailTemplete.html"))
                {
                    bodyHtml = reader.ReadToEnd();
                }
                bodyHtml = bodyHtml.Replace("{titulo} ", header);
                bodyHtml = bodyHtml.Replace("{table}", body);
                bodyHtml = bodyHtml.Replace("{comp}", headText);
                bodyHtml = bodyHtml.Replace("{ware}", resulthtml);
            }
            //resulthtml = "";
            
        }

        public void writeBody(string batch)
        {
            bodyHtml = "";
            using (StreamReader reader = new StreamReader(@"\\mxtswtjnts\Groups\GRP Tijuana Departments\Plastics\2015 Plastics DB\Shutdown Monitoring\noti.html"))
            {
                bodyHtml = reader.ReadToEnd();
            }
            bodyHtml = bodyHtml.Replace("{orden}", batch);
        }

        public void writeBodyNotify(string path)
        {
            bodyHtml = "";
            using (StreamReader reader = new StreamReader(@"\\mxtswtjnts\Groups\GRP Tijuana Departments\Plastics\2015 Plastics DB\CAPA Tool\TempFiles\" + path))
            {
                bodyHtml = reader.ReadToEnd();
            }
        }

        private void getFrom(string from)
        {
            fromEmail = "";
            fromName = "";
            fromName = from.Split('<', '>')[0];
            fromEmail= from.Split('<', '>')[1];
            //int cont = 0;
            //int pos1 = 0;
            //int pos2 = 0;
            //foreach(char c in from)
            //{
            //    cont++;
            //    if (c == '<')
            //    {
            //        pos1 = cont;
            //    }
            //    if(c=='>')
            //    {
            //        pos2 = cont;
            //    }
            //}
        }

        private string formatString(string emails)
        {
            string value = "";
            int i = 0;
            foreach(char c in emails)
            {
                i++;
                if (c == ';' && i != emails.Length)
                {
                    value += ',';
                }
                else
                {
                    if (c != ';')
                    {
                        value += c;
                    }
                }
            }
            return value;
        }
    }
}
