using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    public class EquipItem
    {
        private string name;
        private ObservableCollection<FuncBlock> fBlocks = new ObservableCollection<FuncBlock>();

        #region Properties Getters and Setters
        public string Name
        {
            get => name;
            set => name = value;
        }
        public ObservableCollection<FuncBlock> FBlocks
        {
            get => fBlocks;
            set => fBlocks = value;
        }
        #endregion

        #region Constructors
        public EquipItem(string name)
        {
            this.name = name;
        }
        #endregion

        public void AddFBlock(string name)
        {
            fBlocks.Add(new FuncBlock(name));
        }

        public bool RemoveFBlock(string name)
        {
            int idx = fBlocks.IndexOf(new FuncBlock(name));
            if (idx >= 0)
            {
                fBlocks.RemoveAt(idx);
                return true;
            }
            return false;
        }
    }
}
