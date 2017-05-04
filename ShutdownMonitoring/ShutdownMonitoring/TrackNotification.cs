using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShutdownMonitoring
{
    public class TrackNotification
    {
        private MysqlDatabase mycon;
        private Email email;
        private List<string> areasId = new List<string>();
        private List<string> emails = new List<string>();
                
        public TrackNotification()
        {
            mycon = new MysqlDatabase();
            email = new Email();
        }

        public void getNewNotify()
        {
            areasId.Clear();
            mycon.fillList(areasId, "select Area_OrdenId from area_orden where notify=true");
        }

        public void makeEmail()
        {
            if (areasId.Count > 0)
            {
                foreach (string s in areasId)
                {
                    int actualArea = 0;
                    int nextArea = 0;
                    string to = "";
                    string batch = "";


                    actualArea = Convert.ToInt32(mycon.getValue(
                        string.Format("select a.orden from area_orden as b inner join Areas as a on b.AreaId=a.AreaId where b.Area_OrdenId={0}",
                        s)));
                    batch = mycon.getValue(string.Format(
                        "select w.BatchOrden from workordens as w inner join area_orden as a on w.workordenid=a.workordenid where a.area_ordenid={0}",
                        s));
                    if (actualArea != 6)
                    {
                        nextArea = actualArea + 1;
                        int newarea = Convert.ToInt32(mycon.getValue(string.Format("select AreaId from Areas where orden={0}", nextArea)));
                        emails.Clear();
                        mycon.fillList(emails, string.Format("select emailuser from users where areaid={0}", newarea));

                        foreach (string e in emails)
                        {
                            email.writeBody(batch);
                            email.sendEmail(e, string.Format("Notificación de TrackBatch: Nuevo batch por iniciar (No. {0})",batch),
                                "");
                        }
                    }
                    mycon.executeQuery(string.Format("update Area_orden set notify=false where area_ordenid={0}", s));
                }
            }
        }

    }
}
