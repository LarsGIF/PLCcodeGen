using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PLCcodeGen
{
    /// <summary>
    /// Interaction logic for NewProjectDlg.xaml
    /// </summary>
    public partial class NewProjectDlg : Window
    {
        public NewProjectDlg()
        {
            InitializeComponent();
            mcpTypeCbo.Items.Add("AZS_12F1T12X");
            mcpTypeCbo.Items.Add("AZS_16F2T24X");
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            //if (!IsValid(this)) this.DialogResult = false;
            Project prj = new Project();
            prj.LineName = lineNameTxt.Text;
            prj.CtrlArea = (ControlArea)(this.DataContext);
            ((App)Application.Current).MyProjects.Add(prj);

            this.DialogResult = true; // Will also close the dialog.
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
