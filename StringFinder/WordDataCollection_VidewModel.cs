using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace StringFinder
{
    class WordDataCollection_VidewModel :INotifyPropertyChanged
    {
       // OpenWordFile owf = new OpenWordFile();

        private static WordDataCollection_VidewModel _instance;

        public static WordDataCollection_VidewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WordDataCollection_VidewModel();
                }
                return _instance;
            }

        }

        private WordDataCollection_VidewModel()
        {
            WordData = new ObservableCollection<WordFileData>();
        }


        public ObservableCollection<WordFileData> WordData { get; set; }


        private WordFileData CurrentItem;
        public WordFileData SelectedListItem
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
                    OpenWordFile.getValues();
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
