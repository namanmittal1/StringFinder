using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace StringFinder
{
    class SearchDistributor
    {
        public delegate void progressBarUpdater(Object sender,ProgressEventArgs ar);
        public event progressBarUpdater statechanged;
        public int counter = 0;
        SearchInTextFile stf=new SearchInTextFile();
        SearchInExcel se = new SearchInExcel();
        SearchInPDF sp = new SearchInPDF();
        SearchInWord sw = new SearchInWord();
        SearchInXmlFile sx = new SearchInXmlFile();

        private void OnStateChanged(float Percentage)
        {
            if (statechanged != null)
            {
                statechanged(null, new ProgressEventArgs(Percentage));
            }
        }

        private string _searchString;
        public string SearchString
        {
            get
            {
                return _searchString;
            }
            set
            {
                _searchString = value;
            }
        }

        public void searchFile(string folderName, float totalFiles)
        {
                    DirectoryInfo dinfo = new DirectoryInfo(folderName);
                    string[] ext = { ".txt", ".doc", ".docx", ".xls", ".xlsx", ".pdf",".xml" };
                    IEnumerable<FileInfo> files = GetFiles.GetFilesByExtensions(dinfo, ext);
            
                    if (files.Count() != 0)
                    {
                        Parallel.ForEach(files, currentFile =>
                        {
                            Interlocked.Increment(ref counter);
                            startSearching(currentFile);
                            OnStateChanged((counter / totalFiles) * 100);
                            Thread.Sleep(20);
                        }
                            );
                    }

                    files = null;
                    dinfo = null;

                    string[] folders = Directory.GetDirectories(folderName);
                    if (folders.Length != 0)
                    {
                        foreach (string folder in folders)
                        {
                            folderName = folder;
                            searchFile(folderName, totalFiles);
                        }
                    }


                    TextDataCollection_ViewModel.Instance.SearchCount = "("+ TextDataCollection_ViewModel.Instance.TestData.Count.ToString() + ")";
                    ExcelDataCollection_ViewModel.Instance.SearchCount = "(" + ExcelDataCollection_ViewModel.Instance.ExcelData.Count.ToString() + ")";
                    PDFDataCollection_VidewModel.Instance.SearchCount = "(" + PDFDataCollection_VidewModel.Instance.PDFData.Count.ToString() + ")";
                    WordDataCollection_VidewModel.Instance.SearchCount = "(" + WordDataCollection_VidewModel.Instance.WordData.Count.ToString() + ")";
                    XMLDataCollection_ViewModel.Instance.SearchCount = "(" + XMLDataCollection_ViewModel.Instance.XMLData.Count.ToString() + ")";

                    ComObjectsHandler.ReleaseComObjects();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect(); 
        }
        

        private void startSearching(FileInfo file)
        {
            switch (file.Extension)
            {
                case ".txt": stf.ProcessTextFile(file.FullName, SearchString);
                    break;
                case ".doc":
                    if (file.FullName.Contains("~$"))
                        break;
                    sw.ProcessWordFile(file.FullName, SearchString);
                    break;
                case ".docx":
                    if (file.FullName.Contains("~$"))
                        break;
                    sw.ProcessWordFile(file.FullName, SearchString);
                    break;
                case ".xls":
                    if (file.FullName.Contains("~$"))
                        break;
                    se.ProcessExcelFile(file.FullName, SearchString);
                    break;
                case ".xlsx":
                    if (file.FullName.Contains("~$"))
                        break;
                    se.ProcessExcelFile(file.FullName, SearchString);
                    break;
                case ".pdf": sp.ProcessPDFFile(file.FullName, SearchString);
                    break;
                case ".xml": sx.ProcessXMLFile(file.FullName, SearchString);
                    break;
                default: break;
            }    
 
        }


    }
}
