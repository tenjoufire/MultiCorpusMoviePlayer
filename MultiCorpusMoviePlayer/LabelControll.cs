using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinectWPF;

namespace MultiCorpusMoviePlayer
{
    class LabelControll
    {
        private string fileName;
        private string enableLabelName;
        private string disableLabelName;
        private TimeLineLabel TimeLineLabel;

        public LabelControll(string filename, string enable, string disable)
        {
            fileName = filename;
            enableLabelName = enable;
            disableLabelName = disable;
            TimeLineLabel = new TimeLineLabel();
        }
    }
}
