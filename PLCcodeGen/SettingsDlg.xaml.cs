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
using System.Windows.Shapes;

namespace PLCcodeGen
{
    /// <summary>
    /// Interaction logic for SettingsDlg.xaml
    /// </summary>
    public partial class SettingsDlg : Window
    {
        public SettingsDlg()
        {
            InitializeComponent();
        }

        private void SaveSettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            // The Settings class is auto generated and do not support INotifyPropertyChanged.
            // Save modifications by code.
            Properties.Settings.Default.DefaultProjectPath = this.defPath.Text;
            Properties.Settings.Default.PreviousProjectPath = this.lastOpenedProj.Text; // Overwritten when app is closed.
            Properties.Settings.Default.LoadPreviousProject = (this.loadPrevProj.IsChecked == true);
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
