using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringFinder
{
    public class ProgressEventArgs : EventArgs
    {

        private float _progressPercentage;

        public float ProgressPercentage
        {
            get
            {
                return _progressPercentage;
            }
            set
            {
                _progressPercentage = value;
            }
        }

        public ProgressEventArgs(float Percentage)
        {
            ProgressPercentage = Percentage;
        }
    }
}
