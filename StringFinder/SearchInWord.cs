using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;

namespace StringFinder
{
    class SearchInWord
    {       
        public void ProcessWordFile(string filename, string searchstring)
        {
            object fileName = filename;
            Word.Application word = new Word.Application();
            Word.Document doc = new Word.Document();
            object missing = System.Type.Missing;

            doc = word.Documents.Open(ref fileName, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing);

            ComObjectsHandler.word.Add(word);
            ComObjectsHandler.document.Add(doc);

            if (CheckCaseSelection.MatchEntireCellContentSelected && !CheckCaseSelection.IgnoreCaseSelected)
            {
                MatchEntireFind(searchstring, filename, doc);
            }
            else if (CheckCaseSelection.IgnoreCaseSelected && !CheckCaseSelection.MatchEntireCellContentSelected)
            {
                IgnoreCaseFind(searchstring, filename, doc);
            }
            else if (CheckCaseSelection.IgnoreCaseSelected && CheckCaseSelection.MatchEntireCellContentSelected)
            {
                IgnoreandMatchEntireFind(searchstring, filename, doc);
            }
            else
            {
                IgnoreandMatchEntireFind(searchstring, filename, doc);
            }
            ((_Document)doc).Close(missing, missing, missing);
            ((_Application)word).Quit(missing, missing, missing);
        }

        private void IgnoreandMatchEntireFind(string searchstring, string filename, Word.Document doc)
        {
            try
            {
                for (int i = 0; i < doc.Paragraphs.Count; i++)
                {
                    bool val = doc.Paragraphs[i + 1].Range.Find.Execute(searchstring, false, true, false, false, false, false, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    
                    if (val)
                    {                     
                        WordFileData wfd = new WordFileData();
                        wfd.Data_String = doc.Paragraphs[i + 1].Range.Text.Trim();
                        wfd.FilenameList = filename;
                        wfd.Para_Num = i + 1;
                        wfd.Page_Number = (int)doc.Paragraphs[i + 1].Range.get_Information(Word.WdInformation.wdActiveEndPageNumber);
                        System.Windows.Application.Current.Dispatcher.Invoke((Action)(() =>
                        {
                            WordDataCollection_VidewModel.Instance.WordData.Add(wfd);
                        }));
                    }
                }
            }

            catch (Exception ex)
            {
            }
        }

        private void IgnoreCaseFind(string searchstring, string filename, Word.Document doc)
        {            
            try
            {
                for (int i = 0; i < doc.Paragraphs.Count; i++)
                {
                    bool val = doc.Paragraphs[i + 1].Range.Find.Execute(searchstring, false, false, true, false, false, false, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    if(val)
                    {
                        WordFileData wfd = new WordFileData();
                        wfd.Data_String = doc.Paragraphs[i + 1].Range.Text.Trim();
                        wfd.FilenameList = filename;
                        wfd.Para_Num = i + 1;
                        wfd.Page_Number = (int)doc.Paragraphs[i + 1].Range.get_Information(Word.WdInformation.wdActiveEndPageNumber);
                        System.Windows.Application.Current.Dispatcher.Invoke((Action)(() =>
                       {
                           WordDataCollection_VidewModel.Instance.WordData.Add(wfd);
                       }));
                    }
                }
            }

            catch (Exception ex)
            {
            }
        }

        private void MatchEntireFind(string searchstring, string filename, Word.Document doc)
        {
            try
            {
                for (int i = 0; i < doc.Paragraphs.Count; i++)
                {
                    bool val = doc.Paragraphs[i + 1].Range.Find.Execute(searchstring, true, true, false, false, false, false, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    if (val)
                    {

                        WordFileData wfd = new WordFileData();
                        wfd.Data_String = searchstring;
                        wfd.FilenameList = filename;
                        wfd.Para_Num = i + 1;
                        wfd.Page_Number = (int)doc.Paragraphs[i + 1].Range.get_Information(Word.WdInformation.wdActiveEndPageNumber);
                        System.Windows.Application.Current.Dispatcher.Invoke((Action)(() =>
                        {
                            WordDataCollection_VidewModel.Instance.WordData.Add(wfd);
                        }));
                    }
                }
            }

            catch (Exception ex)
            {
            }
        }

    }
}
