using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using Excel= Microsoft.Office.Interop.Excel;

namespace Almacen
{
    public class Excell
    {
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        Excel.Range range;
        string str;
        int rCnt;
        int cCnt;
        int rw = 0;
        int cl = 0;
        public Excell(string file)
        {
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(file,0,true,5,"","",true,Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,"\t",false,false,0,true,1,0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        }
        public void fillList(List<double> mylist)
        {
            range = xlWorkSheet.UsedRange;
            rw = range.Rows.Count;
            cl= range.Columns.Count;
            for (rCnt = 1; rCnt <= rw; rCnt++)
            {
                for (cCnt = 1; cCnt <= cl; cCnt++)
                {
                        mylist.Add(Convert.ToDouble((range.Cells[rCnt,cCnt] as Excel.Range).Value));
                }
            }
            xlWorkBook.Close(false);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }
    }
}
