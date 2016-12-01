using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace Generador
{
    public class Excel
    {
        public void exportToExcel(List<double> mylist)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            int Fila = 0;
            int Col = 1;
            foreach (double d in mylist)
            {
                Fila++;
                excel.Cells[Fila,Col] = d;
                if (Fila == 20)
                {
                    Col++;
                    Fila = 0;
                }
            }
            excel.Visible = true;
        }
    }
}
