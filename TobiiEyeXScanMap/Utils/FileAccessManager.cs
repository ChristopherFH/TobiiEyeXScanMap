using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using EyeTracking.Interfaces;

namespace EyeTracking.Utils
{
    public class FileAccessManager : IFileAccessManager
    {
        public Image LoadImageFrompath(string filepath)
        {
            return File.Exists(filepath) ? Image.FromFile(filepath) : null;
        }

        public async Task<Image> LoadImageFrompathAsync(string filepath)
        {
            return await Task.Factory.StartNew(() => File.Exists(filepath) ? Image.FromFile(filepath) : null);
        }
    }
}