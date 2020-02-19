using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace StringFinder
{

    class ExcelDataCollection_ViewModel :INotifyPropertyChanged
    {
        OpenExcelFile oef = new OpenExcelFile();

        private static ExcelDataCollection_ViewModel _instance;

        public static ExcelDataCollection_ViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ExcelDataCollection_ViewModel();
                }
                return _instance;
            }

        }

        private ExcelDataCollection_ViewModel()
        {
            ExcelData = new ObservableCollection<ExcelFileData>();
        }


        public ObservableCollection<ExcelFileData> ExcelData { get; set; }


        private ExcelFileData CurrentItem;
        public ExcelFileData SelectedListItem
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
                    oef.getValues();
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
