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
        public MainWindow()
        {
            InitializeComponent();

            // Get reference to TreeView
            TreeView pTree = this.ProjectTree;

            // Create a new cell

            TreeViewItem item = new TreeViewItem() {
                Header = "Cell 1"
            };
            pTree.Items.Add(item);

            MessageBox.Show("Started.");
        }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
