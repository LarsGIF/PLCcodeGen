using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PLCcodeGen
{
    public class Cell
    {
        private string name;
        private List<Point> perimeter = new List<Point>();
        private List<Item> items = new List<Item>();
        private ObservableCollection<Station> stations = new ObservableCollection<Station>();

        #region  Properties Getters and Setters
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
        public List<Item> Items
        {
            get => items;
            set => items = value;
        }
        public ObservableCollection<Station> Stations
        {
            get => stations;
            set => stations = value;
        }
        #endregion

        #region Constructors
        public Cell(string name)
        {
            this.name = name;
        }
        #endregion

        public void AddItem(string name)
        {
            items.Add(new Item(name));
        }

        public bool RemoveItem(string name)
        {
            int idx = items.IndexOf(new Item(name));
            if (idx >= 0)
            {
                items.RemoveAt(idx);
                return true;
            }
            return false;
        }

        public void AddStation(string name)
        {
            stations.Add(new Station(name));
        }

        public bool RemoveStation(string name)
        {
            int idx = stations.IndexOf(new Station(name));
            if (idx >= 0)
            {
                stations.RemoveAt(idx);
                return true;
            }
            return false;
        }
    }
}
