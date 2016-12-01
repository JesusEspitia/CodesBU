using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace Almacen
{
    public class Numeros
    {
        public Excell excel;
        public List<double> pseudoNumbers = new List<double>();
        OpenFileDialog fileDialog= new OpenFileDialog();
        public void fillList()
        {
            try
            {
                string filename = "";
                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    filename = fileDialog.FileName;
                }
                excel = new Excell(filename);
                excel.fillList(this.pseudoNumbers);
                MessageBox.Show("Números cargados correctamente.", "Carga de números", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los números. Error:" + ex.Message, "Falla en carga de números", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ShowNumbers(DataGridView dtg, int _long)
        {

            int i = 0;
            int j = 1;

            foreach (double d in pseudoNumbers)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtg);

                row.Cells[0].Value = d.ToString();

                dtg.Rows.Add(row);
            }

        }
    }
}
