using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Windows;
using System.Threading;
using System.Windows.Forms;

namespace StringFinder
{
    class ViewModel : INotifyPropertyChanged, IDataErrorInfo
    {

        List<FileInfo> fileName_List = new List<FileInfo>();
        SearchDistributor sd=new SearchDistributor();

        public ViewModel()
        {
            BrowseCommand = new RelayCommand(Execute);
            SearchCommand = new RelayCommand(Execute_Search);
        }

        public ICommand BrowseCommand
        {
            get;
            set;
        }


        public ICommand SearchCommand
        {
            get;
            set;
        }

        private ICommand checkCommand;
        public ICommand CheckCommand
        {
            get
            {
             
                return checkCommand;
            }
            set
            {
                checkCommand = value;
                OnPropertyChanged("CheckCommand");
            }
        }

        private string folderName;
        public string FolderName
        {
            get
            {
                return folderName;
            }
            set
            {
                folderName = value;
                OnPropertyChanged("FolderName");
            }
        }


        private string searchString;
        public string SearchString
        {
            get
            {
                return searchString;
            }
            set
            {
                    searchString = value;
                    sd.SearchString = searchString;
                    OnPropertyChanged("SearchString");
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

        private bool _isIgnoreCaseSelected;
        public bool IgnoreCaseSelected
        {
            get
            {
                return _isIgnoreCaseSelected;
            }
            set
            {
                _isIgnoreCaseSelected = value;
                CheckCaseSelection.IgnoreCaseSelected = _isIgnoreCaseSelected;
            }
        }

        private bool _isMatchEntireCellContentSelected;
        public bool MatchEntireCellContentSelected
        {
            get
            {
                return _isMatchEntireCellContentSelected;
            }
            set
            {
                _isMatchEntireCellContentSelected = value;
                CheckCaseSelection.MatchEntireCellContentSelected = _isMatchEntireCellContentSelected;
            }
        }

        public void Execute()
        {

            FolderBrowserDialog dlg = new FolderBrowserDialog();
            DialogResult result = dlg.ShowDialog();
            List<string> fileNames = new List<string>();

            if (result == DialogResult.OK)
            {
                FolderName = dlg.SelectedPath;
            }
            
        }


        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                switch (columnName)
                {
                    case "SearchString": if (string.IsNullOrEmpty(SearchString)) result = " "; break;
                    case "FolderName": if (string.IsNullOrEmpty(FolderName)) result = " "; break;
                };
                return result;
            }
        }

        public void Execute_Search()
        {
            TextDataCollection_ViewModel.Instance.TestData.Clear();
            ExcelDataCollection_ViewModel.Instance.ExcelData.Clear();
            PDFDataCollection_VidewModel.Instance.PDFData.Clear();
            WordDataCollection_VidewModel.Instance.WordData.Clear();
            XMLDataCollection_ViewModel.Instance.XMLData.Clear();

            if (FolderName != null)
            {
                if (SearchString!=null)
                {
                    if (!SearchString.Equals(""))
                    {
                        DirectoryInfo dinfo = new DirectoryInfo(FolderName);

                        string[] ext = {".txt", ".doc", ".docx", ".xls", ".xlsx", ".pdf", ".xml"};
                        IEnumerable<FileInfo> allfiles = GetFiles.GetFilesByExtensions(dinfo, ext);           
                        float totalFiles = allfiles.Count();

                        sd.statechanged -= new SearchDistributor.progressBarUpdater(OnRecievingEvent);
                        sd.statechanged += new SearchDistributor.progressBarUpdater(OnRecievingEvent);

                        Task.Factory.StartNew(() =>
                            {
                                sd.searchFile(FolderName, totalFiles);
                                sd.counter = 0;
                            }).ContinueWith((a) =>
                                {
                                    CallBack(null);
                                });
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Enter the string to be searched.", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }

            }
                
            else
            {
                System.Windows.MessageBox.Show("First select the folder.", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        public void CallBack(IAsyncResult ar)
        {
            System.Windows.Application.Current.Dispatcher.Invoke((Action)(() =>
                {
                    DataViewer dw = new DataViewer();
                    dw.Show();
                }));

            CurrentProgress = 0;
            new ProgressEventArgs(0);
            sd.statechanged -= new SearchDistributor.progressBarUpdater(OnRecievingEvent);
        }

        public void OnRecievingEvent(Object sender,ProgressEventArgs ar)
        {
            CurrentProgress = ar.ProgressPercentage;
        }

        private float currentProgress;
        public float CurrentProgress
        {
            get
            {
                return currentProgress;
            }
            set
            {
                currentProgress = value;
                OnPropertyChanged("CurrentProgress");
            }
        }
    
    }

    public static class GetFiles
    {
        public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo dir, params string[] extensions)
        {
            if (extensions == null)
                throw new ArgumentNullException("extensions");
            IEnumerable<FileInfo> files = dir.EnumerateFiles();
            return files.Where(f => extensions.Contains(f.Extension));
        }
    }

}
