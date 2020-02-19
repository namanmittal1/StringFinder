using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace StringFinder
{
    class WordFileData : INotifyPropertyChanged
    {
        private int page_number;

        public int Page_Number
        {
            get { return page_number; }
            set
            {
                page_number = value;
                OnPropertyChanged("Page_Number");
            }
        }

        private int para_num;
        public int Para_Num
        {
            get { return para_num; }
            set
            {
                para_num = value;
                OnPropertyChanged("Para_Num");
            }
        }

        private string filenamelist;
        public string FilenameList
        {
            get
            {
                return filenamelist;
            }
            set
            {
                filenamelist = value;
                OnPropertyChanged("FilenameList");
            }
        }


        private string data_string;
        public string Data_String
        {
            get
            {
                return data_string;
            }
            set
            {
                data_string = value;
                OnPropertyChanged("Data_String");
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
