using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows;

namespace Dekart.LazyNet.SQLBackup2Remote.Windows
{
    /// <summary>
    /// Логика взаимодействия для TaskSchedulerAccount.xaml
    /// </summary>
    public partial class TaskSchedulerAccount : Window
    {
        public TaskSchedulerAccount()
        {
            InitializeComponent();
        }

        public string Username { set { LoginTextBox.Text = value; } get { return LoginTextBox.Text; } }
        public string Password => PasswordTextBox.Password;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Owner != null)
            {
                Left = Owner.Left + (Owner.Width - Width) / 2;
                Top = Owner.Top + (Owner.Height - Height) / 2;
            }

            var identity = WindowsIdentity.GetCurrent();
            LoginTextBox.Text = identity.Name;
            ErrorLabel.Content = "";
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorLabel.Content = "";

            try
            {
                var token = IntPtr.Zero;
                string domain, username;
                var split = LoginTextBox.Text.Split('\\');
                if (split.Length > 1)
                {
                    domain = split[0];
                    username = split[1];
                }
                else
                {
                    domain = null;
                    username = split[0];
                }
                if (!WinHelper.LogonUser(username, domain, Password, WinHelper.LOGON32_LOGON_INTERACTIVE, WinHelper.LOGON32_PROVIDER_DEFAULT, ref token))
                {
                    throw new Exception($"WinApi exception. Error code:{Marshal.GetLastWin32Error()}.");
                }
                DialogResult = true;
                Close();
            }
            catch (Exception exc)
            {
                ErrorLabel.Content = exc.Message;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
