using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Numbers _numbers;
        private void Form1_Load(object sender, EventArgs e)
        {
            //double x = (double)1 / 100;
            this.Text = "Generador de numeros pseudoaleatorios";
            this.label1.Text = "Valor de a:";
            this.label2.Text = "Valor de C:";
            this.label3.Text = "Valor de X:";
            this.label4.Text = "Valor de M:";
            this.label5.Text = "Números a generar:";
            this.bntGenerete.Text = "Generar";
            this.btnExcel.Text = "Exportar";
            this.btnView.Text = "Mostrar";
            this.btnView.Enabled = false;
            this.btnExcel.Enabled = false;

            this.txtValueA.Text = Convert.ToString(3);
            this.txtValueC.Text = Convert.ToString(10);
            this.txtValueX.Text = Convert.ToString(2);
            this.txtValueM.Text = "104729";

        }

        private void bntGenerete_Click(object sender, EventArgs e)
        {
            _numbers = new Numbers()
            {
                a = Convert.ToInt32(txtValueA.Text),
                c = Convert.ToInt32(txtValueC.Text),
                M = Convert.ToDouble(txtValueM.Text),
                X = Convert.ToDouble(txtValueX.Text),
                n=Convert.ToInt32(txtMax.Text),
            };
            _numbers.generateNumberList(Convert.ToInt32(txtMax.Text));
            if (_numbers.ValidNumber() == true)
            {
                MessageBox.Show("Los número estan distribuidos uniformemente.", "Validación de lo numeros", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Los no número estan distribuidos uniformemente.", "Validación de lo numeros", MessageBoxButtons.OK);
            }
            this.btnExcel.Enabled = true;
            this.btnView.Enabled = true;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se exportaran los números generados a un archivo de Excel.","Exportar números",MessageBoxButtons.OK);
            try
            {
                _numbers.GenereteExcel();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar archivo. Mensaje:" + ex.Message, "Exportar números", MessageBoxButtons.OK);
            }
        }
        private DataGridView dtg;
        private void btnView_Click(object sender, EventArgs e)
        {
            if (this.btnView.Text == "Mostrar")
            {
                dtg = new DataGridView();
                this.dtg.Location = new System.Drawing.Point(50, 350);
                this.dtg.Size = new System.Drawing.Size(500, 200);
                this.dtg.AutoGenerateColumns = false;
                this.dtg.ColumnCount = 5;
                //this.dtg.Columns[0].Name = "Number";
                this.Controls.Add(this.dtg);
                this.Size = new System.Drawing.Size(617, 650);  

                this.btnView.Text = "Ocultar";
                _numbers.ShowNumbers(this.dtg,5);
            }
            else
            {
                this.Controls.Remove(this.dtg);
                this.Size = new System.Drawing.Size(617, 300);
                this.btnView.Text = "Mostrar";
            }

        }
    }
}
