using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    class Cell
    {
        string name;
        List<int> perimeter;
        List<Station> stations;

        public Cell(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }

        public void AddStation(string name)
        {
            stations.Add(new Station(name));
        }

        public bool RemoveStation(string name)
        {
            int idx = stations.FindIndex(x => x.Name == name);
            if (idx >= 0)
            {
                stations.RemoveAt(idx);
                return true;
            }
            return false;
        }
    }
}
