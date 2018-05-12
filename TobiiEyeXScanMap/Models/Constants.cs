using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeTracking.Models
{
    public static class Constants
    {
        public const double DefauleDiameter = 75; 
        public const double Distance = 75; 

        public static class DialogConstants
        {
            public const string Title = "Select an Image"; 
            public const string ImageFilter =
                "Bilddatei (*.png;*.jpeg;*.jpg;*.tiff;*.tif)|*.png;*.jpeg;*.jpg;*.tiff;*.tif|All files (*.*)|*.*";
        }
    }
}