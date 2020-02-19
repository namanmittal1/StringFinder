using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace StringFinder
{
    class OpenExcelFile
    {
        String filename;
        int linenumber;
        int columnnumber;
        String datastring;
        Excel.Range range;

        public void getValues()
        {
            filename = ExcelDataCollection_ViewModel.Instance.SelectedListItem.FilenameList;
            linenumber = ExcelDataCollection_ViewModel.Instance.SelectedListItem.Linenumber_List;
            columnnumber = ExcelDataCollection_ViewModel.Instance.SelectedListItem.Position_List;
            datastring = ExcelDataCollection_ViewModel.Instance.SelectedListItem.Data_String;
            openAndGotoPosition();
        }

        private void openAndGotoPosition()
        {
            try
            {
                string dir = "";
                RegistryKey key = Registry.LocalMachine;
                RegistryKey excelKey = key.OpenSubKey(@"SOFTWARE\MicroSoft\Office");
                if (excelKey != null)
                {
                    foreach (string valuename in excelKey.GetSubKeyNames())
                    {
                        int version = 9;
                        double currentVersion = 0;
                        if (Double.TryParse(valuename, out currentVersion) && currentVersion >= version)
                        {
                            RegistryKey rootdir = excelKey.OpenSubKey(currentVersion + @".0\Excel\InstallRoot");
                            if (rootdir != null)
                            {
                                dir = rootdir.GetValue(rootdir.GetValueNames()[0]).ToString();
                                break;
                            }
                        }
                    }
                }
                if (dir != "")
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();

                    startInfo.FileName = dir + @"Excel.exe";
                    startInfo.Arguments = "\"" + filename + "\"";
                    startInfo.UseShellExecute = false;
                   
                    using (Process process = new Process())
                    {
                        process.StartInfo = startInfo;
                        try
                        {
                            process.Start();
                           // Navigatetocell();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("\n\nCould not start Excel process.");
                            Console.WriteLine(ex);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Can't Open in excel because excel is not installed.");
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void Navigatetocell()
        {

            //Excel.Application xlApp;
            //Excel.Workbook xlWorkBook;
            //Excel.Worksheet xlWorkSheet;
            //object misValue = System.Reflection.Missing.Value;

            //xlApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            ////xlApp = new Excel.Application();
            //xlWorkBook = xlApp.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            ////MessageBox.Show(xlWorkSheet.get_Range("A1", "A1").Value2.ToString());
            //xlWorkSheet.get_Range("A1", "A1").Select();
            //xlWorkSheet.Cells.Select();
            //xlWorkBook.Close(true, misValue, misValue);


           //Excel.Application app = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
           //Excel.Worksheet Worksheet = app.ThisWorkbook.ActiveSheet;
           ////Worksheet.get_Range("linenumber", "columnnumber").Select();
        
           //Excel.Range currentRange = (Excel.Range)Worksheet.Cells[linenumber, columnnumber];
           //string columnLetter = currentRange.get_AddressLocal(true, false, Excel.XlReferenceStyle.xlA1, System.Type.Missing, System.Type.Missing).Split('$')[0];
           //string title = null;
           //if (currentRange.Value2 != null)
           //{
           //    title = currentRange.Value2.ToString();
           //}
            
        }
    }
}

