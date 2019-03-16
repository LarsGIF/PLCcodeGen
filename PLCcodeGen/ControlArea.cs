using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    public class ControlArea : INotifyPropertyChanged
    {
        private string plcName;
        private string baseProj;
        private List<int> perimeter;
        private List<Cell> cells;

        public event PropertyChangedEventHandler PropertyChanged;
        
        #region Properties Getters and Setters
        public string PlcName
        {
            get { return plcName; }
            set
            {
                plcName = value;
                OnPropertyChanged("PlcName");
            }
        }

        public string BaseProj
        {
            get { return baseProj; }
            set
            {
                baseProj = value;
                OnPropertyChanged("BaseProj");
            }
        }

        public List<int> Perimeter { get => perimeter; set => perimeter = value; }
        internal List<Cell> Cells { get => cells; set => cells = value; }
        #endregion

        #region Constructors
        public ControlArea()
        {
        }

        public ControlArea(string plcName)
        {
            this.plcName = plcName;
        }
        #endregion

        #region Methods
        public List<int> CreatePerimeter()
        {
            return null;
        }

        public void AddCell(string name)
        {
            cells.Add(new Cell(name));
        }

        public bool RemoveCell(string name)
        {
            int idx = cells.FindIndex(x => x.Name == name);
            if (idx >= 0) {
                cells.RemoveAt(idx);
                return true;
            }
            return false;
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
