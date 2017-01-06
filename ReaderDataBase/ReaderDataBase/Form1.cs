using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReaderDataBase
{
    public partial class Form1 : Form
    {
        public ConnectAccess con;
        public MySqlConnect mycon;
        public static Orden orden= new Orden();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            con = new ConnectAccess();
            mycon = new MySqlConnect();
            con.ReadDataBase();
            mycon.InsertValues(Form1.orden.lstOrden);
        }
    }
}
