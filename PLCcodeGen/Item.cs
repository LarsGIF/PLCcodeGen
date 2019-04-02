using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    public class Item
    {
        private string name;
        private TypeOfItem itemType;
        private Item parentItem;
        private List<FuncBlock> fBlocks = new List<FuncBlock>();

        #region Properties Getters and Setters
        public string Name
        {
            get => name;
            set => name = value;
        }
        public TypeOfItem ItemType
        {
            get => itemType;
            set => itemType = value;
        }
        public Item ParentItem
        {
            get => parentItem;
            set => parentItem = value;
        }
        public List<FuncBlock> FBlocks
        {
            get => fBlocks;
            set => fBlocks = value;
        }
        #endregion

        #region Constructors
        public Item(string name)
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

    public enum TypeOfItem {
        undefined,      // Undefined item (default if not defined)
        cylinder,       // Cylinder
        valve,          // Pnematic valve
        motor,          // Electric motor
        encapulation,   // Encapsulation (power distribution panel AK, control panel AZ, interface panel AE, manual control panel AS)
        aGate,          // Access gate
        hmi,            // HMI
        hCB,            // Portable HMI connection box
        ioBlock,        // I/O block
        mfBlock,        // Multi instance function block
        sfBlock,        // Single instance function block
        seqBlock        // SFC function block
    };
}
