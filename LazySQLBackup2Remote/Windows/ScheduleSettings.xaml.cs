using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using System.ComponentModel;
using System.Security.Principal;
using System.Windows;

namespace Dekart.LazyNet.SQLBackup2Remote.Windows
{
    /// <summary>
    /// Логика взаимодействия для ScheduleSettings.xaml
    /// </summary>
    public partial class ScheduleSettings : Window
    {
        JobData _job;

        public ScheduleSettings(JobData job)
        {
            InitializeComponent();
            _job = job;
        }

        MainWindow ParentWindow => Application.Current.MainWindow as MainWindow;

        JobData Job => _job;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WinFormData.LoadFormLayout(this);
            if (Owner != null)
            {
                Left = Owner.Left + (Owner.Width - Width) / 2;
                Top = Owner.Top + (Owner.Height - Height) / 2;
            }

            teScheduleUserId.Text = Job.ScheduleUserId;
            FullBackupGrid.ItemsSource = Job.FullBackupSchedule;
            DiffBackupGrid.ItemsSource = Job.DiffBackupSchedule;
            TranBackupGrid.ItemsSource = Job.TranBackupSchedule;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            WinFormData.SaveFormLayout(this);
        }

        private void DeleteFullBackupShedule_Click(object sender, RoutedEventArgs e)
        {
            var dataItem = FullBackupGrid.SelectedItem as ScheduleData;
            if (dataItem == null || Job.FullBackupSchedule.Count < 2) return;
            Job.FullBackupSchedule.Remove(dataItem);
        }

        private void EditFullBackupShedule_Click(object sender, RoutedEventArgs e)
        {
            var dataItem = FullBackupGrid.SelectedItem as ScheduleData;
            if (dataItem == null) return;
            var window = new AddSchedule(dataItem);
            window.ShowDialog(ParentWindow);
        }

        void AddFullBackupShedule_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddSchedule(null);
            if (window.ShowDialog(ParentWindow) == true)
            {
                Job.FullBackupSchedule.Add(window.Schedule);
            }
        }

        private void DeleteDiffBackupShedule_Click(object sender, RoutedEventArgs e)
        {
            var dataItem = DiffBackupGrid.SelectedItem as ScheduleData;
            if (dataItem == null) return;
            Job.DiffBackupSchedule.Remove(dataItem);
        }

        private void EditDiffBackupShedule_Click(object sender, RoutedEventArgs e)
        {
            var dataItem = DiffBackupGrid.SelectedItem as ScheduleData;
            if (dataItem == null) return;
            var window = new AddSchedule(dataItem);
            window.ShowDialog(ParentWindow);
        }

        void AddDiffBackupShedule_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddSchedule(null);
            if (window.ShowDialog(ParentWindow) == true)
            {
                Job.DiffBackupSchedule.Add(window.Schedule);
            }
        }

        private void DeleteTranBackupShedule_Click(object sender, RoutedEventArgs e)
        {
            var dataItem = TranBackupGrid.SelectedItem as ScheduleData;
            if (dataItem == null) return;
            Job.TranBackupSchedule.Remove(dataItem);
        }

        private void EditTranBackupShedule_Click(object sender, RoutedEventArgs e)
        {
            var dataItem = TranBackupGrid.SelectedItem as ScheduleData;
            if (dataItem == null) return;
            var window = new AddSchedule(dataItem);
            window.ShowDialog(ParentWindow);
        }

        void AddTranBackupShedule_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddSchedule(null);
            if (window.ShowDialog(ParentWindow) == true)
            {
                Job.TranBackupSchedule.Add(window.Schedule);
            }
        }

        void SetAsCurrentUserButton_Click(object sender, RoutedEventArgs e)
        {
            var identity = WindowsIdentity.GetCurrent();
            if (identity != null)
            {
                teScheduleUserId.Text = identity.Name;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            var userId = teScheduleUserId.Text.Trim();
            if (Job.ScheduleUserId != userId)
            {
                Job.ScheduleUserId = userId;
                Job.SchedulePassword = null;
                if (Job.ScheduleThisJob)
                {
                    var window = new TaskSchedulerAccount();
                    if (!string.IsNullOrWhiteSpace(userId))
                    {
                        window.Username = userId;
                    }
                    if (window.ShowDialog(ParentWindow) == true)
                    {
                        Job.ScheduleUserId = window.Username;
                        Job.SchedulePassword = window.Password;
                    }
                }
            }

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
