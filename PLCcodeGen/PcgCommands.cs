using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    class PcgCommands
    {
        #region Edit menu
        // Add Cell
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

        // Add Station
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
        #endregion

        #region AddItems menu
        // Add Pnematic Cylinder
        public static readonly RoutedUICommand AddPneuCyl = new RoutedUICommand
            (
                "Add Cylinder",
                "AddPneuCyl",
                typeof(PcgCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.C, ModifierKeys.Control)
                }
            );

        // Add Pnematic Valve
        public static readonly RoutedUICommand AddValve = new RoutedUICommand
            (
                "Add Valve",
                "AddValve",
                typeof(PcgCommands),
                new InputGestureCollection()
                {
                            new KeyGesture(Key.V, ModifierKeys.Control)
                }
            );

        // Add Electric motor
        public static readonly RoutedUICommand AddMotor = new RoutedUICommand
            (
                "Add Motor",
                "AddMotor",
                typeof(PcgCommands),
                new InputGestureCollection()
                {
                            new KeyGesture(Key.M, ModifierKeys.Control)
                }
            );

        // Add AddEnclosure (e.g. Electrical control pannel/box)
        public static readonly RoutedUICommand AddEnclosure = new RoutedUICommand
            (
                "Add Enclosure",
                "AddEnclosure",
                typeof(PcgCommands),
                new InputGestureCollection()
                {
                            new KeyGesture(Key.E, ModifierKeys.Control)
                }
            );

        // Add Access Gate
        public static readonly RoutedUICommand AddAGate = new RoutedUICommand
            (
                "Add Access Gate",
                "AddAGate",
                typeof(PcgCommands),
                new InputGestureCollection()
                {
                            new KeyGesture(Key.G, ModifierKeys.Control)
                }
            );

        // Add HMI
        public static readonly RoutedUICommand AddHmi = new RoutedUICommand
            (
                "Add HMI",
                "AddHmi",
                typeof(PcgCommands),
                new InputGestureCollection()
                {
                            new KeyGesture(Key.H, ModifierKeys.Control)
                }
            );

        // Add HMI Connection box
        public static readonly RoutedUICommand AddHCB = new RoutedUICommand
            (
                "Add HMI Connection box",
                "AddHCB",
                typeof(PcgCommands),
                new InputGestureCollection()
                {
                            new KeyGesture(Key.B, ModifierKeys.Control)
                }
            );

        // Add I/O Block
        public static readonly RoutedUICommand AddIoBlock = new RoutedUICommand
            (
                "Add I/O Block",
                "AddIoBlock",
                typeof(PcgCommands),
                new InputGestureCollection()
                {
                            new KeyGesture(Key.I, ModifierKeys.Control)
                }
            );

        // Add Muli Instance Function Block
        public static readonly RoutedUICommand AddMfBlock = new RoutedUICommand
            (
                "Add Muli FBlock",
                "AddMfBlock",
                typeof(PcgCommands),
                new InputGestureCollection()
                {
                            new KeyGesture(Key.F, ModifierKeys.Control)
                }
            );

        // Add Single Instance Function Block (Program)
        public static readonly RoutedUICommand AddSfBlock = new RoutedUICommand
            (
                "Add Program",
                "AddSfBlock",
                typeof(PcgCommands),
                new InputGestureCollection()
                {
                            new KeyGesture(Key.P, ModifierKeys.Control)
                }
            );
        
        // Add SFC Program
        public static readonly RoutedUICommand AddSeqBlock = new RoutedUICommand
            (
                "Add SFC Program",
                "AddSeqBlock",
                typeof(PcgCommands),
                new InputGestureCollection()
                {
                            new KeyGesture(Key.S, ModifierKeys.Control)
                }
            );       
        #endregion

        #region Tools menu
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
        #endregion
    }
}

