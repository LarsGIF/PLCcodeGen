﻿using System;
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
        private ObservableCollection<EquipItem> equipItems = new ObservableCollection<EquipItem>();

        #region Properties Getters and Setters
        public string Name
        {
            get => name;
            set => name = value;
        }
        public ObservableCollection<EquipItem> EquipItems
        {
            get => equipItems;
            set => equipItems = value;
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
            equipItems.Add(new EquipItem(name));
        }

        public bool RemoveItem(string name)
        {
            int idx = equipItems.IndexOf(new EquipItem(name));
            if (idx >= 0)
            {
                equipItems.RemoveAt(idx);
                return true;
            }
            return false;
        }
    }
}
