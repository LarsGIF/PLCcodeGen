using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace PLCcodeGen
{
    public class Project : INotifyPropertyChanged
    {
        public Object SelectedItem;

        private string lineName;
        private string projFile;
        private string plcName;
        private string baseProj;
        private List<Point> perimeter;
        private ObservableCollection<Item> items = new ObservableCollection<Item>();
        private ObservableCollection<Cell> cells = new ObservableCollection<Cell>();

        #region Properties Getters and Setters
        public string LineName
        {
            get => lineName;
            set
            {
                if(lineName != value)
                {
                    lineName = value;
                    OnPropertyChanged("LineName");
                }
            }
        }
        public string ProjFile
        {
            get => projFile;
            set => projFile = value;
        }
        public string PlcName
        {
            get => plcName; 
            set
            {
                if (plcName != value)
                { 
                    plcName = value;
                    OnPropertyChanged("PlcName");
                }
            }
        }
        public string BaseProj
        {
            get => baseProj; 
            set
            {
                if (baseProj != value)
                { 
                    baseProj = value;
                    OnPropertyChanged("BaseProj");
                }
            }
        }
        public List<Point> Perimeter
        {
            get => perimeter;
            set => perimeter = value;
        }
        public ObservableCollection<Item> Items
        {
            get => items;
            set => items = value;
        }
        public ObservableCollection<Cell> Cells
        {
            get => cells;
            set
            {
                cells = value;
                OnPropertyChanged("Cells");
            }
        }
        #endregion

        #region Property changed
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        #region Constructors
        public Project()
        {
            this.Cells = new ObservableCollection<Cell>();
        }
        #endregion

        public static bool CreateProject(MainWindow mWin)
        {
            // Instantiate the dialog box
            NewProjectDlg dlg = new NewProjectDlg { Owner = mWin };
            return (dlg.ShowDialog() == true);
        }

        public bool OpenProject()
        {
            // Configure and open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = ""; // Default file name
            dlg.DefaultExt = ".pcg"; // Default file extension
            dlg.Filter = "PLCcodeGen project (.pcg)|*.pcg"; // Filter files by extension

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
                dlg.DefaultExt = ".pcg"; // Default file extension
                dlg.Filter = "PLCcodeGen project (.pcg)|*.pcg"; // Filter files by extension

                // Show save file dialog box and process save file dialog box results
                if (dlg.ShowDialog() == true)
                {
                    // Save document
                    ProjFile = dlg.FileName;
                }
                else
                    MessageBox.Show("Project could not be saved!", "Save error");
            }
            else
                MessageBox.Show("No project to save!", "Save error");
        }

        #region Methods
        public List<Point> CreatePerimeter()
        {
            // Only for testing
            List<Point> perimeter = new List<Point>();
            perimeter.Add(new Point(100, 100));
            perimeter.Add(new Point(100, 150));
            perimeter.Add(new Point(150, 150));
            perimeter.Add(new Point(150, 100));
            return perimeter;
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

        public void AddCell(string name)
        {
            cells.Add(new Cell(name));
        }

        public bool RemoveCell(string name)
        {
            int idx = cells.IndexOf(new Cell("name"));
            if (idx >= 0)
            {
                cells.RemoveAt(idx);
                return true;
            }
            return false;
        }
        #endregion

    }
}
