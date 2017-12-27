using System.Windows;

namespace Dekart.LazyNet.SQLBackup2Remote.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddDestination.xaml
    /// </summary>
    public partial class AddDestination : Window
    {
        public AddDestination()
        {
            InitializeComponent();
        }

        public int DestinationType { get; private set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Owner != null)
            {
                Left = Owner.Left + (Owner.Width - Width) / 2;
                Top = Owner.Top + (Owner.Height - Height) / 2;
            }
        }

        private void FolderButton_Click(object sender, RoutedEventArgs e)
        {
            DestinationType = 0;
            DialogResult = true;
            Close();
        }

        private void FtpButton_Click(object sender, RoutedEventArgs e)
        {
            DestinationType = 1;
            DialogResult = true;
            Close();
        }

    }
}
