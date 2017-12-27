using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Dekart.LazyNet.SQLBackup2Remote.Windows
{
    /// <summary>
    /// Логика взаимодействия для RunJob.xaml
    /// </summary>
    public partial class RunJob : Window
    {
        JobData _job;
        Task<Dictionary<string, bool>> _task;

        public RunJob(JobData job)
        {
            InitializeComponent();

            _job = job;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WinFormData.LoadFormLayout(this);
            if (Owner != null)
            {
                Left = Owner.Left + (Owner.Width - Width) / 2;
                Top = Owner.Top + (Owner.Height - Height) / 2;
            }

            LogHelper.TextChanged += LogHelper_TextChanged;
            OkButton.IsEnabled = CancelButton.IsEnabled = false;
            Cursor = Cursors.Wait;
            _task = new JobRunner().RunAsync(_job, BackupType.Full);
            await _task;
            LogHelper.TextChanged -= LogHelper_TextChanged;
            CancelButton.IsEnabled = true;
            Cursor = Cursors.Arrow;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_task != null && _task.IsCompleted == false)
            {
                e.Cancel = true;
                return;
            }

            WinFormData.SaveFormLayout(this);
        }

        void LogHelper_TextChanged(string text)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new TextChangedEventHandler(LogHelper_TextChanged), text);
            }
            else
            {
                OutputTextBox.AppendText(text + Environment.NewLine);
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

     }
}
