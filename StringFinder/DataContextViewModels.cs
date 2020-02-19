using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringFinder
{
    class DataContextViewModels
    {
        public TextDataCollection_ViewModel TextInstance
        {
            get
            {
                    return TextDataCollection_ViewModel.Instance;
                
            }

        }

        public ExcelDataCollection_ViewModel ExcelInstance
        {
            get
            {
                return ExcelDataCollection_ViewModel.Instance;

            }
        }

        public PDFDataCollection_VidewModel PDFInstance
        {
            get
            {
                return PDFDataCollection_VidewModel.Instance;

            }
        }

        public WordDataCollection_VidewModel WordInstance
        {
            get
            {
                return WordDataCollection_VidewModel.Instance;

            }
        }

        public XMLDataCollection_ViewModel XMLInstance
        {
            get
            {
                return XMLDataCollection_ViewModel.Instance;

            }

        }
    }
}
