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
    [Serializable]
    public class Project : INotifyPropertyChanged
    {
        private string lineName;
        private string projFile ="";
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

        }
        #endregion
 
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
        #endregion
    }
}
