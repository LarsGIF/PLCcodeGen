using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    public class Station
    {
        private string name;
        private ObservableCollection<Item> items = new ObservableCollection<Item>();

        #region Properties Getters and Setters
        public string Name
        {
            get => name;
            set => name = value;
        }
        public ObservableCollection<Item> Items
        {
            get => items;
            set => items = value;
        }
        #endregion

        #region Constructors
        public Station(string name)
        {
            this.name = name;
        }
        #endregion

        public void AddItem(string name)
        {
            Items.Add(new Item(name));
        }

        public bool RemoveItem(string name)
        {
            int idx = Items.IndexOf(new Item(name));
            if (idx >= 0)
            {
                Items.RemoveAt(idx);
                return true;
            }
            return false;
        }
    }
}
