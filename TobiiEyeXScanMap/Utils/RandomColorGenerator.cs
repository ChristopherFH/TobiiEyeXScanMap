using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EyeTracking.Utils
{
    public static class RandomColorGenerator
    {
        public static Color GetColor()
        {
            Random rnd = new Random();
            Byte[] b = new Byte[3];
            rnd.NextBytes(b);
            Color color = Color.FromRgb(b[0], b[1], b[2]);
            return color;
        }
    }
}