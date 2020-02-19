using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace StringFinder
{
    class XMLDataCollection_ViewModel
    {
        OpenXmlFile oxf = new OpenXmlFile();

        private static XMLDataCollection_ViewModel _instance;

        public static XMLDataCollection_ViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new XMLDataCollection_ViewModel();
                }
                return _instance;
            }
         
        }

        private XMLDataCollection_ViewModel()
        {
            XMLData = new ObservableCollection<XMLFileData>();
        }


        public ObservableCollection<XMLFileData> XMLData { get; set; }

        private XMLFileData CurrentItem;
        public XMLFileData SelectedListItem
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
                    oxf.getValues();
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
