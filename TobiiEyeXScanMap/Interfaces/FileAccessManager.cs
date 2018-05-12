using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeTracking.Interfaces
{
    public interface IFileAccessManager
    {
        Image LoadImageFrompath(string filepath); 
        Task<Image> LoadImageFrompathAsync(string filepath); 
    }
}
