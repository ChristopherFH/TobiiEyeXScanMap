using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EyeTracking.Utils
{
    public class ReceivedDataEventArgs : EventArgs
    {
        public ReceivedDataEventArgs(Point point)
        {
            Point = point;
        }

        public ReceivedDataEventArgs(Point point, TimeSpan fixationTime)
        {
            Point = point;
            FixationTime = fixationTime;
        }

        public ReceivedDataEventArgs(Point point, double timestamp)
        {
            Point = point;
            Timestamp = timestamp;
        }

        public Point Point { get; set; }
        public TimeSpan FixationTime { get; set; }
        public double Timestamp { get; set; }
    }
}
