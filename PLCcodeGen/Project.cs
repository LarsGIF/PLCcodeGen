using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace PLCcodeGen
{
    public class Project
    {
        #region Properties Getters and Setters
        public string LineName { get; set; }
        public string ProjFile { get; set; }
        public ControlArea CtrlArea { get; set; }
        #endregion

        public bool CreateProject(MainWindow mWin)
        {
            // Instantiate the dialog box
            NewProjectDlg dlg = new NewProjectDlg { Owner = mWin };

            // Open the dialog box modally
            if (dlg.ShowDialog() == true)
            {
                CtrlArea = new ControlArea(dlg.plcNameTxt.Text);
                LineName = dlg.lineNameTxt.Text;
                CtrlArea.BaseProj = "AZS_16F2T24X";
                return true;
            }
            else
                return false;
        }

        public bool OpenProject()
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = ""; // Default file name
            dlg.DefaultExt = ".pcd"; // Default file extension
            dlg.Filter = "PLCcodeGen project (.pcd)|*.pcd"; // Filter files by extension

            // Show open file dialog box and process open file dialog box results
            if (dlg.ShowDialog() == true)
            {
                // Open document
                ProjFile = dlg.FileName;
                return true;
            }
            return false;
        }

        public void SaveProject()
        {
            if (((App)Application.Current).MyProjects.Count == 1)
            {
                // Configure save file dialog box
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = ProjFile; // Default file name
                dlg.DefaultExt = ".pcd"; // Default file extension
                dlg.Filter = "PLCcodeGen project (.pcd)|*.pcd"; // Filter files by extension

                // Show save file dialog box and process save file dialog box results
                if (dlg.ShowDialog() == true)
                {
                    // Save document
                    ProjFile = dlg.FileName;
                }
                else
                    MessageBox.Show("Project could not be saved!", "Save error");
            } else
                MessageBox.Show("No project to save!", "Save error");
        }

        public void AddCell()
        {
            string cellName = "Cell1";

            // Create a new cell
            TreeViewItem item = new TreeViewItem()
            {
                Header = cellName
            };
        }
    }
}
