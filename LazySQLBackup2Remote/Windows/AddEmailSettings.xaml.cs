using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dekart.LazyNet.SQLBackup2Remote.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEmailSettings.xaml
    /// </summary>
    public partial class AddEmailSettings : Window
    {
        EmailSettingsData _emailSetting;
        string[] _to;

        public AddEmailSettings(EmailSettingsData emailSetting, string[] to)
        {
            InitializeComponent();
            _emailSetting = emailSetting;
            _to = to;
        }

        EmailSettingsData EmailSettings => _emailSetting;

        private bool ValidateData(bool hideOnSuccessMessage)
        {
            try
            {
                if (!hideOnSuccessMessage)
                {
                    var subject = string.Format(ConstStrings.EmailSubject, ConstStrings.ApplicationCaption);
                    SendMail.Send(teServer.Text, Convert.ToInt32(sePort.Text), cbUseAuthentication.IsChecked == true, cbEnableSsl.IsChecked == true, teUserName.Text, tePassword.Password, _to, subject, ConstStrings.EmailBody, teFrom.Text, "");

                    MessageBox.Show(this, ConstStrings.EmailError, Title, MessageBoxButton.OK, MessageBoxImage.Information);
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
            teFrom.Text = EmailSettings.From;
            teServer.Text = EmailSettings.SmtpServer;
            sePort.Text = EmailSettings.SmtpPort.ToString();
            cbUseAuthentication.IsChecked = EmailSettings.UseAuthentication;
            if (cbUseAuthentication.IsChecked == true)
            {
                cbEnableSsl.IsEnabled = teUserName.IsEnabled = tePassword.IsEnabled = true;
                cbEnableSsl.IsChecked = EmailSettings.EnableSsl;
                teUserName.Text = EmailSettings.UserName;
                tePassword.Password = EmailSettings.Password;
            }
            else
            {
                cbEnableSsl.IsEnabled = teUserName.IsEnabled = tePassword.IsEnabled = false;
                cbEnableSsl.IsChecked = false;
                teUserName.Text = tePassword.Password = null;
            }
        }

        private void CbUseAuthentication_Click(object sender, RoutedEventArgs e)
        {
            cbEnableSsl.IsEnabled = teUserName.IsEnabled = tePassword.IsEnabled = cbUseAuthentication.IsChecked == true;
            if (cbUseAuthentication.IsChecked == false)
            {
                cbEnableSsl.IsChecked = false;
                teUserName.Text = tePassword.Password = null;
            }
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
                EmailSettings.From = teFrom.Text;
                EmailSettings.SmtpServer = teServer.Text;
                EmailSettings.SmtpPort = Convert.ToInt32(sePort.Text);
                EmailSettings.UseAuthentication = cbUseAuthentication.IsChecked == true;
                EmailSettings.EnableSsl = cbEnableSsl.IsChecked == true;
                EmailSettings.UserName = teUserName.Text;
                EmailSettings.Password = tePassword.Password;

                DialogResult = true;
                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void SendMailButton_Click(object sender, RoutedEventArgs e)
        {
            ValidateData(false);
        }
    }
}
