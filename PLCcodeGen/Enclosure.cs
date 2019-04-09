using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    [Serializable]
    public class Enclosure
    {
        String name;
        List<FuncBlock> fBlocks = new List<FuncBlock>();

        #region Properties Getters and Setters
        public string Name { get => name; set => name = value; }
        public List<FuncBlock> FBlocks { get => fBlocks; set => fBlocks = value; }
        #endregion

        #region Constructors
        public Enclosure()
        {

        }

        public Enclosure(string name)
        {
            this.name = name;
        }
        #endregion
    }
}
