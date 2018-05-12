using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace EyeTracking.Models.Shape
{
    public class ConnectionLine : Point
    {
        private double _x2;
        private double _y2;

        public double X2
        {
            get => _x2;
            set
            {
                _x2 = value;
                OnPropertyChanged(nameof(X2));
            }
        }

        public double Y2
        {
            get => _y2;
            set
            {
                _y2 = value;
                OnPropertyChanged(nameof(Y2));
            }
        }

        public ConnectionLine(double x, double y, double x2, double y2, Color color) : base(x, y, color)
        {
            X2 = x2;
            Y2 = y2;
        }

        public ConnectionLine(Point p, double x2, double y2, Color color) : base(p.X, p.Y, color)
        {
            X2 = x2;
            Y2 = y2;
        }

        public ConnectionLine(Point p, Point p1, Color color) : base(p.X, p.Y, color)
        {
            X2 = p1.X;
            Y2 = p1.Y;
        }
    }
}