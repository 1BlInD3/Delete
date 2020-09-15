using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace PaintCheck
{
    class Excel1
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook workbook;
        Worksheet worksheet;
        Range xlRange;
       // Range column = worksheet.get_Range[1,null];

        public Excel1(string path, int sheet)
        {
            this.path = path;
            // excel = new _Excel.Application()
            workbook = excel.Workbooks.Open(path);
            worksheet = workbook.Worksheets[sheet];
        }

        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (worksheet.Cells[i, j].Value2 != null)
            {
                string value = (worksheet.Cells[i, j].Value2).ToString();
                return value;//worksheet.Cells[i, j].Value2;
            }
            else return "";
        }
        public int GetRowNumber() 
        {
            int val = 0;
         //   xlRange = worksheet.UsedRange;
            //val = xlRange.Rows.Count;
            val = worksheet.Cells.Find("*", System.Reflection.Missing.Value,
                               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                               _Excel.XlSearchOrder.xlByRows, _Excel.XlSearchDirection.xlPrevious,
                               false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;
            //excel.Quit();
            return val;
        }
        public void WorkBookClose() 
        {
            workbook.Close(false);
        }
        public void ExcelClose()
        {
            excel.Quit();
        }
 
    }
    /*lastUsedColumn = worksheet.Cells.Find("*", System.Reflection.Missing.Value, 
                               System.Reflection.Missing.Value,System.Reflection.Missing.Value, 
                               Excel.XlSearchOrder.xlByColumns,Excel.XlSearchDirection.xlPrevious, 
                               false,System.Reflection.Missing.Value,System.Reflection.Missing.Value).Column;*/
}
