using System;
using System.Deployment.Application;
using System.Timers;

namespace Dekart.LazyNet.Win
{
    public class SilentUpdater
    {
        // ReSharper disable InconsistentNaming
        /// <summary> проверка обновлений каждые 30 минут </summary>
        const int DEFAULT_INTERVAL = 30;
        // ReSharper restore InconsistentNaming

        readonly ApplicationDeployment _applicationDeployment;
        readonly Timer _timer = new Timer(60 * 1000); // 1 минута
        bool _processing;
        int _counter;

        public event EventHandler<UpdateAvailableEventArgs> UpdateAvailable;

        public SilentUpdater()
        {
            if (!ApplicationDeployment.IsNetworkDeployed) return;

            _applicationDeployment = ApplicationDeployment.CurrentDeployment;

            _timer.Elapsed += OnTimerOnElapsed;

            _timer.Start();
        }

        void OnTimerOnElapsed(object sender, ElapsedEventArgs args)
        {
            if (_processing) return;

            _processing = true;

            try
            {
                _counter--;
                if (_counter > 0) return;

                var info = _applicationDeployment.CheckForDetailedUpdate(false);

                if (info.UpdateAvailable)
                {
                    if (UpdateAvailable != null)
                    {
                        UpdateAvailable(this, new UpdateAvailableEventArgs(_applicationDeployment.CurrentVersion, info.AvailableVersion));
                    }
                }
                _counter = DEFAULT_INTERVAL;
            }
            finally
            {
                _processing = false;
            }
        }
    }

    public class UpdateAvailableEventArgs : EventArgs
    {
        public UpdateAvailableEventArgs(Version currentVersion, Version availableVersion)
        {
            CurrentVersion = currentVersion.ToString();
            AvailableVersion = availableVersion.ToString();
        }
        public string CurrentVersion { get; private set; }
        public string AvailableVersion { get; private set; }
    }
}
