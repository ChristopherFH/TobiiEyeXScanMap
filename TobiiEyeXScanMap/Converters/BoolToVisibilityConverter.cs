﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace EyeTracking.Converters
{
    class BoolToVisibilityConverter : IValueConverter
    {
        public int Collapse { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool l_value = (bool) value;
            if (l_value)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            Visibility visibility = (Visibility) value;
            switch (visibility)
            {
                case Visibility.Visible:
                default:
                    return true;
                case Visibility.Hidden:
                case Visibility.Collapsed:
                    return false;
            }
        }
    }
}