using System;
using msExcel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace StringFinder
{
    class SearchInExcel
    {

        public void ProcessExcelFile(String filename,String searchstring)
        {
            LoadExcel le = new LoadExcel();
            le.openExcel(filename);
            msExcel.Range firstFind = null;
            int numofSheets = le.xlWorkbook.Worksheets.Count;
            for (int sheetnum = 1; sheetnum <= numofSheets; sheetnum++)
            {
                le.xlWorksheet = (msExcel._Worksheet)le.xlWorkbook.Sheets[sheetnum];
                le.xlRange = le.xlWorksheet.UsedRange;

                ComObjectsHandler.xlWorkSheet.Add(le.xlWorksheet);
                ComObjectsHandler.xlWorkRange.Add(le.xlRange);

                if (CheckCaseSelection.MatchEntireCellContentSelected && !CheckCaseSelection.IgnoreCaseSelected)
                {
                    MatchEntireFind(searchstring, firstFind, filename, le.xlRange);
                }
                else if (CheckCaseSelection.IgnoreCaseSelected && !CheckCaseSelection.MatchEntireCellContentSelected)
                {
                    IgnoreCaseFind(searchstring, firstFind, filename, le.xlRange);
                }
                else if (CheckCaseSelection.IgnoreCaseSelected && CheckCaseSelection.MatchEntireCellContentSelected)
                {
                    IgnoreandMatchEntireFind(searchstring, firstFind, filename, le.xlRange);
                }
                else
                {
                    IgnoreandMatchEntireFind(searchstring, firstFind, filename, le.xlRange);
                }
            }
            le.xlWorkbook.Close();
            le.xlApp.Quit();
        }

        
        private void IgnoreCaseFind(String searchstring, msExcel.Range firstFind,String filename,msExcel.Range range)
        {
            msExcel.Range currentFind = range.Find(searchstring, System.Reflection.Missing.Value, msExcel.XlFindLookIn.xlValues, msExcel.XlLookAt.xlPart, msExcel.XlSearchOrder.xlByRows, msExcel.XlSearchDirection.xlNext, false, true, System.Reflection.Missing.Value);
            while (currentFind != null)
            {
                if (firstFind == null)
                {
                    firstFind = currentFind;
                }
                else if (currentFind.get_Address(msExcel.XlReferenceStyle.xlA1) == firstFind.get_Address(msExcel.XlReferenceStyle.xlA1))
                {
                    break;
                }

                //currentFind.Font.Bold = true;
                ExcelFileData efd = new ExcelFileData();
                efd.Position_List = currentFind.Column;
                efd.Linenumber_List = currentFind.Row;
                efd.FilenameList = filename;
                efd.Data_String = currentFind.Text;
                System.Windows.Application.Current.Dispatcher.Invoke((Action)(() =>
                {
                    ExcelDataCollection_ViewModel.Instance.ExcelData.Add(efd);
                }));
                currentFind = range.FindNext(currentFind);
            }
        }

        private void MatchEntireFind(String searchstring, msExcel.Range firstFind, String filename, msExcel.Range range)
        {
            msExcel.Range currentFind = range.Find(searchstring, System.Reflection.Missing.Value, msExcel.XlFindLookIn.xlValues, msExcel.XlLookAt.xlWhole, msExcel.XlSearchOrder.xlByRows, msExcel.XlSearchDirection.xlNext, true, true, System.Reflection.Missing.Value);
            while (currentFind != null)
            {
                if (firstFind == null)
                {
                    firstFind = currentFind;
                }
                else if (currentFind.get_Address(msExcel.XlReferenceStyle.xlA1) == firstFind.get_Address(msExcel.XlReferenceStyle.xlA1))
                {
                    break;
                }
                //currentFind.Font.Bold = true;
                ExcelFileData efd = new ExcelFileData();
                efd.Position_List = currentFind.Column;
                efd.Linenumber_List = currentFind.Row;
                efd.FilenameList = filename;
                efd.Data_String = searchstring;
                System.Windows.Application.Current.Dispatcher.Invoke((Action)(() =>
                {
                    ExcelDataCollection_ViewModel.Instance.ExcelData.Add(efd);
                }));
                currentFind = range.FindNext(currentFind);
            }
        }

        private void IgnoreandMatchEntireFind(String searchstring, msExcel.Range firstFind, String filename, msExcel.Range range)
        {
            msExcel.Range currentFind = range.Find(searchstring, System.Reflection.Missing.Value, msExcel.XlFindLookIn.xlValues, msExcel.XlLookAt.xlWhole, msExcel.XlSearchOrder.xlByRows, msExcel.XlSearchDirection.xlNext, false, true, System.Reflection.Missing.Value);
            while (currentFind != null)
            {
                if (firstFind == null)
                {
                    firstFind = currentFind;
                }
                else if (currentFind.get_Address(msExcel.XlReferenceStyle.xlA1) == firstFind.get_Address(msExcel.XlReferenceStyle.xlA1))
                {
                    break;
                }
                //currentFind.Font.Bold = true;
                ExcelFileData efd = new ExcelFileData();
                efd.Position_List = currentFind.Column;
                efd.Linenumber_List = currentFind.Row;
                efd.FilenameList = filename;
                efd.Data_String = currentFind.Text;
                System.Windows.Application.Current.Dispatcher.Invoke((Action)(() =>
                {
                    ExcelDataCollection_ViewModel.Instance.ExcelData.Add(efd);
                }));
                currentFind = range.FindNext(currentFind);
            }
        }
        
    }
    
    public  class LoadExcel
    {
        public  msExcel.Application xlApp;
        public  msExcel.Workbook xlWorkbook;
        public  msExcel._Worksheet xlWorksheet;
        public  msExcel.Range xlRange;

        /// <summary>
        /// Loads Excel File
        /// </summary>
        /// <param name="filename"></param>
        public  void openExcel(String filename)
        {
            try
            {
                xlApp = new msExcel.Application();
                xlWorkbook = xlApp.Workbooks.Open(filename);
                ComObjectsHandler.xlApp.Add(xlApp);
                ComObjectsHandler.xlWorkBook.Add(xlWorkbook);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Close Excel files
        /// </summary>
        /// <param name="excelFileName"></param>
        public void closeExcel(string excelFileName)
        {
            try
            {
                    xlWorkbook.Close(Type.Missing, Type.Missing, Type.Missing);
                    xlApp.Quit();
            }
            catch (Exception e)
            {

                throw;
            }
        }

      
    }
}

