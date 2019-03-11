using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    class Station
    {
        string name;
        List<Item> items;

        public Station(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }

        public void AddStation(string name)
        {
            items.Add(new Item(name));
        }

        public bool RemoveItem(string name)
        {
            int idx = items.FindIndex(x => x.Name == name);
            if (idx >= 0)
            {
                items.RemoveAt(idx);
                return true;
            }
            return false;
        }
    }
}
