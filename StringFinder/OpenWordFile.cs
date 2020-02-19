using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Runtime.InteropServices;

namespace StringFinder
{
    class OpenWordFile
    {
        static String filename;
        static int para;
        static int pagenumber;
        static String datastring;
        public static List<String> files = new List<string>();
        static Word.Application word = null;
        static Word.Document doc = null;
        static Dictionary<Word.Application, Word.Document> dictionary = new Dictionary<Word.Application, Word.Document>();

        public static void getValues()
        {
            filename = WordDataCollection_VidewModel.Instance.SelectedListItem.FilenameList;
            para = WordDataCollection_VidewModel.Instance.SelectedListItem.Para_Num;
            pagenumber = WordDataCollection_VidewModel.Instance.SelectedListItem.Page_Number;
            datastring = WordDataCollection_VidewModel.Instance.SelectedListItem.Data_String;

            openAndGotoPosition();
        }

        private static void openAndGotoPosition()
        {
            try
            {

                System.Diagnostics.Process[] Procs = System.Diagnostics.Process.GetProcessesByName("winword");
                if (Procs.Length == 0)
                {
                    files.Clear();
                    dictionary.Clear();
                }

                if (Procs.Length != 0)
                {
                    int i = 0;
                    foreach (System.Diagnostics.Process Process in Procs)
                    {
                        String onlyfilename = filename.Substring(filename.LastIndexOf("\\") + 1);
                        String filenamewoext = onlyfilename.Substring(0, onlyfilename.LastIndexOf("."));
                        String fileTitle = Process.MainWindowTitle.ToString().Substring(0, Process.MainWindowTitle.ToString().IndexOf(" ["));
                        if (fileTitle.Equals(filenamewoext))
                        {
                            goto Label;
                        }
                        else
                        {
                            i = i + 1;
                            continue;
                        }
                    }
                    if (i == Procs.Length)
                    {
                        if (files.Contains(filename))
                        {
                            int index = files.IndexOf(filename);
                            files.RemoveAt(index);
                        }
                        if (dictionary.Count != 0)
                        {
                            foreach (KeyValuePair<Word.Application, Word.Document> pair in dictionary)
                            {
                                try
                                {
                                    String objname = pair.Key.ActiveWindow.Caption.ToString().Substring(0, pair.Key.ActiveWindow.Caption.ToString().IndexOf(" ["));
                                }
                                catch (COMException ce)
                                {
                                    dictionary.Remove(pair.Key);
                                    goto Label;                                        
                                }
                            }
                        }
                    }
                }

         Label: object fileName = filename;
                object missing = System.Type.Missing;

                if (!files.Contains(filename))
                {
                    word = new Word.Application();
                    doc = new Word.Document();
                    doc = word.Documents.Open(ref fileName, ref missing, true,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);
                    dictionary.Add(word, doc);
                    files.Add(filename);                    
                }
                foreach (KeyValuePair<Word.Application, Word.Document> pair in dictionary)
                {
                    String onlyfilename = filename.Substring(filename.LastIndexOf("\\") + 1);
                    String filenamewoext = onlyfilename.Substring(0, onlyfilename.LastIndexOf("."));
                    try
                    {
                        String objname = pair.Key.ActiveWindow.Caption.ToString().Substring(0, pair.Key.ActiveWindow.Caption.ToString().IndexOf(" ["));
                        if (String.Equals(objname, filenamewoext))
                        {
                            pair.Value.Activate();
                            foreach (Word.Window window in pair.Key.Windows)
                            {
                                window.WindowState = Word.WdWindowState.wdWindowStateMinimize;
                                window.WindowState = Word.WdWindowState.wdWindowStateMaximize;
                            }
                            Microsoft.Office.Interop.Word.Range r = pair.Value.Paragraphs[para].Range;
                            object dir = Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseStart;
                            r.Collapse(ref dir);
                            r.Select();
                        }
                    }
                    catch (COMException ce)
                    {
                        continue;
                    }
                }
            }
            catch (Exception e)
            {
            }
        }

    }
}
