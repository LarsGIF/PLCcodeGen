using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    [Serializable]
    public class Item
    {
        private string name;
        private TypeOfItem itemType;
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

        public List<FuncBlock> FBlocks
        {
            get => fBlocks;
            set => fBlocks = value;
        }
        #endregion

        #region Constructors
        public Item()
        {
            this.name = "";
        }

        public Item(string name)
        {
            this.name = name;
        }
        #endregion
    }

    public enum TypeOfItem {
        undefined,      // Undefined item (default if not defined)
        cylinder,       // Cylinder
        valve,          // Pnematic valve
        valveIsland,    // Pnumatic valve island
        motor,          // Electric motor
        enclosure,      // Enclosure (power distribution panel AK, control panel AZ, interface panel AE, manual control panel AS)
        aGate,          // Access gate
        hmi,            // HMI
        hCB,            // Portable HMI connection box
        ioBlock,        // I/O block
        mfBlock,        // Multi instance function block
        sfBlock,        // Single instance function block
        seqBlock        // SFC function block
    };
}
