namespace EyeTracking.Interfaces
{
    public interface IDialogManager
    {
        string OpenFileDialog(string title, string filter);

        string OpenDirectoryDialog(string title = "");
    }
}
