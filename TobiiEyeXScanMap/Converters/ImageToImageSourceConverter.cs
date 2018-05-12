using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace EyeTracking.Converters
{
    [ValueConversion(typeof(System.Drawing.Image), typeof(System.Windows.Media.ImageSource))]
    public class ImageToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value == null) { return null; }

            try
            {
                using (var ms = new MemoryStream())
                {
                    (value as Image)?.Save(ms, ImageFormat.Bmp);
                    ms.Seek(0, SeekOrigin.Begin);

                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = ms;
                    bitmapImage.EndInit();

                    return bitmapImage;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
