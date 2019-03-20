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
            if (this.lineNameTxt.Text.Equals(""))
            {
                MessageBox.Show("\"Line name\" must not be empty.",
                    "Input Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (!IsValid(this)) {
                MessageBox.Show("No spaces allowed in \"PLC name\".", 
                    "Input Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            Project prj = new Project();
            prj.LineName = lineNameTxt.Text;
            prj = (Project)(this.DataContext);
            ((App)Application.Current).MyProjects.Add(prj);

            this.DialogResult = true; // Will also close the dialog.
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Validate all dependency objects in a window
        bool IsValid(DependencyObject node)
        {
            // Check if dependency object was passed
            if (node != null)
            {
                // Check if dependency object is valid.
                // NOTE: Validation.GetHasError works for controls that have validation rules attached 
                bool isValid = !Validation.GetHasError(node);
                if (!isValid)
                {
                    // If the dependency object is invalid, and it can receive the focus,
                    // set the focus
                    if (node is IInputElement) Keyboard.Focus((IInputElement)node);
                    return false;
                }
            }

            // If this dependency object is valid, check all child dependency objects
            foreach (object subnode in LogicalTreeHelper.GetChildren(node))
            {
               if (subnode is DependencyObject)
                {
                    // If a child dependency object is invalid, return false immediately,
                    // otherwise keep checking
                    if (IsValid((DependencyObject)subnode) == false) return false;
                }
            }

            // All dependency objects are valid
            return true;
        }

    }

    class NoWhiteSpaceRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (((String)value).Contains(" "))
                return new ValidationResult(false, "Space characters are not allowed.");
            else
                return ValidationResult.ValidResult;
        }
    }
}
