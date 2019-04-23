using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PLCcodeGen
{
    [Serializable]
    public class Cell
    {
        private string name;
        private List<Point> perimeter = new List<Point>();
        private ObservableCollection<Station> stations = new ObservableCollection<Station>();
        private ObservableCollection<Item> items = new ObservableCollection<Item>();

        #region Properties Getters and Setters
        public string Name
        {
            get => name;
            set => name = value;
        }
        public List<Point> Perimeter
        {
            get => perimeter;
            set => perimeter = value;
        }
        public ObservableCollection<Station> Stations
        {
            get => stations;
            set => stations = value;
        }
        public ObservableCollection<Item> Items
        {
            get => items;
            set => items = value;
        }
        #endregion

        #region Constructors
        public Cell()
        {
            this.name = "";
        }

        public Cell(string name)
        {
            this.name = name;
        }
        #endregion
    }
}
