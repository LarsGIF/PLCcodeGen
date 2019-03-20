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
        //private ObservableCollection<FuncBlock> funcBlocks = new ObservableCollection<FuncBlock>();
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
        /*public ObservableCollection<FuncBlock> FuncBlocks
        {
            get => funcBlocks;
            set => funcBlocks = value;
        }*/
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

        /*public void AddFBlock(string name)
        {
            funcBlocks.Add(new FuncBlock(name));
        }

        public bool RemoveFBlock(string name)
        {
            int idx = funcBlocks.IndexOf(new FuncBlock(name));
            if (idx >= 0)
            {
                funcBlocks.RemoveAt(idx);
                return true;
            }
            return false;
        }*/

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
