using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EyeTracking.Interfaces;
using EyeTracking.Utils;
using EyeTracking.ViewModel;
using Tobii.Interaction;
using Tobii.Interaction.Framework;
using Tobii.Interaction.Wpf;

namespace EyeTracking.Models
{
    public class GazeHandler : IObserver<StreamData<FixationData>>, IObserver<StreamData<GazePointData>>
    {
        public event EventHandler OnFixation;
        public event EventHandler OnFixationEnd;
        public event EventHandler OnData;

        private GazePointDataStream _gazePointDataStream;
        private FixationDataStream _fixationDataStream;
        private readonly Host _host;
        private readonly WpfInteractorAgent _wpfInteractorAgent;

        public GazeHandler()
        {
            _host = new Host();
            _wpfInteractorAgent = _host.InitializeWpfAgent();

            _gazePointDataStream = _host.Streams.CreateGazePointDataStream();
            _fixationDataStream = _host.Streams.CreateFixationDataStream();

            _fixationDataStream.Subscribe(this);
            _gazePointDataStream.Subscribe(this);
        }


        public void OnNext(StreamData<FixationData> fixation)
        {
            var fixationBeginTime = 0d;
            var fixationPointX = fixation.Data.X;
            var fixationPointY = fixation.Data.Y;

            switch (fixation.Data.EventType)
            {
                case FixationDataEventType.Begin:
                    fixationBeginTime = fixation.Data.Timestamp;
                    Console.WriteLine(@"Begin fixation at X: {0}, Y: {1}", fixationPointX, fixationPointY);
                    break;

                case FixationDataEventType.Data:
                    OnFixation?.Invoke(this, new ReceivedDataEventArgs(new Point(fixationPointX, fixationPointY)));
                    break;

                case FixationDataEventType.End:
                    OnFixationEnd?.Invoke(this,
                        new ReceivedDataEventArgs(new Point(fixationPointX, fixationPointY),
                            TimeSpan.FromMilliseconds(fixation.Data.Timestamp - fixationBeginTime)));
                    Console.WriteLine(@"End fixation at X: {0}, Y: {1}", fixationPointX, fixationPointY);
                    Console.WriteLine(@"Fixation duration: {0} ",
                        fixationBeginTime > 0
                            ? TimeSpan.FromMilliseconds(fixation.Data.Timestamp - fixationBeginTime)
                            : TimeSpan.Zero);
                    break;

                default:
                    throw new InvalidOperationException(
                        "Unknown fixation event type, which doesn't have explicit handling.");
            }
        }

        public void OnNext(StreamData<GazePointData> value)
        {
            double x = value.Data.X;
            double y = value.Data.Y;
            double ts = value.Data.Timestamp;
            OnData?.Invoke(this, new ReceivedDataEventArgs(new Point(x, y), ts));
        }

        public void OnError(Exception error)
        {
            CleanUp();
        }

        public void OnCompleted()
        {
            // ignore
        }

        public void CleanUp()
        {
            _host.RemoveInteractorAgent(_wpfInteractorAgent);
            _wpfInteractorAgent.Dispose();
            _host.Dispose();
        }
    }
}