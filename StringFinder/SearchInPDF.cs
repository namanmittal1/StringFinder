using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BitMiracle.Docotic.Pdf;
using System.Windows.Forms;

namespace StringFinder
{
    class SearchInPDF
    {
        public void ProcessPDFFile(String filename, String searchstring)
        {
            if (CheckCaseSelection.MatchEntireCellContentSelected && !CheckCaseSelection.IgnoreCaseSelected)
            {
                MatchEntireFind(searchstring, filename);
            }
            else if (CheckCaseSelection.IgnoreCaseSelected && !CheckCaseSelection.MatchEntireCellContentSelected)
            {
                IgnoreCaseFind(searchstring, filename);
            }
            else if (CheckCaseSelection.IgnoreCaseSelected && CheckCaseSelection.MatchEntireCellContentSelected)
            {
                IgnoreandMatchEntireFind(searchstring, filename);
            }
            else
            {
                IgnoreandMatchEntireFind(searchstring, filename);
            }
        }

        private void MatchEntireFind(String searchstring, string filename)
        {
            using (PdfDocument pdf = new PdfDocument(filename))
            {
                for (int i = 0; i < pdf.Pages.Count; i++)
                {
                    PdfPage page = pdf.Pages[i];
                    foreach (PdfTextData data in page.GetWords())
                    {
                        int index = -1;
                        if (data.Text.Equals(searchstring))
                        {
                            index = data.Text.IndexOf(data.Text, 0);
                        }
                        else
                        {
                            index = -1;
                        }
                        if (index > -1)
                        {
                            PdfPoint pp = new PdfPoint();
                            pp = data.Position;
                            PDFFileData pfd = new PDFFileData();
                            pfd.Linenumber_List = (int)pp.X;
                            pfd.Position_List = (int)pp.Y;
                            pfd.FilenameList = filename;
                            pfd.Data_String = data.Text;
                            System.Windows.Application.Current.Dispatcher.Invoke((Action)(() =>
                            {
                                PDFDataCollection_VidewModel.Instance.PDFData.Add(pfd);
                            }));
                        }
                    }
                }
            }
        }

        private void IgnoreCaseFind(String searchstring, string filename)
        {
            using (PdfDocument pdf = new PdfDocument(filename))
            {
                for (int i = 0; i < pdf.Pages.Count; i++)
                {
                    PdfPage page = pdf.Pages[i];
                    foreach (PdfTextData data in page.GetWords())
                    {
                        int index = data.Text.IndexOf(searchstring, 0, StringComparison.InvariantCultureIgnoreCase);
                        if (index > -1)
                        {
                            PdfPoint pp = new PdfPoint();
                            pp = data.Position;
                            PDFFileData pfd = new PDFFileData();
                            pfd.Linenumber_List = (int)pp.X;
                            pfd.Position_List = (int)pp.Y;
                            pfd.FilenameList = filename;
                            pfd.Data_String = data.Text;
                            System.Windows.Application.Current.Dispatcher.Invoke((Action)(() =>
                            {
                                PDFDataCollection_VidewModel.Instance.PDFData.Add(pfd);
                            }));
                        }
                    }
                }
            }
        }

        private void IgnoreandMatchEntireFind(String searchstring, string filename)
        {
            using (PdfDocument pdf = new PdfDocument(filename))
            {
                for (int i = 0; i < pdf.Pages.Count; i++)
                {
                    PdfPage page = pdf.Pages[i];
                    foreach (PdfTextData data in page.GetWords())
                    {
                        int index = -1;
                        if(data.Text.Equals(searchstring,StringComparison.InvariantCultureIgnoreCase))
                        {
                            index = data.Text.IndexOf(data.Text, 0);
                        }
                        else
                        {
                            index = -1;
                        }
                        
                        if (index > -1)
                        {
                            PdfPoint pp = new PdfPoint();
                            pp = data.Position;
                            PDFFileData pfd = new PDFFileData();
                            pfd.Linenumber_List = (int)pp.X;
                            pfd.Position_List = (int)pp.Y;
                            pfd.FilenameList = filename;
                            pfd.Data_String = data.Text;
                            System.Windows.Application.Current.Dispatcher.Invoke((Action)(() =>
                            {
                                PDFDataCollection_VidewModel.Instance.PDFData.Add(pfd);
                            }));
                        }
                    }
                }
            }
        }

    }
}
