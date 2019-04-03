using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
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

        public MainWindow()
        {
            InitializeComponent();
            projectTree.ItemsSource = ((App)Application.Current).MyProjects;
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
            Project prj;

            if (((App)Application.Current).MyProjects.Count == 0)
            {
                prj = new Project();
                //(prj.OpenProject()){
                // Configure and open file dialog box
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = ""; // Default file name
                dlg.DefaultExt = ".pcg"; // Default file extension
                dlg.Filter = "PLCcodeGen|*.pcg|All files (*.*)|*.*"; // Filter files by extension

                // Show open file dialog box and process open file dialog box results
                if (dlg.ShowDialog() == true)
                {
                    // Open document
                    prj.ProjFile = dlg.FileName;
                    XmlSerializer serializer = new XmlSerializer(typeof(Project));
                    try { 
                        using (FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open))
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

        private void Exit_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
        #endregion

        #region Edit menu
        private void AddCellCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (((App)Application.Current).MyProjects.Count)==1 
                && SelectedItem != null && (SelectedItem.GetType().ToString() == "PLCcodeGen.Project");
        }
        private void AddCellCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {         
            //TODO: Add dialog to enter name of cell
            ((Project)SelectedItem).Cells.Add(new Cell("Cxxx"));
        }

        private void AddStnCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (((App)Application.Current).MyProjects.Count) == 1
                && SelectedItem != null && (SelectedItem.GetType().ToString() == "PLCcodeGen.Cell");
        }
        private void AddStnCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //TODO: Add dialog to enter name of station
            ((Cell)SelectedItem).Stations.Add(new Station("Sxxx"));
        }

        private void AddItemCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((App)Application.Current).MyProjects.Count == 1 && SelectedItem != null;
        }
        private void AddItemCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //TODO: Add dialog to enter name of item
            switch (SelectedItem.GetType().ToString()) {
                case "PLCcodeGen.Project":
                    ((Project)SelectedItem).Items.Add(new Item("Ixxx"));
                    break;
                case "PLCcodeGen.Cell":
                    ((Cell)SelectedItem).Items.Add(new Item("Ixxx"));
                    break;
                case "PLCcodeGen.Station":
                    ((Station)SelectedItem).Items.Add(new Item("Ixxx"));
                    break;
            }
        }
        #endregion

        #region helper methods
        public bool NewProject()
        {
            // Instantiate the dialog box
            NewProjectDlg dlg = new NewProjectDlg { Owner = this };
            return (dlg.ShowDialog() == true);
        }

        private void SaveProject()
        {
            if (((App)Application.Current).MyProjects.Count != 1)
            {
                MessageBox.Show("No project to save!", "Save error");
            }
            else
            {
                Project curProj = ((App)Application.Current).MyProjects[0];
                // Configure save file dialog box
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.DefaultExt = ".pcg"; // Default file extension
                dlg.Filter = "PLCcodeGen|*.pcg"; // Filter files by extension
                if (curProj.ProjFile == "")
                { dlg.FileName = curProj.LineName; } // Default file name                
                else
                { dlg.FileName = curProj.ProjFile; }

                // Show save file dialog box and process results
                if (dlg.ShowDialog() == true)
                {
                    // Save file name
                    curProj.ProjFile = dlg.FileName;

                    // Create a file stream;
                    XmlSerializer xs = new XmlSerializer(typeof(Project));
                    using (Stream stream = new FileStream(curProj.ProjFile, FileMode.Create, FileAccess.Write))
                    {
                        try
                        {
                            // Write current project to file
                            xs.Serialize(stream, curProj);
                        }
                        catch (Exception ex)
                        {
                            Console.Write(ex.StackTrace);
                            MessageBox.Show("Project could not be saved!", "Save error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else MessageBox.Show("Project could not be saved!", "Save error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedItem = e.NewValue;
            currentItem.Content = e.NewValue;
        }
    }

    public class PlcItemTemplateSelector : DataTemplateSelector
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
}
