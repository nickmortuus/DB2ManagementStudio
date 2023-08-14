using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace DB2ManagementStudio
{
    public class ExcelFileCreator
    {
        public static void saveExcelFile(ExcelFile file, string filename, string filepath)
        {
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                Logger.WriteToLog("Excel is not properly installed!!");
                return;
            }


            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // Put headers in excel file
            if (file.CheckForHeaders() == true)
            {
                for (int i = 0; i < file.fileColumns; i++)
                {
                    xlWorkSheet.Cells[1, 1 + i] = file.headerRow.record[0 + i];
                }

            }

            // put data in excel file
            if (file.CheckForHeaders() == true)
            {
                for (int row = 0; row < file.records.Count(); row++)
                {
                    for (int column = 0; column < file.fileColumns; column++)
                    {
                        xlWorkSheet.Cells[2 + row, 1 + column] = file.records[row].record[column];
                    }
                }
            }
            else
            {
                for (int row = 0; row < file.records.Count(); row++)
                {
                    for (int column = 0; column < file.fileColumns; column++)
                    {
                        xlWorkSheet.Cells[1 + row, 1 + column] = file.records[row].record[column];
                    }
                }
            }

            xlWorkBook.SaveAs(filepath + filename, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, false, false, Excel.XlSaveAsAccessMode.xlNoChange, Excel.XlSaveConflictResolution.xlUserResolution, true, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }
    }
}
