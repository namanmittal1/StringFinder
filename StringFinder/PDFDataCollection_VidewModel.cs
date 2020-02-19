using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace StringFinder
{
    class PDFDataCollection_VidewModel :INotifyPropertyChanged
    {
       
        OpenPDFFile opf = new OpenPDFFile();

        private static PDFDataCollection_VidewModel _instance;

        public static PDFDataCollection_VidewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PDFDataCollection_VidewModel();
                }
                return _instance;
            }

        }

        private PDFDataCollection_VidewModel()
        {
            PDFData = new ObservableCollection<PDFFileData>();
        }


        public ObservableCollection<PDFFileData> PDFData { get; set; }


        private PDFFileData CurrentItem;
        public PDFFileData SelectedListItem
        {
            get
            {
                return CurrentItem;
            }

            set
            {
                if (value != CurrentItem && value != null)
                {
                    CurrentItem = value;
                    opf.getValues();
                }
            }

        }

        private String _searchCount;
        public String SearchCount
        {
            get
            {
                return _searchCount;
            }
            set
            {
                _searchCount = value;
                OnPropertyChanged("SearchCount");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
