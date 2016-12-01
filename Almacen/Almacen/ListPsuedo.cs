using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Almacen
{
    public partial class ListPsuedo : Form
    {
        public Numeros numero = new Numeros();
        public ListPsuedo()
        {
            InitializeComponent();
        }
        
        private void ListPsuedo_Load(object sender, EventArgs e)
        {
            this.dtgList.AutoGenerateColumns = false;
            this.dtgList.ColumnCount = 2;
            Form1.numero.ShowNumbers(this.dtgList, 1);
        }

        private void dtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
