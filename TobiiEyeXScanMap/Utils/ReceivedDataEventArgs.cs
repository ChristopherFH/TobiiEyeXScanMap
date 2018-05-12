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

        public ReceivedDataEventArgs(Point point, double timeStamp)
        {
            Point = point;
            TimeStamp = timeStamp;
        }

        public Point Point { get; set; }
        public double TimeStamp { get; set; }
    }
}
