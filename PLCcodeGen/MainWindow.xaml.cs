﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PLCcodeGen.Properties;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLCcodeGen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Object SelectedItem;
        Item SelectedDetail;

        public MainWindow()
        {
            InitializeComponent();
            projectTree.ItemsSource = ((App)Application.Current).MyProjects;
            if (Settings.Default.LoadPreviousProject)
            {
                OpenProject(Settings.Default.PreviousProjectPath);
            }
        }

        #region File Menu
        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            switch (((App)Application.Current).MyProjects.Count)
            {
                case 0:
                    NewProject();
                    break;
                case 1:
                    switch (MessageBox.Show(
                        "Only one project can be open at a time.\nDo you want to save current project before it is closed?",
                        "New project", MessageBoxButton.YesNoCancel, MessageBoxImage.Question))
                    {
                        case MessageBoxResult.Yes:
                            SaveProject();
                            break;
                        case MessageBoxResult.No:
                            break;
                        case MessageBoxResult.Cancel:
                            return;
                    }
                    if (NewProject())
                    {
                        // You will now have two projects in the tree. Remove the old one.
                        ((App)Application.Current).MyProjects.RemoveAt(0);
                    }
                    break;
                default:
                    MessageBox.Show(
                        "More than one project exists!\nPlease close current projects to continue.",
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (((App)Application.Current).MyProjects.Count == 0)
            {
                // Configure and open file dialog box
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = ""; // Default file name
                dlg.DefaultExt = ".pcg"; // Default file extension
                dlg.Filter = "PLCcodeGen|*.pcg|All files (*.*)|*.*"; // Filter files by extension

                // Show open file dialog box and process open file dialog box results
                if (dlg.ShowDialog() == true) OpenProject(dlg.FileName);
            }
            else
                MessageBox.Show(
                    "A project is already open!\nPlease close current project to continue.",
                    "Project Open", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void CloseCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (((App)Application.Current).MyProjects.Count > 0)
            {
                switch (MessageBox.Show(
                    "Do you want to save the project before you close it?",
                    "Close project", MessageBoxButton.YesNoCancel, MessageBoxImage.Question))
                {
                    case MessageBoxResult.Yes:
                        SaveProject();
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        // Do nothing (skip removing).
                        return;
                }
                ((App)Application.Current).MyProjects.RemoveAt(0);
            }
            else
                MessageBox.Show(
                    "There is no project to close!",
                    "Close project", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveProject();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (((App)Application.Current).MyProjects.Count == 1)
            {
                // Save current projcet path to User Default Settings
                Properties.Settings.Default.PreviousProjectPath = ((App)Application.Current).MyProjects[0].ProjFile;
                Properties.Settings.Default.Save();
            }
            Application.Current.Shutdown();
        }
        #endregion

        #region Edit menu
        private void AddCellCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (((App)Application.Current).MyProjects.Count) == 1
                && SelectedItem != null && (SelectedItem.GetType().Name == "Project");
        }
        private void AddCellCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddItemDlg dlg = new AddItemDlg
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Tag = "Cell"
            };
            dlg.ShowDialog();
            if (dlg.DialogResult == true)
            {            
                ((Project)SelectedItem).Cells.Add(new Cell(dlg.itemName.Text));
            }
        }

        private void AddStnCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (((App)Application.Current).MyProjects.Count) == 1
                && SelectedItem != null && (SelectedItem.GetType().Name == "Cell");
        }
        private void AddStnCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //TODO: Add dialog to enter name of station
            ((Cell)SelectedItem).Stations.Add(new Station("Sxxx"));
        }

        private void AddPnuCylCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((App)Application.Current).MyProjects.Count == 1
                && SelectedItem != null && SelectedItem.GetType().Name == "Station";
        }
        private void AddPneuCylCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddItemDlg dlg = new AddItemDlg
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Tag = "Cylinder"
            };
            dlg.ShowDialog();
            if (dlg.DialogResult == true)
            {
                if (SelectedItem.GetType().ToString() == "PLCcodeGen.Station")
                {
                    PneuCyl cyl = new PneuCyl(((App)Application.Current).MyProjects[0].PlcName
                        + ((Station)SelectedItem).Name.Substring(1), dlg.itemName.Text);
                    ((Station)SelectedItem).Items.Add(cyl);
                }
                else
                    MessageBox.Show("You can only add Cylinders to a Station", "Input Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddValveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((App)Application.Current).MyProjects.Count == 1
                && SelectedItem != null && SelectedItem.GetType().Name == "Station";
        }
        private void AddValveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddItemDlg dlg = new AddItemDlg
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Tag = "Valve"
            };
            dlg.ShowDialog();
            if (dlg.DialogResult == true)
            {
                if (SelectedItem.GetType().ToString() == "PLCcodeGen.Station")
                {
                    Valve valve = new Valve(dlg.itemName.Text);
                    ((Station)SelectedItem).Items.Add(valve);
                }
                else
                    MessageBox.Show("You can only add Valves to a Station", "Input Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddValveIslandCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((App)Application.Current).MyProjects.Count == 1
                && SelectedItem != null && SelectedItem.GetType().Name == "Station";
        }
        private void AddValveIslandCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // TODO: This dialog can only add one valve island to a station. A second will overwrite the first.
            // TODO: I/O addresses are not set by this method.
            AddValveIslandDlg dlg = new AddValveIslandDlg
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Tag = "Valve Isalnd"
            };
            dlg.ShowDialog();
            if(dlg.DialogResult == true)
            {
                if (SelectedItem.GetType().ToString() == "PLCcodeGen.Station")
                {
                    // Create a new valve island with basic configuration.
                    string location = ((App)Application.Current).MyProjects[0].PlcName + ((Station)SelectedItem).Name.Substring(1);
                    ValveIsland valveIsland = new ValveIsland(location, dlg.vIslandName.Text);

                    // Add all valves in station
                    // TODO: Need to be modified to handle more than one valve island in a station.
                    int modNum = 1; // Start on first input module.
                    int ioNum = 2;  // Start with third input. (First input occupied by pilot air valve sensor.)
                    foreach (Item item in ((Station)SelectedItem).Items)
                    {
                        if (item.ItemType == TypeOfItem.valve) {
                            Valve v = (Valve)item;
                            foreach(PneuCyl cyl in v.PneuCyls)
                            {
                                if(ioNum > valveIsland.Modules[modNum].Size)
                                {
                                    modNum = valveIsland.InsertModule(v.Name + "." + modNum.ToString(), 8, IOtype.inp, "bool");
                                    ioNum = 0;
                                }
                                valveIsland.Modules[modNum].Ios[ioNum++].Name = cyl.SensBxF;
                                if (ioNum > valveIsland.Modules[modNum].Size)
                                {
                                    modNum = valveIsland.InsertModule(v.Name + "." + modNum.ToString(), 8, IOtype.inp, "bool");
                                    ioNum = 0;
                                }
                                valveIsland.Modules[modNum].Ios[ioNum++].Name = cyl.SensBxR;
                            }
                            // TODO: Add outputs for valves.
                            valveIsland.Valves.Add(v);
                        }
                    }
                    ((Station)SelectedItem).Items.Add(valveIsland);
                }
                else
                    MessageBox.Show("You can only add Valve Islands to a Station.", "Input Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void AddMotorCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((App)Application.Current).MyProjects.Count == 1
                && SelectedItem != null && SelectedItem.GetType().Name == "Station";
        }
        private void AddMotorCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void AddMfBlock_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((App)Application.Current).MyProjects.Count == 1
                && SelectedItem != null 
                && (SelectedItem.GetType().Name == "Cell"
                || SelectedItem.GetType().Name == "Station");
        }
        private void AddMfBlock_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddCodeBlockDlg dlg = new AddCodeBlockDlg
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Tag = "Code Block"
            };
            dlg.ShowDialog();
            if (dlg.DialogResult == true)
            {
                // Create a multi instance function block refrence
                FuncBlock fb = new FuncBlock(dlg.fbType.Text);
                fb.Ver = dlg.version.Text;
                fb.InstType = InstanceType.multi;
                fb.CdeType = dlg.SelCodeType;

                // Create a code block item and add the type to it
                CodeBlock cdeBlock = new CodeBlock(dlg.cdeBName.Text);
                cdeBlock.ItemType = TypeOfItem.cdeBlock;
                cdeBlock.FBlocks.Add(fb);

                // Add the code block Item to Cell or Station
                switch (SelectedItem.GetType().Name) {
                    case "Cell":
                        ((Cell)SelectedItem).Items.Add(cdeBlock);
                        break;
                    case "Station":
                        ((Station)SelectedItem).Items.Add(cdeBlock);
                        break;
                    default:
                        MessageBox.Show("A Muli Instance Function Block can only be added to Cell or Station!", 
                            "Add Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }           
            }
        }
        #endregion

        #region Tools menu
        private void SettingsCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void SettingsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SettingsDlg dlg = new SettingsDlg
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            dlg.ShowDialog();
        }
        #endregion

        #region Helper methods
        public bool NewProject()
        {
            // Instantiate the dialog box
            NewProjectDlg dlg = new NewProjectDlg { Owner = this };
            return (dlg.ShowDialog() == true);
        }

        public void OpenProject(string fileName)
        {
            // Open document
            Type[] extraTypes = new Type[12];
            extraTypes[0] = typeof(Cell);
            extraTypes[1] = typeof(Station);
            extraTypes[2] = typeof(PneuCyl);
            extraTypes[3] = typeof(Valve);
            extraTypes[4] = typeof(ValveIsland);
            extraTypes[5] = typeof(Motor);
            extraTypes[6] = typeof(Enclosure);
            extraTypes[7] = typeof(AGate);
            extraTypes[8] = typeof(Hmi);
            extraTypes[9] = typeof(HmiCB);
            extraTypes[10] = typeof(IoBlock);
            extraTypes[11] = typeof(CodeBlock);
            XmlSerializer serializer = new XmlSerializer(typeof(Project), extraTypes);
            try
            {
                Project prj;
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    prj = (Project)serializer.Deserialize(fileStream);
                }
                ((App)Application.Current).MyProjects.Add(prj);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open file!", "File Open Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.Write(ex.StackTrace);
            }
        }

        private void SaveProject()
        {
            if (((App)Application.Current).MyProjects.Count != 1)
            {
                MessageBox.Show("No project to save!", "Save error");
            }
            else
            {
                // Ceate a new Project object
                Project curProj = ((App)Application.Current).MyProjects[0];

                // Create Save file dialog box
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

                // Setup starting directory
                if (Properties.Settings.Default.DefaultProjectPath == null ||
                    Properties.Settings.Default.DefaultProjectPath == "")
                { } // Use system default Documents directory               
                else
                { dlg.InitialDirectory = Properties.Settings.Default.DefaultProjectPath; }

                // Setup default file name
                if (curProj.ProjFile == null || curProj.ProjFile == "")
                { dlg.FileName = curProj.LineName; } // Line name is default file name                
                else
                { dlg.FileName = curProj.ProjFile; }

                // Setup file type and extension
                dlg.DefaultExt = ".pcg"; // Default file extension
                dlg.Filter = "PLCcodeGen|*.pcg"; // Filter files by extension

                // Show Save file dialog box and process results
                if (dlg.ShowDialog() == true)
                {
                    // Create a serializer and a file stream;
                    Type[] extraTypes = new Type[12];
                    extraTypes[0] = typeof(Cell);
                    extraTypes[1] = typeof(Station);
                    extraTypes[2] = typeof(PneuCyl);
                    extraTypes[3] = typeof(Valve);
                    extraTypes[4] = typeof(ValveIsland);
                    extraTypes[5] = typeof(Motor);
                    extraTypes[6] = typeof(Enclosure);
                    extraTypes[7] = typeof(AGate);
                    extraTypes[8] = typeof(Hmi);
                    extraTypes[9] = typeof(HmiCB);
                    extraTypes[10] = typeof(IoBlock);
                    extraTypes[11] = typeof(CodeBlock);
                    XmlSerializer xs = new XmlSerializer(typeof(Project), extraTypes);
                    using (Stream stream = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write))
                    {
                        try
                        {
                            // Write current project to file in XML format
                            xs.Serialize(stream, curProj);

                            // Project successfully saved. 
                            // Save file name
                            curProj.ProjFile = dlg.FileName;
                        }
                        catch (InvalidOperationException e)
                        {
                            // Oops! Serialization failed.
                            Console.Write(e.StackTrace);
                            MessageBox.Show("Could not convert project to file!\nProject could not saved.", "Save error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        catch (Exception e)
                        {
                            // Oops! Something else went wrong.
                            Console.Write(e.StackTrace);
                            MessageBox.Show("Project could not be saved!", "Save error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else // User canceled.
                    MessageBox.Show("Project could not be saved!", "Save error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region Event methods
        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedItem = e.NewValue;
            currentItem.Content = e.NewValue;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView source = (ListView)e.Source;
            SelectedDetail = (Item)source.SelectedItem;

            // Clear Content if no item selected
            if(SelectedDetail == null)
            {
                itemDetail.Content = null;
                return;
            }
            itemDetail.Content = source.SelectedItem;
        }
        #endregion
    }

    public class ItemTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            
            if (element == null || item == null) return null;// No template...

            switch (item.GetType().Name)
            {
                case "Project":
                    return element.FindResource("ProjItemTemplate") as DataTemplate;
                case "Cell":
                    return element.FindResource("CellItemTemplate") as DataTemplate;
                case "Station":
                    return element.FindResource("StnItemTemplate") as DataTemplate;
                default:
                    // No template implemented for other types
                    return null;
            }            
        }
    }

    public class DetailTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object detail, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (element == null || detail == null) return null;// No template...

            switch (detail.GetType().Name)
            {
                case "PneuCyl":
                    return element.FindResource("PneuCylTemplate") as DataTemplate;
                case "Valve":
                    return element.FindResource("ValveTemplate") as DataTemplate;
                case "ValveIsland":
                    return element.FindResource("ValveIslandTemplate") as DataTemplate;
                case "Motor":
                    return element.FindResource("MotorTemplate") as DataTemplate;
                case "Enclosure":
                    return element.FindResource("EnclosureTemplate") as DataTemplate;
                case "AGate":
                    return element.FindResource("AGateTemplate") as DataTemplate;
                case "Hmi":
                    return element.FindResource("HmiTemplate") as DataTemplate;
                case "HmiCB":
                    return element.FindResource("HmiCBTemplate") as DataTemplate;
                case "IoBlock":
                    return element.FindResource("IoBlockTemplate") as DataTemplate;
                case "CodeBlock":
                    return element.FindResource("CodeBlockTemplate") as DataTemplate;
                default:
                    return null;
            }
        }
    }
}
