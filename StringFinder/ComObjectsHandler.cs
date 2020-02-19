using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace StringFinder
{
    public static class ComObjectsHandler
    {
        
        public static List<Object> xlApp = new List<object>();
        public static List<Object> xlWorkBook = new List<object>();
        public static List<Object> xlWorkSheet = new List<object>();
        public static List<Object> xlWorkRange = new List<object>();
        public static List<Object> word = new List<object>();
        public static List<Object> document = new List<object>();

        public static void ReleaseComObjects()
        {
            if (xlWorkRange.Count != 0)
            {
                foreach (object comobj in xlWorkRange)
                {
                    Marshal.ReleaseComObject(comobj);                    
                }
                xlWorkRange.Clear();
            }
            if (xlWorkSheet.Count != 0)
            {
                foreach (object comobj in xlWorkSheet)
                {
                    Marshal.ReleaseComObject(comobj);                   
                }
                xlWorkSheet.Clear();
            }
            if (xlWorkBook.Count != 0)
            {
                foreach (object comobj in xlWorkBook)
                {
                    Marshal.ReleaseComObject(comobj);                    
                }
                xlWorkBook.Clear();
            }
            if (xlApp.Count != 0)
            {
                foreach (object comobj in xlApp)
                {
                    Marshal.ReleaseComObject(comobj);                    
                }
                xlApp.Clear();
            }
            if (document.Count != 0)
            {
                foreach (object comobj in document)
                {
                    Marshal.ReleaseComObject(comobj);
                }
                document.Clear();
            }
            if (word.Count != 0)
            {
                //foreach (object comobj in word)
                //{
                //    Marshal.ReleaseComObject(comobj);
                //}
                word.Clear();
            }
        }

    }
}
