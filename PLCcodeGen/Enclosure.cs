using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    class Enclosure
    {
        String name;
        List<FuncBlock> fBlocks = new List<FuncBlock>();

        public Enclosure(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }
        public List<FuncBlock> FBlocks { get => fBlocks; set => fBlocks = value; }
    }
}
