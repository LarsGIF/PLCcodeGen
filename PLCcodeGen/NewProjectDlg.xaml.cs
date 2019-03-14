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
            // if (!IsValid(this)) return;
            this.DialogResult = true; // Will also close the dialog.
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class PlcNameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // Name is valid.
            return new ValidationResult(true, null);
        }

    }
}
