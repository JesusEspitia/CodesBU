using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Almacen
{
    public partial class Form1 : Form
    {
        public static Numeros numero = new Numeros();
        public Form1()
        {
            InitializeComponent();
        }

        private void cagarNúmerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            numero.fillList();
            numero.pseudoNumbers.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mostrarNúmerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListPsuedo list = new ListPsuedo();
            list.Show();
        }
    }
}
