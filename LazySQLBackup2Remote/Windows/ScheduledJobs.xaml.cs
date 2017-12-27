using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using Microsoft.Win32.TaskScheduler;
using System;
using System.ComponentModel;
using System.Windows;

namespace Dekart.LazyNet.SQLBackup2Remote.Windows
{
    /// <summary>
    /// Логика взаимодействия для ScheduledJobs.xaml
    /// </summary>
    public partial class ScheduledJobs : Window
    {
        public ScheduledJobs()
        {
            InitializeComponent();
        }

        async void InitData()
        {
            try
            {
                // Get the service on the local machine
                using (var ts = new TaskService())
                {
                    var tasks = await System.Threading.Tasks.Task.Factory.StartNew(() => ts.FindAllTasks(new Wildcard(WinHelper.AppName + "*"), false));
                    ScheduledJobsGrid.ItemsSource = tasks;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, ConstStrings.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WinFormData.LoadFormLayout(this);
            if (Owner != null)
            {
                Left = Owner.Left + (Owner.Width - Width) / 2;
                Top = Owner.Top + (Owner.Height - Height) / 2;
            }

            InitData();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            WinFormData.SaveFormLayout(this);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var dataItem = ScheduledJobsGrid.SelectedItem as Task;
            if (dataItem == null) return;

            if (MessageBox.Show(this, string.Format(ConstStrings.DeleteScheduledJob, dataItem.Name), ConstStrings.Question, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) return;
            try
            {
                // Get the service on the local machine
                using (var ts = new TaskService())
                {
                    ts.RootFolder.DeleteTask(dataItem.Name);
                    InitData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, ConstStrings.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
