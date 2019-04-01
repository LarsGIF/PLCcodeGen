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
    }
}
