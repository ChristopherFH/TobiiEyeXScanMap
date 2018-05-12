using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EyeTracking.Converters
{
    class BoolToBoolInvertedConverter : IValueConverter
    {
        public BoolToBoolInvertedConverter() { }
        public int Collapse { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                bool lRes = bool.TryParse(value.ToString(), out var lValue);
                if (lRes)
                {
                    return !lValue;
                }
                else
                {
                    return Binding.DoNothing;
                }
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                bool lRes = bool.TryParse(value.ToString(), out var lValue);
                if (lRes)
                {
                    return !lValue;
                }
                else
                {
                    return Binding.DoNothing;
                }
            }
            return Binding.DoNothing;
        }
    }
}
