using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShutdownMonitoring
{
    public partial class Form1 : Form
    {
        private Connect con;
        private Notifiy noticon;
        private Email email;
        private TrackNotification track;
        private List<string> notify1 = new List<string>();
        private List<string> notify2 = new List<string>();
        private List<string> notify3 = new List<string>();
        private List<string> notify4 = new List<string>();
        private bool send = false;

        private string grupoA = "abraham_cano@baxter.com,jose_barragan@baxter.com,jose_montoya@baxter.com,fernando_vera@baxter.com,marco_vazquez@baxter.com,jorge_ramos@baxter.com,leticia_ramirez@baxter.com,mirtha_perez@baxter.com";
        private string grupoB = "abraham_cano@baxter.com,jose_barragan@baxter.com,jose_montoya@baxter.com,fernando_vera@baxter.com,marco_vazquez@baxter.com,jorge_ramos@baxter.com,leticia_ramirez@baxter.com,mirtha_perez@baxter.com,anibal_de_jesus_martinez@baxter.com,victor_alvarez@baxter.com";
        private string grupoC = " abraham_cano@baxter.com,jose_barragan@baxter.com,jose_montoya@baxter.com,fernando_vera@baxter.com,marco_vazquez@baxter.com,jorge_ramos@baxter.com, leticia_ramirez@baxter.com,mirtha_perez@baxter.com,anibal_de_jesus_martinez@baxter.com,victor_alvarez@baxter.com";
        private string grupoD = "abraham_cano@baxter.com,jose_barragan@baxter.com,jose_montoya@baxter.com,enrique_perez_sanchez@baxter.com,fernando_vera@baxter.com,marco_vazquez@baxter.com,jorge_ramos@baxter.com,leticia_ramirez@baxter.com,mirtha_perez@baxter.com,anibal_de_jesus_martinez@baxter.com,victor_alvarez@baxter.com";
        private string allGroup = "abraham_cano@baxter.com,jose_barragan@baxter.com,jose_montoya@baxter.com,fernando_vera@baxter.com,marco_vazquez@baxter.com,jorge_ramos@baxter.com, leticia_ramirez@baxter.com,mirtha_perez@baxter.com,anibal_de_jesus_martinez@baxter.com,victor_alvarez@baxter.com";
        private int turn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //noticon = new ConnectNotify();

            track = new TrackNotification();
            
            con = new Connect();
            email = new Email();

            noticon = new Notifiy();
            //email.writeBody(string.Format("select Equipment, Shutdown_Time,Description from Shutdown_Monitoring where ID={0}", "239"), "tittle", "239");
            //email.sendEmail("leopoldo_espitia@baxter.com", "", "leopoldo_espitia@baxter.com");
            //email.writeBody(string.Format("select Equipment, Shutdown_Time,Description from Shutdown_Monitoring where Solved=false"), "");
            //email.writeBodyNotify(@"\\mxtswtjnts\Groups\GRP Tijuana Departments\Plastics\2015 Plastics DB\CAPA Tool\temp.htm");
            //email.sendEmail("leopoldo_espitia@baxter.com", "Prueba", "");

            if (DateTime.Now.Hour >=6 && DateTime.Now.Hour < 18)
            {
                turn = 1;
            }
            if(DateTime.Now.Hour>=18 && DateTime.Now.Hour <= 23)
            {
                turn = 2;
            }
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 6)
            {
                turn = 2;
            }


            timerNotfitication();
            timer1.Interval = 60000;
            timer1.Start();
            //email.writeBody("select Equipment, Shutdown_Time,Description from Shutdown_Monitoring where Solved=false");
            //email.sendEmail("abraham_cano@baxter.com,jose_barragan@baxter.com,juan_c_munoz@baxter.com,fernando_vera@baxter.com, jorge_ramos@baxter.com, leticia_ramirez@baxter.com,edgar_aleman@baxter.com,mirtha_perez@baxter.com,anibal_de_jesus_martinez@baxter.com,victor_alvarez@baxter.com");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(con.getValueBool("select * from Shutdown_Monitoring where Solved=false and Not1=true") == true)
            {
                email.writeBody("select Equipment, Shutdown_Time,Description from Shutdown_Monitoring where Solved=false and Not1=true", "Equipos dentenidos.","n");
                email.sendEmail("leopoldo_espitia@baxter.com",
                    "Notificación. Equipo detenido","leopoldo_espitia@baxter.com");
                ChangeNot();
            }
            if (con.getValueBool("select * from Shutdown_Monitoring where Not2=true") == true)
            {
                email.writeBody("select Equipment, Shutdown_Time,Description from Shutdown_Monitoring where Not2=true", "Equipo(s) reiniciado(s).","n");
                email.sendEmail(allGroup,
                    "Notificación. Equipo reiniciado.", "leopoldo_espitia@baxter.com");
                ChangeStr();
            }
            timerNotfitication();

            if (checkTurn() == true)
            {
                allStops();
            }
            //track.getNewNotify();
            //track.makeEmail();
            noticon.ReadNewNotify();
        }

        public void ChangeNot()
        {
            List<string> lst = new List<string>();
            con.fillList("select * from Shutdown_Monitoring where Solved=false and Not1=true", lst);
            foreach(string s in lst)
            {
                con.executeQuery(string.Format("update Shutdown_Monitoring set Not1=false where ID={0}", s));
            }
        }

        public  void ChangeStr()
        {
            List<string> lst = new List<string>();
            con.fillList("select * from Shutdown_Monitoring where Not2=true", lst);
            foreach (string s in lst)
            {
                con.executeQuery(string.Format("update Shutdown_Monitoring set Not2=false where ID={0}", s));
            }
        }

        private void timerNotfitication()
        {
            Clearlist();
            List<string> stoped = new List<string>();
            con.fillList("select ID from Shutdown_Monitoring where Solved=false", stoped);
            if (stoped.Count > 0)
            {
                foreach (string s in stoped)
                {
                    DateTime d = Convert.ToDateTime(con.getValue(string.Format("select Shutdown_Time from Shutdown_Monitoring where ID={0}", s)));

                    double time = (DateTime.Now - d).TotalMinutes;
                    if (time >= 30 && time <= 31)
                    {
                        notify1.Add(s);
                    }
                    if (time >= 60 && time <= 61)
                    {
                        notify2.Add(s);
                    }
                    if (time >= 120 && time < 121)
                    {
                        notify3.Add(s);

                    }
                    if (time >= 240 && time <= 241)
                    {
                        notify4.Add(s);

                    }
                }
            }
            if (notify1.Count() > 0)
            {
                emailNotification("Notificación. Equipo(s) detenido(s) (Paro de 30 min.)", notify1,grupoA);
            }
            if (notify2.Count() > 0)
            {
                emailNotification("Notificación. Equipo(s) detenido(s) (Paro mayor a 1 hr.)", notify2, grupoB);
            }
            if (notify3.Count() > 0)
            {
                emailNotification("Notificación. Equipo(s) detenido(s) (Paro mayor a 2 hrs.)", notify3, grupoC);
            }
            if (notify4.Count() > 0)
            {
                emailNotification("Notificación. Equipo(s) detenido(s) (Paro mayor a 4 hrs.)", notify4, grupoD);
            }
        }

        private void Clearlist()
        {
            notify1.Clear();
            notify2.Clear();
            notify3.Clear();
            notify4.Clear();
        }

        private void emailNotification(string tittle,List<string> lst,string to)
        {
            foreach (string s in lst)
            {
                email.writeBody(string.Format("select Equipment, Shutdown_Time,Description from Shutdown_Monitoring where ID={0}",s), tittle,s);
                email.sendEmail(to, tittle, "leopoldo_espitia@baxter.com");
            }
        }

        private void allStops()
        {
            email.writeBody(string.Format("select Equipment, Shutdown_Time,Description from Shutdown_Monitoring where Solved=false"), "");
            email.sendEmail(allGroup, "Paros sin resolver durante el turno", "leopoldo_espitia@baxter.com");
        }

        private bool checkTurn()
        {
            int turno = 0;
            if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour < 18)
            {
                turno = 1;
            }
            if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour <= 23)
            {
                turno = 2;
            }
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 6)
            {
                turno = 2;
            }
            if (turn != turno)
            {
                turn = turno;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
