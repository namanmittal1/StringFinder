using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using BitMiracle.Docotic.Pdf;

namespace StringFinder
{
    class OpenPDFFile
    {
        String filename;
        int X;
        int Y;
        String datastring;

        public void getValues()
        {
            filename = PDFDataCollection_VidewModel.Instance.SelectedListItem.FilenameList;
            X = PDFDataCollection_VidewModel.Instance.SelectedListItem.Linenumber_List;
            Y = PDFDataCollection_VidewModel.Instance.SelectedListItem.Position_List;
            datastring = PDFDataCollection_VidewModel.Instance.SelectedListItem.Data_String;
            openAndGotoPosition();
        }

        private void openAndGotoPosition()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            process.StartInfo = startInfo;
            startInfo.FileName = filename;
            process.Start();            
        }
    }
}
