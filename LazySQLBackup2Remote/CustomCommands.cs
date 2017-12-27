using System.Windows.Input;

namespace Dekart.LazyNet.SQLBackup2Remote
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Download = new RoutedUICommand
                (
                        "Download",
                        "Download",
                        typeof(CustomCommands),
                        new InputGestureCollection()
                        {
                                        new KeyGesture(Key.D, ModifierKeys.Control)
                        }
                );
        public static readonly RoutedUICommand Jobs = new RoutedUICommand
                (
                        "Jobs",
                        "Jobs",
                        typeof(CustomCommands),
                        new InputGestureCollection()
                        {
                                        new KeyGesture(Key.J, ModifierKeys.Control)
                        }
                );
        public static readonly RoutedUICommand Logs = new RoutedUICommand
                (
                        "Logs",
                        "Logs",
                        typeof(CustomCommands),
                        new InputGestureCollection()
                        {
                                        new KeyGesture(Key.L, ModifierKeys.Control)
                        }
                );
        public static readonly RoutedUICommand Exit = new RoutedUICommand
                (
                        "Exit",
                        "Exit",
                        typeof(CustomCommands),
                        new InputGestureCollection()
                        {
                                        new KeyGesture(Key.X, ModifierKeys.Control)
                        }
                );

        //Define more commands here, just like the one above
    }
}
