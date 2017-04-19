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
        private Email email;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            email = new Email();
            email.writeBody("select Equipment, Shutdown_Time,Description from Shutdown_Monitoring where Solved=false");
            email.sendEmail("leopoldo_espitia@baxter.com");
        }
    }
}
