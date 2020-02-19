using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace StringFinder
{

    class TextDataCollection_ViewModel :INotifyPropertyChanged
    {
        OpenTextFile otf = new OpenTextFile();

        private static TextDataCollection_ViewModel _instance;

        public static TextDataCollection_ViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TextDataCollection_ViewModel();
                }
                return _instance;
            }
         
        }

        private TextDataCollection_ViewModel()
        {
           TestData = new ObservableCollection<TextFileData>();
        }


        public  ObservableCollection<TextFileData> TestData { get; set; }
            
        private TextFileData CurrentItem;
        public TextFileData SelectedListItem
        {
            get
            {
                return CurrentItem;
            }

            set
            {
                if (value != CurrentItem && value!=null)
                {
                    CurrentItem = value;
                    otf.getValues();
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
