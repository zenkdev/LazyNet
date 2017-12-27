using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows;
using System.Windows.Input;
using WinSCP;

namespace Dekart.LazyNet.SQLBackup2Remote.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddFtpDestination.xaml
    /// </summary>
    public partial class AddFtpDestination : Window
    {
        DestinationData _destination;

        public AddFtpDestination(DestinationData destination)
        {
            InitializeComponent();

            _destination = destination;
            if (_destination == null)
            {
                _destination = new DestinationData { Type = 1, DeleteAfterMonths = 6, Protocol = 0, Port = 21, RemoteFolder = "/" };
            }
        }

        public DestinationData Destination => _destination;

        private bool ValidateData(bool hideOnSuccessMessage)
        {
            if (!RemoteFolderTextBox.Text.EndsWith("/"))
            {
                RemoteFolderTextBox.Text += @"/";
            }

            try
            {
                var path = WinHelper.GetTempDirectory() + "\\test.txt";
                File.WriteAllText(path, "");

                // Setup session options
                var sessionOptions = new SessionOptions
                {
                    Protocol = ProtocolComboBox.SelectedIndex == 0 ? Protocol.Ftp : Protocol.Sftp,
                    HostName = HostTextBox.Text,
                    PortNumber = Convert.ToInt32(PortTextBox.Text),
                    UserName = teUserName.Text,
                    Password = tePassword.Password,
                    GiveUpSecurityAndAcceptAnySshHostKey = ProtocolComboBox.SelectedIndex > 0,
                    //SshHostKeyFingerprint = "ssh-rsa 1024 da:7d:21:d0:28:b6:ad:d8:76:35:58:d0:05:9b:b8:ce"
                };

                using (var session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);

                    // Upload files
                    var transferOptions = new TransferOptions { TransferMode = TransferMode.Binary };

                    var transferResult = session.PutFiles(path, RemoteFolderTextBox.Text, false, transferOptions);

                    // Throw on any error
                    transferResult.Check();

                    var removeResult = session.RemoveFiles(RemoteFolderTextBox.Text + "test.txt");

                    removeResult.Check();

                }
                File.Delete(path);

                if (!hideOnSuccessMessage)
                {
                    MessageBox.Show(this, "FTP Server destination has been successfully tested", Title, MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
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

            HostTextBox.Text = Destination.Path;
            teUserName.Text = Destination.UserName;
            tePassword.Password = Destination.Password;
            seDeleteAfterMonths.Text = Destination.DeleteAfterMonths.ToString();
            seDeleteAfterDays.Text = Destination.DeleteAfterDays.ToString();
            ProtocolComboBox.SelectedIndex = Destination.Protocol;
            PortTextBox.Text = Destination.Port.ToString();
            RemoteFolderTextBox.Text = Destination.RemoteFolder;
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
                Destination.Path = HostTextBox.Text;
                Destination.UserName = teUserName.Text;
                Destination.Password = tePassword.Password;
                Destination.DeleteAfterMonths = Convert.ToInt32(seDeleteAfterMonths.Text);
                Destination.DeleteAfterDays = Convert.ToInt32(seDeleteAfterDays.Text);
                Destination.Protocol = ProtocolComboBox.SelectedIndex;
                Destination.Port = Convert.ToInt32(PortTextBox.Text);
                Destination.RemoteFolder = RemoteFolderTextBox.Text;

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
