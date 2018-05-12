using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using EyeTracking.Annotations;

namespace EyeTracking.Models.Shape
{
    public class Point : INotifyPropertyChanged
    {
        private double _x;
        private double _y;

        public Color Color { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point(double x, double y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public double X
        {
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged(nameof(X));
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                OnPropertyChanged(nameof(Y));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}