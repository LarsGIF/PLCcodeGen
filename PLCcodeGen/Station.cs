using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    [Serializable]
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
        public Station()
        {
            this.name = "";
        }

        public Station(string name)
        {
            this.name = name;
        }
        #endregion
    }
}
