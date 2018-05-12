using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.IO;
using EyeTracking.Interfaces;
using EyeTracking.Utils;
using EyeTracking.Models;
using EyeTracking.Models.Shape;
using System.Linq;
using System.Collections;
using EyeTracking.Utils.Csv;

namespace EyeTracking.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        #region Properties

        public double ScanPathDistance { get; set; }
        public Point prevPoint { get; set; }
        public bool IsImageShown { get; set; }
        public bool WebBrowser { get; set; }
        public ObservableCollection<FixationCircle> Shapes { get; set; }
        public ObservableCollection<ConnectionLine> Saccades { get; set; }

        public System.Drawing.Image Image
        {
            get => _image;
            set
            {
                IsImageShown = true;
                _image = value;
            }
        }
        #endregion

        #region Commands
        public ICommand OpenFileDialogCommand { get; set; }
        public ICommand OpenWebBrowserCommand { get; set; }
        #endregion

        #region Fields
        private readonly IDialogManager _ioManager;
        private readonly IFileAccessManager _fileAccessManager;
        private System.Drawing.Image _image;
        private GazeHandler _gazeHandler;
        #endregion

        public MainViewModel()
        {
            Shapes = new ObservableCollection<FixationCircle>();
            Saccades = new ObservableCollection<ConnectionLine>();

            ScanPathDistance = 0;


            _ioManager = new DialogManager();
            _fileAccessManager = new FileAccessManager();

            OpenFileDialogCommand = new RelayCommand(ImportFile);
            OpenWebBrowserCommand = new RelayCommand(OpenWebBrowser);

            _gazeHandler = new GazeHandler();
            _gazeHandler.OnFixation += OnFixation;
            _gazeHandler.OnData += OnData;
            _gazeHandler.OnFixationEnd += OnFixationEnd;
        }

        private void OpenWebBrowser()
        {
            WebBrowser = true;
        }

        private async void ImportFile()
        {
            var filename = _ioManager.OpenFileDialog(Constants.DialogConstants.Title,
                Constants.DialogConstants.ImageFilter);
            Image = await _fileAccessManager.LoadImageFrompathAsync(filename);
        }

        public FixationCircle GetShapeAtPos(double x, double y)
        {
            foreach (var shape in Shapes)
            {
                if (shape.IsInRange(x, y))
                {
                    return shape;
                }
            }

            return null;
        }

        public void OnFixationEnd(object sender, EventArgs e)
        {
            if (Image != null || WebBrowser)
            {
                double x = ((ReceivedDataEventArgs)e).Point.X;
                double y = ((ReceivedDataEventArgs)e).Point.Y;
                FixationCircle fixationCircle = GetShapeAtPos(x, y);
                if (fixationCircle != null)
                {
                    fixationCircle.FixationTime += ((ReceivedDataEventArgs)e).FixationTime.Milliseconds;
                }
            }
        }

        public void OnFixation(object sender, EventArgs e)
        {
            if (Image != null || WebBrowser)
            {
                double x = ((ReceivedDataEventArgs)e).Point.X;
                double y = ((ReceivedDataEventArgs)e).Point.Y;
                FixationCircle fixationCircle = GetShapeAtPos(x, y);
                if (fixationCircle != null)
                {
                    fixationCircle.OnFixation();
                    return;
                }
                System.Windows.Application.Current.Dispatcher.Invoke(delegate
                {
                    var color = RandomColorGenerator.GetColor();
                    var circle = new FixationCircle(x, y, color, Shapes.Count);
                    if (Shapes.Count > 0)
                    {
                        var line = new ConnectionLine(prevPoint, x, y, color);
                        Saccades.Add(line);
                        ScanPathDistance += line.Distance;
                    }
                    Shapes.Add(circle);
                    prevPoint = new Point(x, y);
                });
            }
        }

        private void OnData(object sender, EventArgs e)
        {
            double x = ((ReceivedDataEventArgs)e).Point.X;
            double y = ((ReceivedDataEventArgs)e).Point.Y;
            double ts = ((ReceivedDataEventArgs)e).FixationTime.Seconds;
            Console.WriteLine("Timestamp: {0}\t X: {1} Y:{2}", ts, x, y);
        }

        public ICommand WindowClosing
        {
            get
            {
                return new GalaSoft.MvvmLight.Command.RelayCommand<CancelEventArgs>(
                    (args) =>
                    {
                        try
                        {
                            SaveMetrics();
                            _gazeHandler.CleanUp();
                        }
                        catch (Exception)
                        {
                            // Object leakage in tobii framework
                        }
                        ViewModelLocator.Cleanup();
                    });
            }
        }

        private void SaveMetrics()
        {
            var metrics = new Metrics
            {
                Distance = ScanPathDistance,
                Number = Shapes.Count
            };
            CsvWriter.WriteCollectionToCsv(Shapes.ToList(), typeof(FixationCircle), @"Fixations.csv", new FixationClassMap());
            CsvWriter.WriteObjectToCsv(metrics, typeof(Metrics), @"Metrics.csv");
            CsvWriter.WriteCollectionToCsv(Saccades.ToList(), typeof(ConnectionLine), @"Saccades.csv", new ConnectionLineClassMap());
        }
    }
}
