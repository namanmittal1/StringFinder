using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace StringFinder
{
    class OpenTextFile
    {
        String filename;
        int linenumber;
        int columnnumber;
        String datastring;
    
        public void getValues()
        {
            filename = TextDataCollection_ViewModel.Instance.SelectedListItem.FilenameList;
            linenumber = TextDataCollection_ViewModel.Instance.SelectedListItem.Linenumber_List;
            columnnumber = TextDataCollection_ViewModel.Instance.SelectedListItem.Position_List;
            datastring = TextDataCollection_ViewModel.Instance.SelectedListItem.Data_String;
            openAndGotoPosition();
        }

        private void openAndGotoPosition()
        {
            try
            {

                var nDir = (string)Registry.GetValue("HKEY_CLASSES_ROOT\\*\\OpenWithList\\notepad.exe", null, null);
                var nppDir = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Notepad++", null, null);

                var sb = new StringBuilder();

                if (nppDir!=null)
                {
                    var nppExePath = Path.Combine(nppDir, "Notepad++.exe");
                    var nppReadmePath = Path.Combine(nppDir, filename);
                    sb.AppendFormat("\"{0}\" -n{1} -c{2}", nppReadmePath, linenumber, columnnumber + 1);
                    Process.Start(nppExePath, sb.ToString());
                }
                else
                {
                    var nExePath = Path.Combine(nDir, "notepad.exe");
                    var nReadmePath = Path.Combine(nDir, filename);
                    sb.AppendFormat("\"{0}\" -n{1}", nReadmePath, linenumber);
                    Process.Start(nExePath, sb.ToString());
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
