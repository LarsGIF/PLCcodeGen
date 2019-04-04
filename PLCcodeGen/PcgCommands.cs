using System.Windows.Input;

namespace PLCcodeGen
{
    public static class PcgCommands
    {
        public static readonly RoutedUICommand AddCell = new RoutedUICommand
            (
                "Add Cell",
                "AddCell",
                typeof(PcgCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.A, ModifierKeys.Control)
                }
            );

        public static readonly RoutedUICommand AddStn = new RoutedUICommand
            (
                "Add Stn",
                "AddStn",
                typeof(PcgCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.S, ModifierKeys.Control)
                }
            );

        public static readonly RoutedUICommand AddItem = new RoutedUICommand
            (
                "Add Item",
                "AddItem",
                typeof(PcgCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.I, ModifierKeys.Control)
                }
            );

        public static readonly RoutedUICommand Settings = new RoutedUICommand
            (
                "Edit Settings",
                "Settings",
                typeof(PcgCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.A, ModifierKeys.Control)
                }
            );
    }
}
