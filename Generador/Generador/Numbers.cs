using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generador
{
    class Numbers
    {
        public int a { get; set; }
        public int c { get; set; }
        public double X { get; set; }
        public double M { get; set; }
        public int n { get; set; }
        public List<double> pseudo = new List<double>();
        private Excel _excel = new Excel();
        private double max, min;
        private double interval;
        public void generateNumberList(int max)
        {   
            double temp = 0;
            for (int i = 0; i < max; i++)
            {
                temp = (a * X + c) % M;

                pseudo.Add(temp/M);
                X = temp;
            }
            //_excel.exportToExcel(pseudo);
            //ValidNumber();
        }
        public bool ValidNumber()
        {
            double p=PruebaMedias();
            double i=LimInf();
            double s=LimSup();
                if (p >= i && p <= s)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private double PruebaMedias()
        {
            double sumatoria = 0;
            foreach (double d in pseudo)
            {
                sumatoria += d;
            }
            
            return ((double) 1/pseudo.Count) * (sumatoria);
        }
        private double LimSup()
        {
            return 0.5 + (1.96 * (1 / (Math.Sqrt(12 * pseudo.Count()))));
        }
        private double LimInf()
        {
            return 0.5 - (1.96 * (1 / (Math.Sqrt(12 * pseudo.Count()))));
        }
        public void GenereteExcel()
        {
            if (pseudo.Count > 0)
            {
                _excel.exportToExcel(pseudo);
                MessageBox.Show("Archivo generado con exito.", "Exportar números", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No ha generado los números.", "Alerta", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }
        public void ShowNumbers(DataGridView dtg,int _long)
        {
            
            int i = 0;
            int j = 1;

            foreach (double d in pseudo)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtg);

                row.Cells[0].Value = d.ToString();

                dtg.Rows.Add(row);
            }

        }
    }
}
