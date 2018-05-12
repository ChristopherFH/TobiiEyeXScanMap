using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EyeTracking.Interfaces;

namespace EyeTracking.Utils
{
    public class DialogManager : IDialogManager
    {
        public string OpenFileDialog(string title, string filter)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = false,
                Title = title,
                Filter = filter
            };

            string filename = "";
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                filename = dialog.FileName;
            }

            dialog.Dispose();
            return filename;
        }

        public string OpenDirectoryDialog(string title)
        {
            var filename = "";
            var dialog = new FolderBrowserDialog
            {
                Description = title,
            };
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                filename = dialog.SelectedPath;
            }

            dialog.Dispose();
            return filename;
        }
    }
}
