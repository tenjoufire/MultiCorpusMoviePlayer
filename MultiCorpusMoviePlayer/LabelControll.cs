using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinectWPF;
using System.IO;

namespace MultiCorpusMoviePlayer
{
    class LabelControll
    {
        private string fileName;
        private string enableLabelName;
        private string disableLabelName;
        private TimeLineLabel TimeLineLabel;

        private string startTimeString = "";
        private string endTimeString = "";

        public LabelControll(string filename, string enable, string disable)
        {
            fileName = filename;
            enableLabelName = enable;
            disableLabelName = disable;
            TimeLineLabel = new TimeLineLabel();
            TimeLineLabel.Labels = new List<Label>();
        }

        private void AddLabel(string startTime, string endTime, string type)
        {
            var label = new Label()
            {
                StartTime = startTime,
                EndTime = endTime,
                LabelType = type
            };
            TimeLineLabel.Labels.Add(label);
        }

        public void ExportLabelCSV()
        {
            using (var sw = new StreamWriter($"{fileName}.csv", false))
            {
                foreach(var label in TimeLineLabel.Labels)
                {
                    sw.WriteLine($"{label.StartTime},{label.EndTime},{label.LabelType},");
                }
            }
        }

        public void SetStartTimeString(string time)
        {
            startTimeString = time;
        }

        public void SetEndTimeString(string time)
        {
            endTimeString = time;
            AddLabel(startTimeString, endTimeString, enableLabelName);
        }

    }
}
