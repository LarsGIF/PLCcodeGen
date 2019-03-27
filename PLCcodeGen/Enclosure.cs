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
        List<FuncBlock> fBlocks;

        public Enclosure(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }

        public void AddFBlock(String name)
        {
            fBlocks.Add(new FuncBlock(name));
        }

        public bool RemoveFBlock(String name)
        {
            int idx = fBlocks.FindIndex(x => x.TypeName == name);
            if (idx >= 0)
            {
                fBlocks.RemoveAt(idx);
                return true;
            }
            return false;
        }
    }
}
