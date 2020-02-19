using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace StringFinder
{
    
    public class TextFileData : INotifyPropertyChanged
    {
        private int position_list;

        public int Position_List
        {
            get { return position_list; }
            set
            {
                position_list = value;
                OnPropertyChanged("Position_List");
            }
        }

        private int linenumber_list;
        public int Linenumber_List
        {
            get { return linenumber_list; }
            set
            {
                linenumber_list = value;
                OnPropertyChanged("Linenumber_List");
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
