using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;

namespace ShutdownMonitoring
{
    public class Notifiy
    {
        private ConnectNotify con;
        private Email email;
        private string to = "";
        private string copy = "";
        private string from = "";
        private string subject="";
        private string body = "";

        public Notifiy()
        {
            con = new ConnectNotify();
            email = new Email();
        }

        public void ReadNewNotify()
        {
            
            List<string> listIDs = new List<string>();
            con.fillList("select ID from Emails where Sent=false", listIDs);
            if (listIDs.Count > 0)
            {
                foreach(string s in listIDs)
                {
                    to = con.getValue(string.Format("select Para from Emails where ID={0}", s));
                    copy = con.getValue(string.Format("select CC from Emails where ID={0}", s));
                    from= con.getValue(string.Format("select De from Emails where ID={0}", s));
                    subject= con.getValue(string.Format("select Subject from Emails where ID={0}", s));
                    body= con.getValue(string.Format("select BodyFile from Emails where ID={0}", s));
                    if (body != "")
                    {
                        email.writeBodyNotify(body);
                        email.sendEmail(to, subject, copy, from);
                    }
                    con.executeQuery(string.Format("update Emails set Sent=true where ID={0}", s));
                    try
                    {
                        File.Delete(@"\\mxtswtjnts\Groups\GRP Tijuana Departments\Plastics\2015 Plastics DB\CAPA Tool\TempFiles\" + body);
                    }
                    catch { }
                }
            }
        }

    }
}
