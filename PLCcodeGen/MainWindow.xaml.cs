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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLCcodeGen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Object SelectedItem;

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
                    Project.CreateProject(this);
                    break;
                case 1:
                    switch (MessageBox.Show(
                        "Only one project can be open at a time.\nDo you want to save current project before it is closed?",
                        "New project", MessageBoxButton.YesNoCancel, MessageBoxImage.Question))
                    {
                        case MessageBoxResult.Yes:
                            ((App)Application.Current).MyProjects.ElementAt(0).SaveProject();
                            break;
                        case MessageBoxResult.No:
                            break;
                        case MessageBoxResult.Cancel:
                            return;
                    }
                    if (Project.CreateProject(this))
                    {
                        // You will now have two projects in the tree. Remove the old one.
                        ((App)Application.Current).MyProjects.RemoveAt(0);
                    }
                    break;
                default:
                    MessageBox.Show(
                        "More than one project exists!\nPlease close current projects to continue.", 
                        "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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
                if(prj.OpenProject())
                    ((App)Application.Current).MyProjects.Add(prj);
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
                        ((App)Application.Current).MyProjects.ElementAt(0).SaveProject();
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
            if (((App)Application.Current).MyProjects.Count == 1)
                ((App)Application.Current).MyProjects.ElementAt(0).SaveProject();
            else
                MessageBox.Show(
                    "There is no project to save!",
                    "Save project", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void Exit_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
        #endregion

        #region Edit menu
        private void AddCellCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (((App)Application.Current).MyProjects.Count)==1;
        }
        private void AddCellCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            switch (((App)Application.Current).MyProjects.Count)
            { 
                case 0:
                    // This command should be disabled when Count is 0.
                    MessageBox.Show(
                        "There is no open project!\nPlese create or open a project to continue.",
                        "Add cell", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    break;
                case 1:
                    ((App)Application.Current).MyProjects.ElementAt(0).AddCell();
                    break;
                default:
                    MessageBox.Show(
                        "None or too many projects open!\nPlease close all projects and create or open a new to continue.",
                        "Add cell", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                break;
            }
        }
        #endregion

        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //SelectedItem = e.NewValue;
            currentItem.Content = e.NewValue; //SelectedItem;
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
