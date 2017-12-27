using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows;
using System.Windows.Input;

namespace Dekart.LazyNet.SQLBackup2Remote.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddFolderDestination.xaml
    /// </summary>
    public partial class AddFolderDestination : Window
    {
        DestinationData _destination;

        public AddFolderDestination(DestinationData destination)
        {
            InitializeComponent();

            _destination = destination;
            if (_destination == null)
            {
                _destination = new DestinationData { Type = 0, DeleteAfterMonths = 6 };
            }
        }

        public DestinationData Destination => _destination;

        private bool ValidateData(bool hideOnSuccessMessage)
        {
            //elevate privileges before doing file copy to handle domain security
            WindowsImpersonationContext impersonationContext = null;
            IntPtr userHandle = IntPtr.Zero;
            try
            {
                var userName = teUserName.Text.Trim();
                if (userName != "")
                {
                    string domain, user;
                    var split = userName.Split('\\');
                    if (split.Length > 1)
                    {
                        domain = split[0];
                        user = split[1];
                    }
                    else
                    {
                        // if domain name was blank, assume local machine
                        domain = Environment.UserDomainName;
                        user = userName;
                    }

                    // Call LogonUser to get a token for the user
                    if (!WinHelper.LogonUser(user, domain, tePassword.Password, WinHelper.LOGON32_LOGON_INTERACTIVE, WinHelper.LOGON32_PROVIDER_DEFAULT, ref userHandle))
                    {
                        throw new Exception("Exception impersonating user, error code: " + Marshal.GetLastWin32Error());
                    }

                    // Begin impersonating the user
                    impersonationContext = WindowsIdentity.Impersonate(userHandle);
                }

                //run the program with elevated privileges (like file copying from a domain server)
                var path = Path.Combine(tePath.Text, "test.txt");
                File.WriteAllText(path, "");
                File.Delete(path);

                if (!hideOnSuccessMessage)
                {
                    MessageBox.Show(this, "Folder destination has been successfully tested", Title, MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            finally
            {
                // Clean up
                impersonationContext?.Undo();

                if (userHandle != IntPtr.Zero)
                {
                    WinHelper.CloseHandle(userHandle);
                }
            }

            return true;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Owner != null)
            {
                Left = Owner.Left + (Owner.Width - Width) / 2;
                Top = Owner.Top + (Owner.Height - Height) / 2;
            }

            tePath.Text = Destination.Path;
            teUserName.Text = Destination.UserName;
            tePassword.Password = Destination.Password;
            seDeleteAfterMonths.Text = Destination.DeleteAfterMonths.ToString();
            seDeleteAfterDays.Text = Destination.DeleteAfterDays.ToString();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateData(true))
            {
                Destination.Path = tePath.Text;
                Destination.UserName = teUserName.Text;
                Destination.Password = tePassword.Password;
                Destination.DeleteAfterMonths = Convert.ToInt32(seDeleteAfterMonths.Text);
                Destination.DeleteAfterDays = Convert.ToInt32(seDeleteAfterDays.Text);

                DialogResult = true;
                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void AccessButton_Click(object sender, RoutedEventArgs e)
        {
            ValidateData(false);
        }
    }
}
