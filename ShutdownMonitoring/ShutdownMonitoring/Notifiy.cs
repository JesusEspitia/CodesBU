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
        private string to = "";
        private string cc = "";

        public Notifiy()
        {
            con = new ConnectNotify();
        }

        public void ReadNewNotify()
        {
            
            List<string> listIDs = new List<string>();
            con.fillList("select * from tabla where campo=null", listIDs);
            if (listIDs.Count > 0)
            {
                foreach(string s in listIDs)
                {
                    to = con.getValue(string.Format("select columnto form tabla where ID={0}", s));

                }
            }
        }

    }
}
