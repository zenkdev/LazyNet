using System.Windows;

namespace Dekart.LazyNet.SQLBackup2Remote.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddCustomSQLScript.xaml
    /// </summary>
    public partial class AddCustomSQLScript : Window
    {
        public AddCustomSQLScript(string script)
        {
            InitializeComponent();

            ScriptTextBox.Text = script;
        }

        public string SQL { get { return ScriptTextBox.Text; } }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WinFormData.LoadFormLayout(this);
            if (Owner != null)
            {
                Left = Owner.Left + (Owner.Width - Width) / 2;
                Top = Owner.Top + (Owner.Height - Height) / 2;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            WinFormData.SaveFormLayout(this);
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
