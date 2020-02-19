using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringFinder
{
    class CheckCaseSelection
    {
        private static bool _isIgnoreCaseSelected;
        public static bool IgnoreCaseSelected
        {

            get
            {
                return _isIgnoreCaseSelected;
            }
            set
            {
                _isIgnoreCaseSelected = value;

            }
        }

        private static bool _isMatchEntireCellContentSelected;
        public static bool MatchEntireCellContentSelected
        {
            get
            {
                return _isMatchEntireCellContentSelected;
            }
            set
            {
                _isMatchEntireCellContentSelected = value;

            }
        }
    }
}
