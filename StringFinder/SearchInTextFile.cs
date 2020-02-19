using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace StringFinder
{
    class SearchInTextFile
    {
        int modeSelected = 0;
        StringComparison searchMode;

        public void ProcessTextFile(string filename, String text)
        {
            try
            {

                int linenumber = 0;
                using (FileStream fs = File.Open(filename, FileMode.Open))
                using (BufferedStream bs = new BufferedStream(fs))
                using (StreamReader sr = new StreamReader(bs))
                {
                    string s = String.Empty;
                    while ((s = sr.ReadLine()) != null)
                    {
                        linenumber++;
                        searchString(s, text, filename, linenumber);
                    }
                    sr.Close();
                    bs.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {

            }

        }

        private Regex getRegex_Option(String text)
        {
            Regex rx = null;

            if (CheckCaseSelection.IgnoreCaseSelected)
            {
                rx = new Regex(text, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                modeSelected = 1;
                searchMode = StringComparison.InvariantCultureIgnoreCase;
            }
            if (CheckCaseSelection.MatchEntireCellContentSelected)
            {
                rx = new Regex(text, RegexOptions.None | RegexOptions.CultureInvariant);
                modeSelected = 2;
            }
            if (CheckCaseSelection.IgnoreCaseSelected && CheckCaseSelection.MatchEntireCellContentSelected)
            {
                rx = new Regex(text, RegexOptions.IgnoreCase | RegexOptions.None | RegexOptions.CultureInvariant);
                modeSelected = 3;
                searchMode = StringComparison.InvariantCultureIgnoreCase;
            }
            if (!CheckCaseSelection.IgnoreCaseSelected && !CheckCaseSelection.MatchEntireCellContentSelected)
            {
                rx = new Regex(text, RegexOptions.IgnoreCase | RegexOptions.None | RegexOptions.CultureInvariant);
                modeSelected = 3;
                searchMode = StringComparison.InvariantCultureIgnoreCase;
            }

            return rx;
        }

        private void searchString(String line, String text, string filename, int linenumber)
        {
            try
            {
                Regex rx = null;
                rx = getRegex_Option(text);

                if (rx.IsMatch(line))
                {
                    Regex r = new Regex(" +");
                    string[] words = r.Split(line);
                    switch (modeSelected)
                    {
                        case 1: searchAsMode1(words, text, filename, linenumber, rx, line);
                            break;
                        case 2: searchAsMode2(words, text, filename, linenumber, rx, line);
                            break;
                        case 3: searchAsMode3(words, text, filename, linenumber, rx, line, searchMode);
                            break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void searchAsMode1(String[] words, string text, string filename, int linenumber, Regex rx, String line)
        {
            try
            {
                int incrementedval = 0;
                string targetString = null;
                foreach (string word in words)
                {

                    targetString = word;
                    var matches = rx.Matches(word);

                    if (matches.Count != 0)
                    {

                        foreach (Match nextmatch in matches)
                        {
                            TextFileData tfd = new TextFileData();
                            tfd.Position_List = stringPostion1(line, text, incrementedval, searchMode);
                            incrementedval++;
                            tfd.Linenumber_List = linenumber;
                            tfd.FilenameList = filename;
                            tfd.Data_String = targetString;
                            System.Windows.Application.Current.Dispatcher.Invoke((Action)(() =>
                            {
                                TextDataCollection_ViewModel.Instance.TestData.Add(tfd);
                            }));

                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void searchAsMode2(String[] words, string text, string filename, int linenumber, Regex rx, String line)
        {
            try
            {
                int incrementedval = 0;
                string targetString = null;
                foreach (string word in words)
                {
                    targetString = text;
                    string pattern = "^" + word + "$";
                    MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.None | RegexOptions.CultureInvariant);

                    if (matches.Count != 0)
                    {
                        foreach (Match nextmatch in matches)
                        {
                            TextFileData tfd = new TextFileData();
                            tfd.Position_List = stringPostion2(line, text, incrementedval);
                            incrementedval++;
                            tfd.Linenumber_List = linenumber;
                            tfd.FilenameList = filename;
                            tfd.Data_String = targetString;
                            System.Windows.Application.Current.Dispatcher.Invoke((Action)(() =>
                            {
                                TextDataCollection_ViewModel.Instance.TestData.Add(tfd);
                            }));

                        }

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void searchAsMode3(String[] words, string text, string filename, int linenumber, Regex rx, String line, StringComparison searchMode)
        {
            try
            {

                int incrementedval = 0;
                string targetString = null;
                foreach (string word in words)
                {
                    if (word.Equals(text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        targetString = word;

                        TextFileData tfd = new TextFileData();
                        tfd.Position_List = stringPostion3(line, text, incrementedval, searchMode);
                        incrementedval++;
                        tfd.Linenumber_List = linenumber;
                        tfd.FilenameList = filename;
                        tfd.Data_String = targetString;
                        System.Windows.Application.Current.Dispatcher.Invoke((Action)(() =>
                        {
                            TextDataCollection_ViewModel.Instance.TestData.Add(tfd);
                        }));

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        private int stringPostion1(string line, string text, int incrementedval, StringComparison searchMode)
        {
            try
            {
                List<int> foundIndexes = new List<int>();
                int foundIndex = 0;
                for (int i = line.IndexOf(text, searchMode); i > -1; i = line.IndexOf(text, i + 1, searchMode))
                {
                    foundIndexes.Add(i);
                }
                foundIndex = foundIndexes[incrementedval];

                return foundIndex;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private int stringPostion2(string line, string text, int incrementedval)
        {
            try
            {
                int foundIndex = 0;
                int index = 0;
                List<int> indexes = new List<int>();
                while (index < line.Length && index >= 0)
                {
                    index = line.IndexOf(text, index);
                    if (index + text.Length == line.Length || index >= 0 && !char.IsLetter(line[index + text.Length]))
                    {
                        indexes.Add(index);
                    }
                    if (index != -1)
                        index++;
                }
                foundIndex = indexes[incrementedval];
                return foundIndex;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private int stringPostion3(string line, string text, int incrementedval, StringComparison searchMode)
        {
            try
            {
                int foundIndex = 0;
                int index = 0;
                List<int> indexes = new List<int>();
                while (index < line.Length && index >= 0)
                {
                    index = line.IndexOf(text, index, searchMode);
                    if (index + text.Length == line.Length || index >= 0 && !char.IsLetter(line[index + text.Length]))
                    {
                        indexes.Add(index);
                    }
                    if (index != -1)
                        index++;
                }
                foundIndex = indexes[incrementedval];
                return foundIndex;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
