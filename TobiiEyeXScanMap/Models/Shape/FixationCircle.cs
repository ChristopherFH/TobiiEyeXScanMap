using System;
using System.Windows;
using System.Windows.Media;
using EyeTracking.Interfaces;

namespace EyeTracking.Models.Shape
{
    public class FixationCircle : Point, IRange
    {
        public int Number { get; set; }
        private double _height = Constants.DefauleDiameter;
        private double _width = Constants.DefauleDiameter;

        public Point Origin { get; set; }

        public FixationCircle(double x, double y, Color color, int number) : base(x, y, color)
        {
            Origin = new Point(x - Height / 2, y - Width / 2);
            X = x;
            Y = y;
            Color = color;
            Number = number;
        }

        public double Width
        {
            get => _width;
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        public void OnFixation()
        {
            Height++;
            Width++;
            Origin.X -= 0.5;
            Origin.Y -= 0.5;
        }

        public bool IsInRange(double x, double y)
        {
            var distance = Math.Sqrt(Math.Pow(x - X, 2) + Math.Pow(y - Y, 2));
            return !(distance > Constants.Distance);
        }
    }
}