using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace Dekart.LazyNet.SQLBackup2Remote.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddConnection.xaml
    /// </summary>
    public partial class AddConnection : Window
    {
        JobData _data;
        private List<string> _items;

        public AddConnection(JobData data)
        {
            InitializeComponent();
            _data = data;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Owner != null)
            {
                Left = Owner.Left + (Owner.Width - Width) / 2;
                Top = Owner.Top + (Owner.Height - Height) / 2;
            }

            ServerNameComboBox.Text = _data.ServerName;

            if (_data.IntegratedSecurity)
            {
                cbIntegratedSecurity.IsChecked = true;
            }
            else
            {
                cbSQLAuthentication.IsChecked = true;
            }
            if (cbIntegratedSecurity.IsChecked == true)
            {
                teUserName.IsEnabled = false;
                tePassword.IsEnabled = false;
            }
            else
            {
                teUserName.Text = _data.UserName;
                tePassword.Password = _data.Password;
            }
        }

        private async void ServerNameComboBox_DropDownOpened(object sender, System.EventArgs e)
        {
            if (_items != null) return;

            Cursor = Cursors.Wait;
            try
            {
                _items = await DbHelper.GetDataSourcesAsync();
                ServerNameComboBox.Items.Clear();
                foreach (var item in _items)
                {
                    ServerNameComboBox.Items.Add(item);
                }
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        private void CbIntegratedSecurity_Click(object sender, RoutedEventArgs e)
        {
            teUserName.IsEnabled = tePassword.IsEnabled = false;
            teUserName.Text = tePassword.Password = null;
        }

        private void cbSQLAuthentication_Click(object sender, RoutedEventArgs e)
        {
            teUserName.IsEnabled = tePassword.IsEnabled = true;
        }

        private void ConnectionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var conn = DbHelper.GetNewOpenConnection(ServerNameComboBox.Text, cbIntegratedSecurity.IsChecked == true, teUserName.Text, tePassword.Password);
                conn.Close();

                MessageBox.Show(this, "Test connection succeeded", Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var conn = DbHelper.GetNewOpenConnection(ServerNameComboBox.Text, cbIntegratedSecurity.IsChecked == true, teUserName.Text, tePassword.Password);
                conn.Close();

                _data.ServerName = ServerNameComboBox.Text;
                _data.IntegratedSecurity = cbIntegratedSecurity.IsChecked == true;
                _data.UserName = teUserName.Text;
                _data.Password = tePassword.Password;

                DialogResult = true;
                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}
